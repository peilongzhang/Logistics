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
    public class AllocationController : Controller
    {
        public Allocation allocation; 
        public AllocationController(Allocation _allocation)
        {
            allocation = _allocation;

        }
        /// <summary>
        /// 角色功能
        /// </summary>
        /// <param name="UsersName"></param>
        /// <param name="UsersPass"></param>
        /// <returns></returns>
        [Route("Allocationshow")]
        [HttpGet]
        public IActionResult Allocationshow(string UsersName, string UsersPass)
        {
            //异常处理-   
            try
            {
                List<UsersRole> allocations = allocation.allocationshow(UsersName,UsersPass);
                
                return Ok(allocations);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 查询上一级权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("allocationCha")]
        [HttpGet]
        public IActionResult allocationCha(int id)
        {
            //异常处理-   
            try
            {
                List<UsersRole> allocations = allocation.allocationCha(id);

                return Ok(allocations);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
