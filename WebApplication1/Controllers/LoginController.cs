using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (loginEntities1 db = new loginEntities1())
                {
                    var sel = from d in db.users
                              where d.email == user && d.password == password
                              select d;
                    if (sel.Count() > 0)
                    {
                        users user1 = sel.First();
                        Session["User"] = user1;
                        return Content("1");
                    }
                    else
                    {
                        return Content("correo o contrasena incorrecta");
                    }
                }

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}