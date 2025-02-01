using BusinessLayer.DTOs.PersonDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPersonDetailsService
    {
        string GetPersonDetails(string? Name, string? TelephoneNumber);
    }
}
