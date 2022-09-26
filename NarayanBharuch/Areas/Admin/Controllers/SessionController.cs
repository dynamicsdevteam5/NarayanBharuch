using System.Web.Mvc;

namespace NarayanBharuch.Areas.Admin.Controllers
{
    public class SessionController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] != null)
            {
                ViewBag.UserId = Session["UserId"].ToString();                
                ViewBag.Name = Session["Name"].ToString();
                ViewBag.AppName = "Narayan Bharuch";
            }
            else
            {
                RedirectToAction("Login", "Login");
            }
        }
    }
}