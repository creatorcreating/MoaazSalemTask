using BusinessLayer.DTOs.PersonDetails;
using BusinessLayer.Interfaces;
using BusinessLayer.Services.PersonService;
using Microsoft.AspNetCore.Mvc;

namespace MoaazSalemTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonDetailsController(IPersonDetailsService _personDetailsService) : ControllerBase
    {

        [HttpGet(Name = "GetPersonDetails")]
        public IActionResult GetPersonDetails(string? Name, string? TelephoneNumber)
        {
            try
            {
                var result = _personDetailsService.GetPersonDetails(Name, TelephoneNumber);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);  
            }
        }
    }
}
