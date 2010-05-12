﻿using System.Web.Mvc;

namespace Restfulie.Server.Results
{
    public abstract class RestfulieResult : ActionResult
    {
        protected void SetStatusCode(ControllerContext context, StatusCodes status)
        {
            context.HttpContext.Response.StatusCode = (int)status;
        }

        protected void Write(ControllerContext context, string content)
        {
            context.HttpContext.Response.Output.Write(content);
            context.HttpContext.Response.Output.Flush();
        }
    }
}