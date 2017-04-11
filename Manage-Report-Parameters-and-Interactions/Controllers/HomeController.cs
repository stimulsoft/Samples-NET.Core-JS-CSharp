using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;
using System.Collections;

namespace Manage_Report_Parameters_and_Interactions.Controllers
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
            return StiNetCoreViewer.GetReportResult(this, reportString);
        }

        public IActionResult Interaction()
        {
            var parameters = StiNetCoreViewer.GetInteractionParams(this);

            // You can change the parameter values, but cannot change the parameter names or delete them from collections.
            switch (parameters.Action)
            {
                case StiAction.Variables:
                    parameters.Variables["AllCountries"] = false;
                    parameters.Variables["SelectedCountry"] = "USA";
                    return StiNetCoreViewer.InteractionResult(this, parameters);

                case StiAction.Sorting:
                    break;

                case StiAction.Collapsing:
                    break;

                case StiAction.DrillDown:
                    break;
            }

            return StiNetCoreViewer.InteractionResult(this);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
