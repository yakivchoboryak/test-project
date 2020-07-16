using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_c.Util;

namespace WebApplication_c.Controllers
{
    public class HomeController : Controller
    {
       

        //відправка файлів користувачу
        // 1 спосіб
        public FilePathResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/test.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";// тип файла
            // Имя файла - необязательно
            string file_name = "test.pdf";
            return File(file_path, file_type, file_name); //різний підхід до зчитування
        }
        //2 cпосіб
        public FileResult GetBytes()
        {
            //string path = Server.MapPath("~/Files/test.pdf"); // шлях до файла
            string path = "C://Users//MSI GV62//source//repos//WebApplication c//WebApplication c//Files//test.pdf"; // шлях до файла
            byte[] mas = System.IO.File.ReadAllBytes(path); //різний підхід до зчитування
           // string file_type = "application/pdf"; // тип файла

            string file_type = "application/octet-stream";//universal tipe
            string file_name = "test.pdf";
            return File(mas, file_type, file_name);
        }
        //3 cпосіб
        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Files/test.pdf"); // шлях до файла
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open); //різний підхід до зчитування
            string file_type = "application/pdf"; // тип файла
            string file_name = "test.pdf";
            return File(fs, file_type, file_name);
        }
        public string GetData()
        {

            string id = HttpContext.Response.Cookies["id"].Value = "ca-435w";
            var val = Session["name"];
            return val.ToString();
         //   return id.ToString();
        }
// основний контроллер*
        public ViewResult  Index()
        {
            Session["name"] = "Tom";
        HttpContext.Response.Cookies["id"].Value = "ca-435w";// кука)

            ViewBag.Head = "Привет мир!";
            return View();
        }
        // /Home/GetVoid/numder      /Home/GetVoid?id=number   
        //number це айді залежно від якого
        // будуть здійснюватись переходи
        public ActionResult GetVoid(int id)
        {
            if (id > 3) { return RedirectPermanent("/Home/Con?tact"); }
            return View("About");
            
        }
        //вивід зображення
        // "звідси WebApplication_c.Util"
        //отже файл стилів в Util -> "ImageResult.cs"
        public ActionResult GetImage()
        {
            string path = "../Content/Images/34799.jpg";
            return new ImageResult(path);
        }
        //інтегрування html коду
        //звідси "WebApplication_c.Util"
        //отже файл коду знаходиться в Util -> " Htmlresult.cs"
        public ActionResult GetHtml()
        {
            return new Htmlresult("<h1>Привіт!</h1>");
        }
        //вивід id
        public string GetId(int id)
        {
            return id.ToString();
        }
        //одна назва але різні потоки
        //in
        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        //out
        [HttpPost]
        public string  GetBook(string title,string autor)
        {
            return title + " " + autor;
        }
        //одержання параметрів з id
        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>";
        }

        public string GetContext()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }
        private ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}