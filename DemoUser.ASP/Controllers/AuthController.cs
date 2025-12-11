using DemoUser.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoUser.ASP.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.User> _service;

        public AuthController(IUserRepository<BLL.Entities.User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(FormCollection form)
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logout(FormCollection form)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(FormCollection form)
        {
            return View();
        }
    }
}
