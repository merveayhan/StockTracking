using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockTracking.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        // GET: Admin/AppUser
        public ActionResult Index()
        {
            return View();
        }
    }
}