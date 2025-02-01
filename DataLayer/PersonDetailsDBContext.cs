using CsvHelper;
using DataLayer.Models.Clasess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PersonDetailsDBContext : DbContext
    {
             private readonly string _resourcePath;

        public PersonDetailsDBContext(DbContextOptions<PersonDetailsDBContext> options, IConfiguration configuration)  : base(options)
        {
            _resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataLayer", "Resources", "CSV");
        }


        public DbSet<Person_Details> Person_Details { get; set; }




    }
}
