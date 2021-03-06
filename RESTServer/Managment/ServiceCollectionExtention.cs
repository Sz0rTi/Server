﻿using Managment.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment
{
    public static class ServiceCollectionExtention
    {
        public static void AddManagment(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceSellService, InvoiceSellService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITaxStageService, TaxStageService>();
            services.AddScoped<IInvoiceSellService, InvoiceSellService>();
            services.AddScoped<IGUSService, GUSService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IInvoiceBuyService, InvoiceBuyService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISummaryService, SummaryService>();
        }
    }
}
