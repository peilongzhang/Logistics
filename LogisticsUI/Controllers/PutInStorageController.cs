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
    public class PutInStorageController : Controller
    {
        public PutIns Putins;
        public PutInStorageController(PutIns _Putins)
        {
            Putins = _Putins;

        }
        /// <summary>
        /// 入库显示
        /// </summary>
        /// <returns></returns>
        [Route("PutInStorageshow")]
        [HttpGet]
        public IActionResult PutInStorageshow()
        {
            //异常处理-   
            try
            {
                List<PutInStorage> PutIn = Putins.PutInStorageshow();

                return Ok(PutIn);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 入库添加
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Route("PutInStorageAdd")]
        [HttpPost]
        public IActionResult PutInStorageAdd(PutInStorage PutInstorage)
        {
            //异常处理-   
            try
            {
                int PutIn = Putins.PutInStorageAdd(PutInstorage);
                if (PutIn > 0)
                {
                    return Ok(new { msg = "添加成功" });
                }
                else
                {
                    return Ok(new { msg = "添加成功" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
