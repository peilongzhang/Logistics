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
    public class LineController : Controller
    {
        public Lines lines;
        public LineController(Lines _lines)
        {
            lines = _lines;

        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("Lineshow")]
        [HttpGet]
        public IActionResult Lineshow()
        {
            //异常处理-   
            try
            {
                List<Line> line = lines.Lineshow();

                return Ok(line);
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
        [Route("LineCha")]
        [HttpGet]
        public IActionResult LineCha(string name)
        {
            //异常处理-   
            try
            {
                List<Line> line = lines.LineCha(name);

                return Ok(line);
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
        [Route("LineAdd")]
        [HttpPost]
        public IActionResult LineAdd(Line Line)
        {
            //异常处理-   
            try
            {
                int line = lines.LineAdd(Line);
                if (line > 0)
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

        [Route("LineDel")]
        [HttpPost]
        public IActionResult LineDel(int id)
        {
            //异常处理-   
            try
            {
                int line = lines.LineDel(id);
                if (line > 0)
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
        [Route("LineFan")]
        [HttpGet]
        public IActionResult LineFan(int id)
        {
            //异常处理-   
            try
            {
                Line line = lines.LineFan(id);
                return Ok(line);
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
        [Route("LineUpd")]
        [HttpPost]
        public IActionResult LineUpd(Line Line)
        {
            //异常处理-   
            try
            {
                int line = lines.LineUpd(Line);
                if (line > 0)
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
