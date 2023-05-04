using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GuessThatPokemon.Controllers
{
    public abstract class BaseController : Controller
    {
        public String UserID
        {
            get
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    if (!HttpContext.Session.TryGetValue("UserID", out byte[]? data))
                    {
                        HttpContext.Session.SetString("UserID", string.Empty);
                    }
                    return HttpContext.Session.GetString("UserID") ?? string.Empty;
                }
                return string.Empty;
            }
            set
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    HttpContext.Session.SetString("UserID", value);
                }
                else
                {
                    if (HttpContext == null)
                    {
                        throw new NullReferenceException("HttpContext is null.");
                    }
                    else
                    {
                        throw new Exception("HttpContext is inaccessible.");
                    }
                }
            }
        }

        public bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserID);

        // Runs before each view
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // Sets a bool in the view bag if we're logged in or not
            ViewBag.IsLoggedIn = IsLoggedIn;
        }
    }
}
