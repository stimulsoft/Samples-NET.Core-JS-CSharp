using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report.NetCore;

namespace Managing_Data_in_Reports.Controllers
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

        public IActionResult GetReportData()
        {
            StiRequestParams requestParams = StiNetCoreViewer.GetRequestParams(this);

            // JSON data
            if (requestParams.Connection.Type == StiConnectionType.JSON)
            {
                return StiNetCoreViewer.GetReportDataResult(this, _hostEnvironment.WebRootPath + "\\data\\Demo.json");
            }

            // XML data
            if (requestParams.Connection.Type == StiConnectionType.XML)
            {
                string pathData = requestParams.Connection.PathData;
                string pathSchema = requestParams.Connection.PathSchema;

                string data = pathSchema != null
                    ? System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "\\" + pathSchema)
                    : System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "\\" + pathData);

                return StiNetCoreViewer.GetReportDataResult(this, data);
                //return StiNetCoreViewer.GetReportDataResult(this, _hostEnvironment.WebRootPath + "\\" + pathData);
            }

            // SQL data
            if (requestParams.Connection.Type == StiConnectionType.MSSQL)
            {
                string connectionString = requestParams.Connection.ConnectionString;
                string queryString = requestParams.Connection.QueryString;

                StiDataResult result = new StiDataResult()
                {
                    Columns = new string[2] { "Column1", "Column2" },
                    Types = new string[2] { "number", "string" },
                    Rows = new string[3][] { new string[2] { "1", "Row1" }, new string[2] { "2", "Row2" }, new string[2] { "3", "Row3" } }
                };
                return StiNetCoreViewer.GetReportDataResult(this, result);
            }

            return StiNetCoreViewer.GetReportDataResult(this);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
