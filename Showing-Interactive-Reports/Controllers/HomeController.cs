using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace Showing_Interactive_Reports.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostEnvironment;

        public HomeController(IHostingEnvironment hostEnvironment)
        {
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

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

        public IActionResult GetReport(int? id)
        {
            switch (id)
            {
                // Dynamic sorting
                case 1: return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\DrillDownSorting.mrt");

                // Drill down
                case 2: return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\DrillDownListOfProducts.mrt");

                // Collapsing
                case 3: return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\DrillDownGroupWithCollapsing.mrt");

                // Bookmarks
                case 4: return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\MasterDetail.mrt");

                // Parameters
                case 5: return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\ParametersSelectingCountry.mrt");
            }

            return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\DrillDownSorting.mrt");
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
