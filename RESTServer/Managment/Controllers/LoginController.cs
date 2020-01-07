using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
using Managment.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly IConfiguration _service;
        private readonly SignInManager<IdentityUser> _manager;

        public LoginController(IConfiguration service, SignInManager<IdentityUser> manager)
        {
            _service = service;
            _manager = manager;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostLogin(LoginModel login)
        {
            var result = await _manager.PasswordSignInAsync(login.Email, login.Password, false, false);
            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Błędny login lub hasło." });
            var user = await _manager.UserManager.FindByNameAsync(login.Email);
            var roles = await _manager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, login.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_service["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_service["ExpireTime"]));

            var token = new JwtSecurityToken(
                _service["Issuer"],
                _service["Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token), Error = null });
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostRegister(RegisterModel model)
        {
            IdentityUser user = new IdentityUser(model.Email);
            if (model.Password == model.ConfirmPassword)
            {
                await _manager.UserManager.CreateAsync(user, model.Password);
                await _manager.UserManager.AddToRoleAsync(user, "User");
                return Ok(new RegisterResult { Successful = true, Errors = new List<string>() });
            }
            else
            {
                return BadRequest(new RegisterResult { Successful = false, Errors = new List<string> { new string("Passwords missmatch") } });
            }

        }
    }
}
