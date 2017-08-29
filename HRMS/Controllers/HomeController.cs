using HRMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class HomeController : BaseController
    {

        #region Declaration
        private readonly SeedService _seedService = null;
        public HomeController()
        {
            this._seedService = new SeedService(db);
        }
        #endregion

        public ActionResult Index()
        {
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

        #region Remove on Production
        [AllowAnonymous]
        public ActionResult Seed()
        {
            return Content("To seed the database took-> " + _seedService.Seed());
        }
        #endregion
    }
}