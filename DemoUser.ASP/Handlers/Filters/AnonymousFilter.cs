using DemoUser.ASP.Handlers.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoUser.ASP.Handlers.Filters
{
    public class AnonymousFilter : IAuthorizationFilter
    {
        private readonly SessionManager _session;

        public AnonymousFilter(SessionManager session)
        {
            _session = session;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_session.IsConnected)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
