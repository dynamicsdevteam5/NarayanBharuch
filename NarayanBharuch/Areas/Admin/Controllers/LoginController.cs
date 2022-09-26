using System.Linq;
using System.Web.Mvc;
using NarayanBharuch.Areas.Admin.Models;
namespace NarayanBharuch.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        #region Login
        public ActionResult Login()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string hdnRememberMe)
        {
            var userId = CheckValidUser(username, password);
            if (userId > 0)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            ViewBag.ErrorMessage = "Please enter valid Username and Password. :(";
            return View("Login");
        }

        public int CheckValidUser(string username, string password)
        {
            var userId = 0;
            using(NarayanBharuchEntities _db = new NarayanBharuchEntities())
            {
                var userList = (from u in _db.UserMasters
                                where u.Username == username && u.Password == password
                                select new { u.Name, u.UserId, u.Username }).FirstOrDefault();

                if (userList != null)
                {
                    userId = userList.UserId;
                    Session["UserId"] = userList.UserId;
                    Session["UserName"] = userList.Username;
                    Session["Name"] = userList.Name;
                }
            }
            return userId;
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
        #endregion
    }
}