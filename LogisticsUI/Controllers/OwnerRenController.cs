﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// 货主管理添加
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        [Route("OwnerRenAdd")]
        [HttpPost]
        public IActionResult OwnerRenAdd(OwnerRen Ownerren)
        {
            //异常处理-   
            try
            {
                int car = Owners.OwnerRenAdd(Ownerren);
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
        /// 货主管理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("OwnerRenDel")]
        [HttpPost]
        public IActionResult OwnerRenDel(int id)
        {
            //异常处理-   
            try
            {
                int car = Owners.OwnerRenDel(id);
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
        /// 货主管理反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("OwnerRenFan")]
        [HttpGet]
        public IActionResult OwnerRenFan(int id)
        {
            //异常处理-   
            try
            {
                OwnerRen car = Owners.OwnerRenFan(id);
                return Ok(car);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 货主管理修改
        /// </summary>
        /// <param name="Ownerren"></param>
        /// <returns></returns>
        [Route("OwnerRenUpd")]
        [HttpPost]
        public IActionResult OwnerRenUpd(OwnerRen Ownerren)
        {
            //异常处理-   
            try
            {
                int car = Owners.OwnerRenUpd(Ownerren);
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
