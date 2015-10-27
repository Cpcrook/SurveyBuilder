using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrookSurveyBuilder.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            return PartialView();
        }
    }
}