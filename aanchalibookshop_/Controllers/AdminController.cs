using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aanchalibookshop_;

namespace aanchalibookshop_.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(userdetail usr)
        {
            //get username password from the user)
            //check it with database user table

       aanchalbookshop_Entities1 dbObject = new aanchalbookshop_Entities1();
            var checkuser = dbObject.userdetails .Where(l => l.u_name.Equals(usr.u_name) && l.u_password.Equals(usr.u_password)).FirstOrDefault();
            if (checkuser != null)
            {
                var loggeduser = dbObject.userdetails.Where(l => l.u_name.Equals(usr.u_name)).FirstOrDefault();
                Session["u-name"] = loggeduser.u_name.ToString();
                Session["u-id"] = loggeduser.u_id.ToString();
                Session["u-type"] = loggeduser.u_type.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View();

        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
    
}