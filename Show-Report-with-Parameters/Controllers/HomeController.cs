using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;
using System.Collections;

namespace Show_Report_with_Parameters.Controllers
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
            string reportString = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "\\reports\\ParametersSelectingCountry.mrt");

            // The parameter name must match the variable name in the report
            var reportParameters = new Hashtable();
            reportParameters["AllCountries"] = false;
            reportParameters["SelectedCountry"] = "USA";

            return StiNetCoreViewer.GetReportResult(this, reportString, reportParameters);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
