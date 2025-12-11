using DemoUser.ASP.Mapper;
using DemoUser.ASP.Models;
using DemoUser.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoUser.ASP.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.User> _service;
        private ILogger<AuthController> _logger;

        public AuthController(
            IUserRepository<BLL.Entities.User> service,
            ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Identification invalide...");
                Guid id = _service.CheckPassword(form.Email, form.Password);
                _logger.LogInformation($"Connection successfull : {id}");
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception)
            {
                return View();
            }
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
        public IActionResult Register(UserRegisterForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException("Le formulaire n'est pas correctement rempli.");
                }
                Guid id = _service.Insert(form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
                
            }
        }
    }
}
