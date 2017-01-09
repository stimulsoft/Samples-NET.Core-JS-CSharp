using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
