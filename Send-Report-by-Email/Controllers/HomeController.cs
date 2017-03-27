using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace Send_Report_by_Email.Controllers
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
            return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\SimpleList.mrt");
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult EmailReport()
        {
            StiEmailOptions options = StiNetCoreViewer.GetEmailOptions(this);

            options.AddressFrom = "admin@test.com";
            //options.AddressTo = "manager@test.com";
            //options.Subject = "Quarterly Report";
            //options.Body = "Quarterly report on arrival of the goods.";

            options.Host = "smtp.test.com";
            //options.Port = 465;
            options.UserName = "admin@test.com";
            options.Password = "************";

            return StiNetCoreViewer.EmailReportResult(this, options);
        }
    }
}
