namespace DemoUser.ASP.Handlers.Sessions
{
    public class UserSession
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        public UserSession(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
