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
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerRenController : Controller
    {
        public Owners Owners;
        public OwnerRenController(Owners _Owners)
        {
            Owners = _Owners;

        }
        /// <summary>
        /// 货主管理显示
        /// </summary>
        /// <returns></returns>
        [Route("OwnerRenshow")]
        [HttpGet]
        public IActionResult OwnerRenshow()
        {
            //异常处理-   
            try
            {
                List<OwnerRen> ren = Owners.OwnerRenshow();

                return Ok(ren);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 货主管理查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("OwnerRenCha")]
        [HttpGet]
        public IActionResult OwnerRenCha(string name)
        {
            //异常处理-   
            try
            {
                List<OwnerRen> ren = Owners.OwnerRenCha(name);

                return Ok(ren);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
