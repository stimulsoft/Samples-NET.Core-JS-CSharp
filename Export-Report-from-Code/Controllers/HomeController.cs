using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;

namespace Export_Report_from_Code.Controllers
{
    public class HomeController : Controller
    {
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

        public async Task<IActionResult> ExportHtml([FromServices] INodeServices nodeServices)
        {
            string reportPath = "./Reports/SimpleList.mrt";
            string result = await nodeServices.InvokeAsync<string>("./node/exportHtml", reportPath);

            return Content(result, "text/html");
        }

        public async Task<IActionResult> ExportPdf([FromServices] INodeServices nodeServices)
        {
            string reportPath = "./Reports/SimpleList.mrt";
            byte[] result = await nodeServices.InvokeAsync<byte[]>("./node/exportPdf", reportPath);

            return File(result, "application/pdf");
        }
    }
}
