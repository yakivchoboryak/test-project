using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_c.Util
{
    public class Htmlresult : ActionResult
    {
        private string htmlCode;
        public Htmlresult(string html)
        {
            htmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html>" +
                "<html> <head>";
            fullHtmlCode += "<title> Главная страница </title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head>  <body>";
            fullHtmlCode += htmlCode;
            fullHtmlCode += "</body>  </html>";
            context.HttpContext.Response.Write(fullHtmlCode);//контекст запроса . обєкт відповіді -> в вихідний потік
        }
    }
}