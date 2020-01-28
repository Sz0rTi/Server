using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.TwoWay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Services
{
    public class SummaryService : ISummaryService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public SummaryService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }
        public async Task<List<Summary>> PostSummaries(InvoicesDate date)
        {
            var temp = await _context.Summaries.Where(s => s.UserID == UserId && s.Month == date.Month && s.Year == date.Year).ToListAsync();
            return temp;
        }

        public async Task<Summary> GetSummary(Guid id)
        {
            var temp = await _context.Summaries.Where(s => s.UserID == UserId && s.ID == id).Include(i => i.SummaryProductBuys).Include(i => i.SummaryProductSells).FirstOrDefaultAsync();
            if (temp == null) return null;
            else return temp;
        }

        public async Task<Summary> PostSummary(InvoicesDate date)
        {
            var invoicesells = await _context.InvoicesSell.Where(i => i.UserID == UserId && i.Date.Month == date.Month && i.Date.Year == date.Year).Include(i=>i.ProductsSell).ToListAsync();
            var invoicebuys = await _context.InvoicesBuy.Where(i => i.UserID == UserId && i.Date.Month == date.Month && i.Date.Year == date.Year).Include(i => i.ProductsBuy).ToListAsync();
            Summary summary = new Summary();
            summary.SummaryProductBuys = new List<SummaryProductBuy>();
            summary.SummaryProductSells = new List<SummaryProductSell>();
            foreach(var item in invoicesells)
            {
                foreach(var sell in item.ProductsSell)
                {
                    bool IfExist = summary.SummaryProductSells.Any(p => p.ProductName == sell.Name);
                    if(!IfExist)
                    {
                        summary.SummaryProductSells.Add(new SummaryProductSell
                        {
                            ProductName = sell.Name,
                            Amount = sell.Amount,
                            AvgBuyPrice = sell.BasePriceNetto,
                            AvgSellPrice = sell.PricePerItemNetto,
                            AvgEarn = sell.PricePerItemNetto - sell.BasePriceNetto,
                            SumBought = sell.Amount * sell.BasePriceNetto,
                            SumSold = sell.Amount * sell.PricePerItemNetto,
                            SumEarned = (sell.Amount * sell.PricePerItemNetto) - (sell.Amount * sell.BasePriceNetto),
                            UserID = UserId
                        });
                    }
                    else
                    {
                        var product = summary.SummaryProductSells.First(s => s.ProductName == sell.Name);
                        product.AvgBuyPrice = ((product.Amount*product.AvgBuyPrice)+(sell.BasePriceNetto*sell.Amount))/(product.Amount+sell.Amount);
                        product.AvgSellPrice = ((product.Amount * product.AvgSellPrice) + (sell.PricePerItemNetto * sell.Amount)) / (product.Amount + sell.Amount);
                        product.Amount += sell.Amount;
                        product.SumBought += sell.Amount * sell.BasePriceNetto;
                        product.SumSold += sell.Amount * sell.PricePerItemNetto;
                        product.SumEarned += (sell.Amount * sell.PricePerItemNetto) - (sell.Amount * sell.BasePriceNetto);
                    }
                }
            }
            
            summary.SumEarned = summary.SummaryProductSells.Sum(s => s.SumEarned);
            summary.SumSold = summary.SummaryProductSells.Sum(s => s.SumSold);

            foreach (var item in invoicebuys)
            {
                foreach (var buy in item.ProductsBuy)
                {
                    bool IfExist = summary.SummaryProductBuys.Any(p => p.ProductName == buy.Name);
                    if (!IfExist)
                    {
                        summary.SummaryProductBuys.Add(new SummaryProductBuy
                        {
                            ProductName = buy.Name,
                            Amount = buy.Amount,
                            AvgBuyPrice = buy.PricePerItemNetto,
                            SumBought = buy.Amount * buy.PricePerItemNetto,
                            UserID = UserId
                        });
                    }
                    else
                    {
                        var product = summary.SummaryProductBuys.First(s => s.ProductName == buy.Name);
                        product.AvgBuyPrice = ((product.Amount * product.AvgBuyPrice) + (buy.PricePerItemNetto * buy.Amount)) / (product.Amount + buy.Amount);
                        product.Amount += buy.Amount;
                        product.SumBought += buy.Amount * buy.PricePerItemNetto;
                    }
                }
            }
            summary.SumBought = summary.SummaryProductBuys.Sum(s => s.SumBought);

            summary.Month = date.Month;
            summary.Year = date.Year;
            summary.UserID = UserId;
            summary.Date = DateTime.Now;
            _context.Summaries.Add(summary);
            await _context.SaveChangesAsync();
            return summary;
        }

        public async Task<InvoicesDate> GetMinDate()
        {
            InvoicesDate MinDate = new InvoicesDate();
            try
            {
                var temp = (from d in _context.Summaries.Where(i => i.UserID == UserId) select d.Date).Min();
                MinDate.Month = temp.Month;
                MinDate.Year = temp.Year;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
            return new InvoicesDate { Year = MinDate.Year, Month = MinDate.Month };
        }
    }

    public interface ISummaryService
    {
        Task<Summary> GetSummary(Guid id);
        Task<List<Summary>> PostSummaries(InvoicesDate date);
        Task<Summary> PostSummary(InvoicesDate date);
        Task<InvoicesDate> GetMinDate();
    }
}
