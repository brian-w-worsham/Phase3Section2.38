using Microsoft.AspNetCore.Mvc;
using Phase3Section2._38.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Phase3Section3._38.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int age = Convert.ToInt16(form["age"]);
            return View();
        }


        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index2(FormCollection form)
        {
            try
            {
                int age = Convert.ToInt16(form["age"]);
            }
            catch (Exception ex)
            {
                // Handle the exception and possibly log it
                ViewData["error"] = ex.Message;
                // Get the request ID from HttpContext and pass it to the Error action
                string requestId = HttpContext.TraceIdentifier;
                return RedirectToAction("Error", new { requestId });
            }
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error(string requestId)
        {
            ErrorViewModel error = new ErrorViewModel();
            error.RequestId = requestId;
            return View("Error", error);
        }
    }
}
