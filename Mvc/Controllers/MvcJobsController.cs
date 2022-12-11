using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class MvcJobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            return View();
        }
    }
}