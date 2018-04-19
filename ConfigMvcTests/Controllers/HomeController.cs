using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigMvcTests.Models;
using Microsoft.Extensions.Options;

namespace ConfigMvcTests.Controllers
{
    public class HomeController : Controller
    {
        IOptions<MySettings> _mySettings;
        IOptions<MyLogging> _myLogging;
        public HomeController(IOptions<MySettings> mySettingOptions, IOptions<MyLogging> myLogging)
        {
            _mySettings = mySettingOptions;
            _myLogging = myLogging;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MySettings()
        {
            return Json(_mySettings.Value);
        }
        public IActionResult MyLogging()
        {
            return Json(_myLogging);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
