using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsLogin;
using LogisticsModel;

namespace LogisticsUI.Controllers
{
    
    [Route("Login")]
    [ApiController]
    public class LoginController : Controller
    {
        public Loginlogin Loginlogin;
        public LoginController(Loginlogin _loginlogin)
        {
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

                return Ok( _users );
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
