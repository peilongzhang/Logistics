using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsLogin;
using LogisticsModel;
using Microsoft.AspNetCore.Authorization;

namespace LogisticsUI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VehicleController : Controller
    {
        public Cars cars;
        public VehicleController(Cars _cars)
        {
            cars = _cars;

        }
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        [Route("Carshow")]
        
        [HttpGet]
        public IActionResult Carshow()
        {
            //异常处理-   
            try
            {
                List<Vehicle> car = cars.Carshow();
                return Ok(car);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 显示车辆查询
        /// </summary>
        /// <returns></returns>
        [Route("CarCha")]
        [HttpGet]
        public IActionResult CarCha(string name)
        {
            //异常处理-   
            try
            {
                List<Vehicle> car = cars.CarCha(name);
                return Ok(car);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 车辆管理添加
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("CarAdd")]
        [HttpPost]
        public IActionResult CarAdd(Vehicle vehicle)
        {
            //异常处理-   
            try
            {
                int car = cars.CarAdd(vehicle);
                if (car > 0)
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
        /// <summary>
        /// 车辆管理删除
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [Route("CarDel")]
        [HttpPost]
        public IActionResult CarDel(int id)
        {
            //异常处理-   
            try
            {
                int car = cars.CarDel(id);
                if (car > 0)
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
        /// 车辆管理反填
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [Route("CarFan")]
        [HttpGet]
        public IActionResult CarFan(int id)
        {
            //异常处理-   
            try
            {
                Vehicle car = cars.CarFan(id);
                return Ok(car);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 车辆管理修改
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>

        [Route("CarUpd")]
        [HttpPost]
        public IActionResult CarUpd(Vehicle vehicle)
        {
            //异常处理-   
            try
            {
                int car = cars.CarUpd(vehicle);
                if (car > 0)
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
