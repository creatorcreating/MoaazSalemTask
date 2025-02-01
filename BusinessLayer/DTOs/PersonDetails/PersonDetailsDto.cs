using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.PersonDetails
{
    public class PersonDetailsDto : Entity
    { 
        public string first_name { get; set; }
        public string last_name { get; set; } 
        public string telephone_code { get; set; }  
        public string telephone_number { get; set; }
        public string address { get; set; }
        public string country { get; set; }
    }
}
