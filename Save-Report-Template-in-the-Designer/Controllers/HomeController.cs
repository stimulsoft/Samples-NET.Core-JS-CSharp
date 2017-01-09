using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace Save_Report_Template_in_the_Designer.Controllers
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

        public IActionResult GetReport()
        {
            return StiNetCoreDesigner.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\SimpleList.mrt");
        }

        public IActionResult SaveReport()
        {
            string reportString = StiNetCoreDesigner.GetReportString(this);
            string reportName = StiNetCoreDesigner.GetReportName(this);

            try
            {
                System.IO.File.WriteAllText(_hostEnvironment.WebRootPath + "\\reports\\" + reportName + ".mrt", reportString);
                return StiNetCoreDesigner.SaveReportResult(this, true, "The report is saved successfully");
            }
            catch (Exception e)
            {
                return StiNetCoreDesigner.SaveReportResult(this, false, "Error at saving: " + e.Message);
            }
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}
