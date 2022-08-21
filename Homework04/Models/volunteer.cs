using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Homework04.Models
{
    public abstract class Volunteer
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string type { get; set; }

        public User user { get; set; }

        public int dob { get; set; } = 0;

        public double donate { get; set; } = 0;
        // constructor
        public Volunteer(string _Name, string _Surname, int? _Age, string _Phone, string type, User user, int id)
        {
            Name = _Name;
            Surname = _Surname;
            Age = (int)_Age;
            Phone = _Phone;
            this.user = user;
            this.type = type;
            this.id = id;
        }
        //default constructor 
        public Volunteer()
        {
            Name = " ";
            Surname = " ";
            Age = 0;
            Phone = "";

        }
        public abstract int getDOB();


        public virtual double makeDonate(double amaount)
        {
            donate = donate + amaount;
            return donate;
        }
        public virtual string display()
        {
            return "";
        }





    }
}