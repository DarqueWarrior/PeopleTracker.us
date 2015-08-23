using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace WebApplication1.Controllers
{
   public class HomeController : Controller
   {
      private IOptions<SiteOptions> siteOptions;

      public HomeController(IOptions<SiteOptions> options)
      {
         this.siteOptions = options;
      }

      public IActionResult Index()
      {
         ViewData["WebApiBaseUrl"] = this.siteOptions.Options.WebApiBaseUrl;

         return View();
      }

      public IActionResult About()
      {
         ViewData["Message"] = "Your application description page.";
         ViewData["WebApiBaseUrl"] = this.siteOptions.Options.WebApiBaseUrl;

         return View();
      }

      public IActionResult Contact()
      {
         ViewData["Message"] = "Your contact page.";
         ViewData["WebApiBaseUrl"] = this.siteOptions.Options.WebApiBaseUrl;

         return View();
      }

      public IActionResult Error()
      {
         ViewData["WebApiBaseUrl"] = this.siteOptions.Options.WebApiBaseUrl;
         return View("~/Views/Shared/Error.cshtml");
      }
   }
}
