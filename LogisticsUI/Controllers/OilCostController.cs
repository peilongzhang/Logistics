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
    public class OilCostController : Controller
    {

        public OilCosts Oilcost;
        public OilCostController(OilCosts _Oilcost)
        {
            Oilcost = _Oilcost;

        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("OilCostshow")]
        [HttpGet]
        public IActionResult OilCostshow()
        {
            //异常处理-   
            try
            {
                List<OilCost> oilcost = Oilcost.OilCostshow();

                return Ok(oilcost);
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
        [Route("OilCostCha")]
        [HttpGet]
        public IActionResult OilCostCha(string name)
        {
            //异常处理-   
            try
            {
                List<OilCost> oilcost = Oilcost.OilCostCha(name);

                return Ok(oilcost);
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
        [Route("OilCostAdd")]
        [HttpPost]
        public IActionResult OilCostAdd(OilCost OilCost)
        {
            //异常处理-   
            try
            {
                int oilcost = Oilcost.OilCostAdd(OilCost);
                if (oilcost > 0)
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

        [Route("OilCostDel")]
        [HttpPost]
        public IActionResult OilCostDel(int id)
        {
            //异常处理-   
            try
            {
                int oilcost = Oilcost.OilCostDel(id);
                if (oilcost > 0)
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
        [Route("OilCostFan")]
        [HttpGet]
        public IActionResult OilCostFan(int id)
        {
            //异常处理-   
            try
            {
                OilCost oilcost = Oilcost.OilCostFan(id);
                return Ok(oilcost);
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
        [Route("OilCostUpd")]
        [HttpPost]
        public IActionResult OilCostUpd(OilCost OilCost)
        {
            //异常处理-   
            try
            {
                int oilcost = Oilcost.OilCostUpd(OilCost);
                if (oilcost > 0)
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
