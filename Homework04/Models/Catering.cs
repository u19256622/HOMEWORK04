using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework04.Models
{
    public class Catering: Volunteer
    {
       public string Location { get; set; }
        public String Description { get; set; }
        public int NumberOfKids { set; get; }
       
        // constructors 
        public Catering(string _Location,string _Description, int _NumberOfKids, string _Name, string _Surname, int? _Age, string _Phone, string type, User user, int id) : base(_Name, _Surname, _Age, _Phone,  type, user, id)
        {
            Location = _Location;
            Description = _Description;
            NumberOfKids = _NumberOfKids;
        } 
        //default constructors 
        public Catering():base()
        {
            Location =" ";
            Description =" ";
            NumberOfKids =0;
        }
        public override int getDOB()
        {
            return ((int)(DateTime.Now.Year - Age));
        }
        public override string display()
        {
            return "Good day this is what the Catering team is up to";
        }
    }
}