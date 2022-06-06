
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Store.Web.Controllers
{
    public class MainController : BaseController
    {
        private readonly ILogger<MainController> _logger;
        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        public IActionResult UnAuthorize() => View();
        public IActionResult Index()
        {
            return View();
        }
       

       
        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
