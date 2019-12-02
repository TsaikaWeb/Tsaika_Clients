using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tsaika_Clients.Models;

namespace Tsaika_Clients.Controllers
{
    public class HomeController : Controller
    {
        UserContext dbU = new UserContext();
        ClientsContext db = new ClientsContext();
        public int getUserId()
        {
            int userId = 0;
            foreach (var u in dbU.Users)
            {
                if (u.Email == User.Identity.Name)
                {
                    userId = u.Id;
                    break;
                }
            }
            return userId;
        }
        public int getUserRole()
        {
            int roleid = 0;
            foreach (var u in dbU.Users)
            {
                if (u.Email == User.Identity.Name)
                {
                    roleid = u.RoleId;
                    break;
                }
            }
            return roleid;
        }
        public ActionResult Index(string filterbyname = "", string[] checkbox_check = null)
        {
            ClientsContext db = new ClientsContext();
            ViewBag.roleid = getUserRole();//Добавить в каждый Action Result для админа

            ViewBag.names = db.Clients.OrderByDescending(x => x.Name);

            ViewBag.Title = "Home Page";


            string filter = filterbyname;
            if (filter == "DESC")
            {
                ViewBag.asc = "";
                ViewBag.desc = "selected";
            }

            if (filter == "ASC")
            {
                ViewBag.asc = "selected";
                ViewBag.desc = "";
            }

            List<string> letters = new List<string>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                letters.Add(Convert.ToString(letter));
            }

            ViewBag.Letters = letters;
            ViewBag.Letters_Count = letters.Count;
            ViewBag.Checkbox = new string[letters.Count];
            if (checkbox_check == null)
            {
                checkbox_check = ViewBag.Letters.ToArray();
            }
            for (int i = 0; i < letters.Count; i++)
            {
                if (checkbox_check.Contains(letters[i]))
                    ViewBag.Checkbox[i] = "checked";

            }
            List<Clients> selected = new List<Clients>();

            for (int i = 0; i < checkbox_check.Length; i++)
            {
                if (filter == "ASC")
                    selected.AddRange(db.Clients.ToList().Where(x => x.Name[0].ToString() == checkbox_check[i]).OrderBy(x => x.Name));
                else if (filter == "DESC")
                    selected.AddRange(db.Clients.ToList().Where(x => x.Name[0].ToString() == checkbox_check[i]).OrderByDescending(x => x.Name));
                else
                    selected.AddRange(db.Clients.ToList().Where(x => x.Name[0].ToString() == checkbox_check[i]).OrderBy(x => x.Name));


            }
            if (filter == "DESC")
            {
                selected.Reverse();
            }
            ViewBag.names = selected;
            ViewBag.client = db.Clients;
            List<Clients> selected1 = new List<Clients>();
            return View();


        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize(Roles="admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Admin()
        {
            ClientsContext db = new ClientsContext();
            ViewBag.roleid = getUserRole();//Добавить в каждый Action Result для админа

            ViewBag.client = db.Clients;
            List<Clients> selected1 = new List<Clients>();
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }
    }
}