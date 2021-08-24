using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticsLogin;
using LogisticsModel;

namespace LogisticsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutsourcesController : Controller
    {
        public Outsources Outsources;
        public OutsourcesController(Outsources _Outsources)
        {
            Outsources = _Outsources;

        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("Outsourcesshow")]
        [HttpGet]
        public IActionResult Outsourcesshow()
        {
            //异常处理-   
            try
            {
                List<Outsource> Outsource = Outsources.Outsourcesshow();

                return Ok(Outsource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("OutsourcesCha")]
        [HttpGet]
        public IActionResult OutsourcesCha(string name)
        {
            //异常处理-   
            try
            {
                List<Outsource> Outsource = Outsources.OutsourcesCha(name);
                 
                return Ok(Outsource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [Route("OutsourcesAdd")]
        [HttpPost]
        public IActionResult OutsourcesAdd(Outsource outsource)
        {
            //异常处理-   
            try
            {
                int Outsource = Outsources.OutsourcesAdd(outsource);
                if (Outsource > 0)
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

        [Route("OutsourcesDel")]
        [HttpPost]
        public IActionResult OutsourcesDel(int id)
        {
            //异常处理-   
            try
            {
                int Outsource = Outsources.OutsourcesDel(id);
                if (Outsource > 0)
                {
                    return Ok(new { msg = "删除成功" });
                }
                else
                {
                    return Ok(new { msg = "删除成功" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("OutsourcesFan")]
        [HttpGet]
        public IActionResult OutsourcesFan(int id)
        {
            //异常处理-   
            try
            {
                Outsource Outsource = Outsources.OutsourcesFan(id);
                return Ok(Outsource);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        [Route("OutsourcesUpd")]
        [HttpPost]
        public IActionResult OutsourcesUpd(Outsource outsource)
        {
            //异常处理-   
            try
            {
                int Outsource = Outsources.OutsourcesUpd(outsource);
                if (Outsource > 0)
                {
                    return Ok(new { msg = "修改成功" });
                }
                else
                {
                    return Ok(new { msg = "修改成功" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
