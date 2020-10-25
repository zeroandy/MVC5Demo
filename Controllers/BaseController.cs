﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/?redir=" + actionName).ExecuteResult(ControllerContext);
        }
    }
}