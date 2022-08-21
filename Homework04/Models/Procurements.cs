using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework04.Models
{
    public class Procurements: Volunteer
    {
        public string Items { get; set; }

        public string Transport { get; set;  }

        public double Amount { get; set; }

        // constructor 

        public Procurements(string _Items, string _Transport, double _Amount, string _Name, string _Surname, int? _Age, string _Phone, string type, User user, int id) : base(_Name, _Surname, _Age, _Phone,  type,  user, id)
        {
            Amount = _Amount;
            Transport = _Transport;
            Items = _Items;
        }
        public override int getDOB()
        {
            return ((int)(DateTime.Now.Year - Age));
        }

        // default constructor 
        public Procurements()
        {
            Amount = 0;
            Transport = " ";
            Items = " ";
        }
        public override string display()
        {
            return "Good day make your food donation today";
        }
    }
}