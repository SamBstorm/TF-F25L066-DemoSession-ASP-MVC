using System.Text.Json;

namespace DemoUser.ASP.Handlers.Sessions
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext!.Session;
        }

        public IEnumerable<string> TodoList
        {
            get {
                string? json = _session.GetString(nameof(TodoList));
                //return JsonSerializer.Deserialize<string[]>(json ?? "[]");
                return json is null ? new string[0] : JsonSerializer.Deserialize<string[]>(json)!;
            }
            private set {
                if (value is null) throw new ArgumentNullException(nameof(TodoList));
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(TodoList), json);
            }
        }

        public void AjouterTodo(string todo)
        {
            List<string> todoList = new List<string>(TodoList);
            todoList.Add(todo);
            TodoList = todoList;
            //OU
            //TodoList = [.. TodoList, todo];
        }

        public UserSession? User
        {
            get {
                string? json = _session.GetString(nameof(User));
                return JsonSerializer.Deserialize<UserSession?>(json ?? "null");
            }
            set {
                if (value is null) {
                    _session.Remove(nameof(User));
                    return; 
                }
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(User), json);
            }
        }

        public bool IsConnected
        {
            get => User is not null;
        }

        public void CleanUserSession()
        {
            _session.Clear();
        }
    }
}
