using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service;
using Logger;

namespace GuessThatPokemon.Controllers
{
    public abstract class BaseController : Controller
    {
        public APICaller api = APICaller.Instance();
        protected DBLogger DBLogger = DBLogger.Instance();

        public string UserID
        {
            get
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
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

            // Sets a bool in the view bag if logged in or not
            ViewBag.IsLoggedIn = IsLoggedIn;
        }
    }
}
