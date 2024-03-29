﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticsUI.Controllers
{
    public class GuoLvQiController : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string guolvqi = context.HttpContext.Session.GetString("name");
            if (context.HttpContext.Session.GetString("name") == null)
            {
                context.Result = new RedirectResult("/Login/LoginShow");
            }
        }
    }
}
