using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrookSurveyBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Crook's Survey Builder";

            return View();
        }

        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult Surveys()
        {
            return PartialView();
        }

        public ActionResult NewSurvey()
        {
            return PartialView();
        }

        public ActionResult TakeSurvey()
        {
            return PartialView();
        }

        public ActionResult SurveyComplete()
        {
            return PartialView();
        }
    }
}
