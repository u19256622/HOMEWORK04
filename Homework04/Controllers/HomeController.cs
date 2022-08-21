using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework04.Models;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Homework04.Controllers
{ 
    public class HomeController : Controller
    {
        public static List<Volunteer> volunteerList = new List<Volunteer>();
        static public Volunteer CurrentVoluneer;
        public ActionResult Index()
        {
            try
            {
                
                ViewBag.name = CurrentVoluneer.Name;
                ViewBag.surname = CurrentVoluneer.Surname;
                ViewBag.type = CurrentVoluneer.type;
            }
            catch { }
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }
        // activities 
        public ActionResult Activities()
        {
            

            return View();
        }
        // class structure diagram 
        public ActionResult Class()
        {
            

            return View();
        }
        public ActionResult Volunteer()
        {
           List<Volunteer> list = new List<Volunteer>();
            foreach(var item in volunteerList)
            {
                item.dob = item.getDOB();
                list.Add(item);
            }
            

            return View(list);
        }
        public ActionResult Narrative()
        {
            

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
      
        public ActionResult Donate()
        {
           

            return View(volunteerList);
        }
        [HttpPost]
        public ActionResult Donate(double amount)
        {
            //CurrentVoluneer.donate = CurrentVoluneer.donate + amount;
            volunteerList.FirstOrDefault(x => x.id == CurrentVoluneer.id).donate = amount + volunteerList.FirstOrDefault(x => x.id == CurrentVoluneer.id).donate;

            return View(volunteerList);
        }
        public ActionResult signUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult signUp(string username, string phone, string password, string name, string surname, string skill, int age)
        {
            Random random = new Random();
            if (username == null && password == null && name == null && surname == null && skill == null && age >= 16)
            {
                ViewBag.Incorrect = "Please input input all fields!!!";
                return View("signUp");
            }
            else
            {
                if(skill == "Buying")
                {
                   
                    CurrentVoluneer = new Procurements();
                    CurrentVoluneer.user = new User(username, password);
                    CurrentVoluneer.Name = name;
                    CurrentVoluneer.Surname = surname;
                    CurrentVoluneer.type = skill;
                    CurrentVoluneer.Age = age;
                    CurrentVoluneer.Phone = phone;
                    return RedirectToAction("RegPrec");
                }
                if (skill == "Cooking")
                {
                  
                    CurrentVoluneer = new Catering();
                    CurrentVoluneer.user = new User(username, password);             
                    CurrentVoluneer.Name = name;
                    CurrentVoluneer.Surname = surname;
                    CurrentVoluneer.type = skill;
                    CurrentVoluneer.Age = age;
                    CurrentVoluneer.Phone = phone;
                    return RedirectToAction("RegCatering");
                }
                if (skill == "Cleaning")
                {
                    //CurrentVoluneer.id = random.Next(0, 10000);
                    CurrentVoluneer = new Cleaning();
                    CurrentVoluneer.user = new User(username, password);
                    CurrentVoluneer.Name = name;
                    CurrentVoluneer.Surname = surname;
                    CurrentVoluneer.type = skill;
                    CurrentVoluneer.Age = age;
                    CurrentVoluneer.Phone = phone;
                    return RedirectToAction("RegCleaner");
                }
                if (skill == "Stock")
                {
                  
                    CurrentVoluneer = new Stock_Management();
                    CurrentVoluneer.user = new User(username, password);
                    CurrentVoluneer.Name = name;
                    CurrentVoluneer.Surname = surname;
                    CurrentVoluneer.type = skill;
                    CurrentVoluneer.Age = age;
                    CurrentVoluneer.Phone = phone;
                    return RedirectToAction("RegStock");
                }
                
            }
           return View("login");
        }
        
        public ActionResult RegCleaner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegCleaner(Cleaning item)
        {
            //  CurrentVoluneer
            Random random = new Random();
            Volunteer newV = new Cleaning(item.Description, CurrentVoluneer.Name, CurrentVoluneer.Surname, CurrentVoluneer.Age, CurrentVoluneer.Phone, CurrentVoluneer.type,CurrentVoluneer.user,random.Next(1,100));
            volunteerList.Add(newV);
            return View("Login");
        }
        public ActionResult RegCatering()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegCatering(Catering item)
        {
            Random random = new Random();
            Volunteer newV = new Catering(item.Location,item.Description,item.NumberOfKids, CurrentVoluneer.Name, CurrentVoluneer.Surname, CurrentVoluneer.Age, CurrentVoluneer.Phone, CurrentVoluneer.type, CurrentVoluneer.user, random.Next(1, 100));
            volunteerList.Add(newV);
            return View("Login");

        }
        public ActionResult RegStock()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegStock(Stock_Management item)
        {
            Random random = new Random();
            Volunteer newV = new Stock_Management(item.Products, item.Location, CurrentVoluneer.Name, CurrentVoluneer.Surname, CurrentVoluneer.Age, CurrentVoluneer.Phone, CurrentVoluneer.type, CurrentVoluneer.user, random.Next(1, 100));
            volunteerList.Add(newV);
            return View("Login");
        }

        public ActionResult RegPrec()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegPrec(Procurements item)
        {
            Random random = new Random();
            Volunteer newV = new Procurements(item.Items, item.Transport,item.Amount, CurrentVoluneer.Name, CurrentVoluneer.Surname, CurrentVoluneer.Age, CurrentVoluneer.Phone, CurrentVoluneer.type, CurrentVoluneer.user, random.Next(1, 100));
            volunteerList.Add(newV);
            return View("Login");
        }
        public static int ids = 0;
        // GET: Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = volunteerList.FirstOrDefault(x=>x.id==id);

            CurrentVoluneer = volunteer;
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Surname,Age,Phone,type")] Cleaning volunteer)
        {
            if (ModelState.IsValid)
            {
               foreach(var item in volunteerList)
                {
                    if(volunteer.id==item.id)
                    {
                        item.Age = volunteer.Age;
                        item.Phone = volunteer.Phone;
                        item.Name = volunteer.Name;
                        item.Surname = volunteer.Surname;
                    }
                }
               
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = volunteerList.FirstOrDefault(x=>x.id==id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = volunteerList.FirstOrDefault(x => x.id == id);
            volunteerList.Remove(volunteer);
          
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            foreach (var volunteer in volunteerList)
            {
                if (volunteer.user.username == username && password == volunteer.user.password)
                {
                    CurrentVoluneer = volunteer;
                    ViewBag.name = CurrentVoluneer.Name;
                    ViewBag.surname = CurrentVoluneer.Surname;
                    ViewBag.type = CurrentVoluneer.type;
                    ViewBag.display = CurrentVoluneer.display();
                    return View("Index");
                }
               ViewBag.Incorrect = "Incorrect password/username login failed!!!";
            }

             
            return View("Login");
        }
    }
}