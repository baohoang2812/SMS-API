using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Data.Extensions;
using StudentManagement.Data.Repository;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using StudentManagementAPI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthController.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAdminService adminService;
        private readonly IConfiguration configuration;
        public AuthController (IAdminService adminService, IConfiguration configuration)
        {
            this.adminService = adminService;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(AdminViewModel model)
        {
            var user = adminService.FindByUsername(model.Username);
            var valid = adminService.CheckPassword(model.Username, model.Password);
            if (user != null && valid)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())                  
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
                var apiUrl = configuration.GetSection("AppSettings:Url").Value;
                var token = new JwtSecurityToken(
                    issuer: apiUrl,
                    audience: apiUrl,
                    expires: DateTime.Now.AddYears(13),
                    claims: authClaims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),                   
                    username = user.Username,                  
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
      

      
       
        
    }
}
