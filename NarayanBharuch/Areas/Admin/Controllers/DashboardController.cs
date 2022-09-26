using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NarayanBharuch.Areas.Admin.Controllers
{
    public class DashboardController : SessionController
    {
        // GET: Admin/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}