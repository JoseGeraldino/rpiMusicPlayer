using Microsoft.AspNetCore.Mvc;

namespace MusicPlayer.Controllers
{
    [Route("Home")]
    [Controller]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return Content("Hello World");
        }

    }
}
