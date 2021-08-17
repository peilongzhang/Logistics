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
    public class JurisdictionController : Controller
    {
        public JurisdictionJ  JurisdictionJ;
        public JurisdictionController(JurisdictionJ _JurisdictionJ)
        {
            JurisdictionJ = _JurisdictionJ;

        }
        /// <summary>
        /// 权限显示
        /// </summary>
        /// <returns></returns>
        [Route("Jurisdictionshow")]
        [HttpGet]
        public IActionResult Jurisdictionshow()
        {
            //异常处理-
            try
            {
                List<Jurisdiction> Jurisdiction = JurisdictionJ.Jurisdictionshow();
                
                return Ok(Jurisdiction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("JurisdictionCha")]
        [HttpGet]
        public IActionResult JurisdictionCha(int id)
        {
            //异常处理-
            try
            {
                List<Jurisdiction> Jurisdiction = JurisdictionJ.JurisdictionCha(id);

                return Ok(Jurisdiction);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
