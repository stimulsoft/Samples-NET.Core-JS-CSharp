using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostEnvironment;

        public HomeController(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Stimulsoft Reports.Web for .NET Core";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Stimulsoft";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            // You can use report string or path to report template MRT file
            string reportString = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "\\reports\\SimpleList.mrt");
            return StiNetCoreDesigner.GetReportResult(this, reportString);

            //return StiNetCoreDesigner.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\SimpleList.mrt");
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}
