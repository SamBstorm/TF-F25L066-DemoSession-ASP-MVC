using DemoUser.ASP.Handlers;
using DemoUser.ASP.Handlers.Filters;
using DemoUser.ASP.Handlers.Sessions;
using DemoUser.ASP.Models;
using DemoUser.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoUser.ASP.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.User> _service;
        private ILogger<AuthController> _logger;
        private SessionManager _session;

        public AuthController(
            IUserRepository<BLL.Entities.User> service,
            SessionManager session,
            ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
            _session = session;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [Route("/Login")]
        [TypeFilter<AnonymousFilter>]
        public IActionResult Login()
        {
            return View();
        }
        [Route("/Login")]
        [HttpPost]
        [TypeFilter<AnonymousFilter>]
        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Identification invalide...");
                Guid id = _service.CheckPassword(form.Email, form.Password);
                _session.User = new UserSession(id, form.Email);
                _logger.LogInformation($"Connection successfull : {id}");
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception)
            {
                return View();
            }
        }
        [Route("/Logout")]
        [TypeFilter<RequiredAuthenticationFilter>]
        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        [Route("/Logout")]
        [TypeFilter<RequiredAuthenticationFilter>]
        public IActionResult Logout(IFormCollection form)
        {
            _session.CleanUserSession();
            return RedirectToAction(nameof(Index));
        }
        [Route("/Register")]
        [TypeFilter<AnonymousFilter>]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("/Register")]
        [TypeFilter<AnonymousFilter>]
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
