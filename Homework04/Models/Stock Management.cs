using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework04.Models
{
    public class Stock_Management : Volunteer
    {

        public string Products{get;set;}
        public string Location { get; set; }


        // constructors 
        public Stock_Management(string _products,string _Location,string _Name, string _Surname, int ?_Age, string _Phone, string type, User user, int id) : base(_Name, _Surname, _Age, _Phone, type, user, id)
        {
            Products = _products;
            Location = _Location;
        }   
        public Stock_Management( )
        {
            Products =" ";
            Location = " ";
        }

        public override int getDOB()
        {
            return ((int)(DateTime.Now.Year - Age));
        }
        public override string display()
        {
            return "Good day, make sure you stay up to date with the stock within the system";
        }
    }

}