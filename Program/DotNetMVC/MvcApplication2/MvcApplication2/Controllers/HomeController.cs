using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenRTM.Core;
using OpenRTM.IIOP;
using log4net;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

                ViewData["Message"] = "ASP.NET MVC へようこそ";
                var manager = new Manager();
                manager.AddTypes(typeof(CorbaProtocolManager));
                manager.Activate();
                var comp = manager.CreateComponent<ExampleComponent>();
                manager.Run();


            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
