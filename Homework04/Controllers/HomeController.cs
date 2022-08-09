using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework04.Models;
using System.Web.Mvc;

namespace Homework04.Controllers
{ 
    public class HomeController : Controller
    {

        static List<User> users = new List<User>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult signUp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult signUp(string username, string password, string name, string surname, string skill, int age)
        {
            if (username == null && password == null && name == null && surname == null && skill == null && age == 0)
            {
                ViewBag.Incorrect = "Please input input all fields!!!";
                return View("signUp");
            }
           return View("login");
        }
        public ActionResult Login()
        {
            User user = new User();
            user.username = "siyanda@gmail.com";
            user.password = "123456";
            User user2 = new User();
            user2.username = "sihle@gmail.com";
            user2.password = "78910";
            User user1 = new User();
            user1.username = "spheshabs@gmail.com";
            user1.password = "111213"; 
            User user3 = new User();
            user3.username = "Nhlanhla.com";
            user3.password = "141516";

            users.Add(user);
            users.Add(user2);
            users.Add(user1);
            users.Add(user3);
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            foreach (var user in users)
            {
                if (user.username == username && password == user.password)
                {
                    return View("Index");
                }
               ViewBag.Incorrect = "Incorrect password/username login failed!!!";
            }

             
            return View("Login");
        }
    }
}