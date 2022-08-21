using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework04.Models
{
    public class Cleaning : Volunteer
    {
        public string Description { get; set; }

        //constructor
        public Cleaning(string _description, string _Name, string _Surname, int? _Age, string _Phone, string type, User user, int id) : base(_Name, _Surname, _Age, _Phone,  type, user, id)
        {
            Description = _description;

        }  public Cleaning()
        {
            Description =" ";

        }
        public override int getDOB()
        {
            return ((int)(DateTime.Now.Year-Age));
        }
        public override string display()
        {
            return "Good day, check activities for things you need to do";
        }
    }
}