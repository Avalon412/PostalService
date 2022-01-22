using Microsoft.AspNetCore.Mvc;
using PostalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly string[] Names = { "Max", "Will", "Andrew", "Alex", "Mr. Anderson" };

        [HttpGet("id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetExistingPerson(int id)
        {
            var rnd = new Random();
            var persons = new PersonModel[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new PersonModel
                {
                    Id = i,
                    Name = Names[rnd.Next(Names.Length)]
                };
            }

            if (persons.Any(p => p.Id == id))
            {
                return Ok(persons[id]);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
