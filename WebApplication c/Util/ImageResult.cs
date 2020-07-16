using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//css image stiles
namespace WebApplication_c.Util
{
    public class ImageResult : ActionResult
    {
        private string path;

        public ImageResult(string path)
        {
            this.path = path;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div style='width:100%;text-align:center;'>" +
                "<img style='max-width:900px;' src='" + path + "' /></div>");
        }
    }
}