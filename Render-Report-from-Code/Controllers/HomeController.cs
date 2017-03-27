using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace Render_Report_from_Code.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string message)
        {
            ViewData["Message"] = message ?? "The report is not rendered.";

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

        public async Task<IActionResult> RenderReport([FromServices] INodeServices nodeServices)
        {
            string fileName = "SimpleList";
            string reportPath = "./Reports/" + fileName + ".mrt";
            string result = await nodeServices.InvokeAsync<string>("./node/renderReport", reportPath);
            System.IO.File.WriteAllText("./Reports/" + fileName + ".mdc", result);

            return Redirect("/?message=The report successfully rendered and saved to the " + fileName + ".mdc file.");
        }
    }
}
