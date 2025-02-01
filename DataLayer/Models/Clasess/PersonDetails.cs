using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Clasess
{
    public class Person_Details : Entity
    {
        [Name("id")]
        [Column("id")]
        public int Id { get; set; }
        [Name("name")]
        [Column("name")]
        public string Name { get; set; }
        [Name("telephone Number")]
        [Column("telephone Number")]
        public string Telephone_Number { get; set; }
        [Name("address")]
        [Column("address")]
        public string Address { get; set; }
        [Name("country")]
        [Column("country")]
        public string Country { get; set; }
        
 
    }
    public class CSVPersonDetails : Entity
    {
     
        
        [Name("First Name")] // CsvHelper attribute to map the CSV header
        //[Column("First Name")] // EF Core column mapping
        public string First_Name { get; set; }

        [Name("Last Name")]
        //[Column("Last Name")]
        public string Last_Name { get; set; }

        [Name("Country code")]
        //[Column("Country code")]
        public string Country_Code { get; set; }

        [Name("Number")]
        public string Number { get; set; }


        [Name("Full Address")]
        //[Column("Full Address")]
        public string Full_Address { get; set; }

    }
}
