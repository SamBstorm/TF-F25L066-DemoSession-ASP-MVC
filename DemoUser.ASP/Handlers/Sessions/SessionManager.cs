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
