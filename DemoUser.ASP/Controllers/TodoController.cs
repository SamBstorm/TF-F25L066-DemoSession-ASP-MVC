using DemoUser.ASP.Handlers.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace DemoUser.ASP.Controllers
{
    public class TodoController : Controller
    {
        private readonly SessionManager _session;

        public TodoController(SessionManager session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            IEnumerable<string> model = _session.TodoList;
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string todo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(todo)) throw new InvalidOperationException();
                todo = todo.Trim();
                _session.AjouterTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
