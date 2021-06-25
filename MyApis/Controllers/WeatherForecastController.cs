using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyApis.Controllers
{
    [ApiController]
    [Route("[controller]")]     //uri pattern
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("/get/detail")]    //https://localhost:46545/get/detail
        public string GetDetailsAsString()
        {
            Person p = new Person();
            p.Aadhaar = "ABC230483209HF";
            p.Name = "Meena";
            p.Age = 16;

            return p.Name + " | " + p.Age + "|" + p.Aadhaar;
        }

        [HttpGet("/get/asperson")]  //https://localhost:46545/get/asperson
        public Person GetAsPerson()
        {
            Person p = new Person();
            p.Aadhaar = "ABC230483209HF";
            p.Name = "Meena";
            p.Age = 16;
            return p;
        }

        [HttpGet("/all")]       //https://localhost:46545/all
        public List<Person> GetAll()
        {
            Person obj = new Person();
            return obj.GetAll();
        }

        [HttpGet("/search/{name}")]    //https://localhost:46545/search/Meena
        public Person Search([FromRoute] string name)   //binders
        {
            Person obj = new Person();
            return obj.Find(name);
        }

        [HttpPost("/add")]              //https://localhost:44326/add
        public IActionResult AddPerson([FromBody] Person p)    //binder: FromBody takes it from the HttpRequest's Body
        {
            if (ModelState.IsValid)     //Please copy it :-)
            {
                Person obj = new Person();
                obj.Add(p);
                return Created("https://localhost:44326/add", p);
            }

            return BadRequest(); //Please copy it :-)

        }

        [HttpPut("/update/{name}")]
        public IActionResult UpdatePerson([FromRoute] string name, [FromForm] Person p)
        {
            if (ModelState.IsValid)
            {
                Person obj = new Person();
                obj.Update(name, p);
                return Ok("Person has been updated successfully");
            }
            return BadRequest();
           
        }
    }
}
