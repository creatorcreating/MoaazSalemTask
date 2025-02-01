using DataLayer.Models.Clasess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastruture.RepositoryPattern;
using BusinessLayer.DTOs.PersonDetails;
using System.Net;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using CsvHelper;
using System.Globalization;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace BusinessLayer.Services.PersonService
{
    public class PersonDetailsService : IPersonDetailsService
    {
        private readonly string _resourcePath;


        private static readonly char[] NameSeparator = new[] { ' ' };
        private static readonly char[] TelephoneSeparator = new[] { '-' };
        private static readonly char[] AddressSeparator = new[] { ',' };
        private readonly IRepository<Person_Details> _personDetailsDBRepository;
        private readonly IRepository<CSVPersonDetails> _personDetailsCSVRepository;


        public PersonDetailsService(IRepository<Person_Details> personDetailsDBRepository, IRepository<CSVPersonDetails> personDetailsCSVRepository)
        {
            _personDetailsDBRepository = personDetailsDBRepository;
            _personDetailsCSVRepository = personDetailsCSVRepository;

            // Navigate to the solution directory and set the resource path
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var solutionDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));
            _resourcePath = Path.Combine(solutionDirectory, "DataLayer", "Resources", "CSV");
            //_resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataLayer", "Resources", "CSV");

        }

      

        public  string GetPersonDetails(string? Name, string? TelephoneNumber)
        {
           
            var CSVResult = GetCSVPersonDetails(Name, TelephoneNumber);
            var DBResult = GetDBPersonDetails(Name, TelephoneNumber);

            var Result = DBResult.Concat(CSVResult).ToList();







            // Convert each object to dictionary with updated keys
            var transformedList = Result
                .Select(p => p.GetType()
                    .GetProperties()
                    .ToDictionary(
                        prop => prop.Name.Replace("_", " "), // Replace _ with space
                        prop => prop.GetValue(p) ?? "" // Handle null values
                    )
                )
                .ToList();

            // Convert to JSON and print
            string jsonOutput = JsonConvert.SerializeObject(transformedList, Formatting.Indented);

            return jsonOutput;


        }



        public List<PersonDetailsDto> GetDBPersonDetails(string? Name, string? TelephoneNumber)
        {
            var DBQuery = _personDetailsDBRepository.Query();

            if (!string.IsNullOrEmpty(Name))
            {
                DBQuery = DBQuery.Where(d => d.Name.ToLower().Contains(Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(TelephoneNumber))
            {
                DBQuery = DBQuery.Where(d => d.Telephone_Number.Contains(TelephoneNumber));
            }
            List<PersonDetailsDto> DBResult = new List<PersonDetailsDto>();
            try
            {
                DBResult = DBQuery
            .Select(db => new PersonDetailsDto
            {
                first_name = db.Name.Split(NameSeparator, StringSplitOptions.None)[0],
                last_name = db.Name.Split(NameSeparator, StringSplitOptions.None)[1],
                telephone_code = db.Telephone_Number.Split(TelephoneSeparator, StringSplitOptions.None)[0],
                telephone_number = db.Telephone_Number.Split(TelephoneSeparator, StringSplitOptions.None)[1],
                address = db.Address,
                country = db.Country,
            })
            .ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

            return DBResult;
        }


        public List<PersonDetailsDto> GetCSVPersonDetails(string? Name, string? TelephoneNumber)
        {

            var csvPath = Path.Combine(_resourcePath, "Technical Task Data As CSV.csv");

            if (!File.Exists(csvPath))
            {
                return new List<PersonDetailsDto>(); // Return empty if file not found
            }

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var CSVResult = csv.GetRecords<CSVPersonDetails>()
                .Where(d => (string.IsNullOrEmpty(Name) 
                        || d.First_Name.ToLower().Contains(Name.ToLower())
                        || d.Last_Name.ToLower().Contains(Name.ToLower()))
                        && (string.IsNullOrEmpty(TelephoneNumber) || d.Number.Contains(TelephoneNumber)))
                .Select(csv => new PersonDetailsDto
                {
                    first_name = csv.First_Name ,
                    last_name = csv.Last_Name ,
                    telephone_code = csv.Country_Code,
                    telephone_number = csv.Number,
                    address = csv.Full_Address.Split(AddressSeparator, StringSplitOptions.None)[0],
                    country = csv.Full_Address.Split(AddressSeparator, StringSplitOptions.None)[1].Trim(),
                })
                .ToList(); // Read and filter in one step

            return CSVResult;
        }

    }
}
