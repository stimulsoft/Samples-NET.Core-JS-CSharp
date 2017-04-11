using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;
using Stimulsoft.Report.NetCore.Export;

namespace Manage_Report_Exporting.Controllers
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

        public IActionResult GetReport()
        {
            return StiNetCoreViewer.GetReportResult(this, _hostEnvironment.WebRootPath + "\\reports\\SimpleList.mrt");
        }

        public IActionResult ExportReport()
        {
            StiExportSettings settings = StiNetCoreViewer.GetExportSettings(this);
            if (settings.GetExportFormat() == StiExportFormat.Html)
            {
                StiHtmlExportSettings settingsHtml = (StiHtmlExportSettings)settings;
                settingsHtml.ImageFormat = ImageFormat.Png;
                settingsHtml.UseEmbeddedImages = true;

                return StiNetCoreViewer.ExportReportResult(this, settingsHtml);
            }

            return StiNetCoreViewer.ExportReportResult(this);
        }

        public IActionResult ExportReportResponse()
        {
            StiRequestParams requestParams = StiNetCoreViewer.GetRequestParams(this);
            // byte[] data = requestParams.Data;
            // string fileName = requestParams.Export.FileName;
            // StiExportFormat format = requestParams.Export.Format;
            // bool openAfterExport = requestParams.Export.OpenAfterExport;

            return StiNetCoreViewer.ExportReportResponseResult(this);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
