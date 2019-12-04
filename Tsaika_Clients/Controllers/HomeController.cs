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
        public ActionResult Index(string sortClient, string searchString)
        {
            ClientsContext db = new ClientsContext();
            ViewBag.roleid = getUserRole();//Добавить в каждый Action Result для админа

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortClient) ? "Name desc" : "";
            var clients = from s in db.Clients
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Eng_Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortClient)
            {
                case "Name desc":
                    clients = clients.OrderByDescending(s => s.Name);
                    break;
                default:
                    clients = clients.OrderBy(s => s.Name);
                    break;
            }

        
        ViewBag.client = db.Clients;
            return View(clients.ToList());




        }
       
        [Authorize(Roles="admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.client = db.Clients;
            return View(clients.ToList());
            
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Clients client)
        {
            db.Clients.Add(client);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}