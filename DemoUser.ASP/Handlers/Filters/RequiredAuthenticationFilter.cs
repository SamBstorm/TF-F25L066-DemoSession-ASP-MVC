using DemoUser.ASP.Handlers.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace DemoUser.ASP.Handlers.Filters
{
    public class RequiredAuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISession session = context.HttpContext.Session;

            string? json = session.GetString("User") ;

            UserSession? user = JsonSerializer.Deserialize<UserSession?>(json ?? "null");
            if(user is null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(){
                        { "controller", "Auth" },
                        { "action", "Login" }
                    });

            }
        }
    }
}
