using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_HR3_MVC.Models;

namespace WebApp_HR3_MVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.News = NewsBase.News;

            return View();
        }
    }
}
