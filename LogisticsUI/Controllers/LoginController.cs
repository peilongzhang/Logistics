using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsLogin;
using LogisticsModel;
using Microsoft.Extensions.Options;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace LogisticsUI.Controllers
{
    
    [Route("Login")]
    [ApiController]
    public class LoginController : Controller
    {
        public Loginlogin Loginlogin;
        private JwtConfig jwtconfig;
        public LoginController(IOptions<JwtConfig> option, Loginlogin _loginlogin)
        {
            jwtconfig = option.Value;
            Loginlogin = _loginlogin;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UsersName"></param>
        /// <param name="UsersPass"></param>
        /// <returns></returns>
        [Route(nameof(LoginShow))]
        [HttpPost]
        public IActionResult LoginShow(string UsersName, string UsersPass)
        {
            //异常处理
            try
            {
                Users _users = Loginlogin.LoginShow(UsersName, UsersPass);
                var claim = new Claim[]{
            new Claim("UsersName", "lb")
        };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.SigningKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: jwtconfig.Issuer,
                    audience: jwtconfig.Audience,
                    claims: claim,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddSeconds(30),
                    signingCredentials: creds);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), UsersId = UsersName });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
