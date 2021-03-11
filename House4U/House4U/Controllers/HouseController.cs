using House4U.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace House4U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        static private List<Houses> HouseList = new List<Houses>()
        {
            new Houses(){ID = 001, Address = "221b Baker Street", Bedrooms=2, Lease= LeaseType.Managed, ExpiryDate = DateTime.Today, Email= "sholmes@gmail.com"},
            new Houses(){ID = 002, Address = "Saint Martha House, 00120 Citta del Vaticano", Bedrooms=7, Lease= LeaseType.Managed, ExpiryDate = DateTime.Now, Email= "ilVaticano@gmail.com"},
            new Houses(){ID = 003, Address = "1600 Pennsylvania Ave., Washington, D.C.", Bedrooms=10, Lease= LeaseType.Managed, ExpiryDate = DateTime.Today, Email= "whouse123@gmail.com"},
            new Houses(){ID = 004, Address = "Prinsengracht 263-267, 1016 GV Amsterdam", Bedrooms=2, Lease= LeaseType.Delegated, ExpiryDate = DateTime.Today, Email= "afrank@gmail.com"},
            new Houses(){ID = 005, Address = "Aras an Uachtarain, Phoenix Park", Bedrooms=5, Lease= LeaseType.Managed, ExpiryDate = DateTime.Now, Email= "mdhiggs@gmail.com"}
        };


        // GET: api/<HouseController>
        //Return all property details
        [HttpGet]
        public IEnumerable<Houses> Get()
        {
            return HouseList;
        }

        // GET api/<HouseController>/5
        //Return property details based on ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Houses foundid = HouseList.FirstOrDefault(x => x.ID == id);
            if (foundid != null)
            {
                return Ok(foundid);
            }
            return NotFound("There is no property with that ID on record.");
        }

        // GET api/<HouseController>/email
        //Return all emails
        [HttpGet("email")]
        public IEnumerable<string> GetEmail(string email)
        {
            return HouseList.Select(x=>x.Email);
        }

        // POST api/<HouseController>
        //Add a new Property to the list
        [HttpPost]
        public IActionResult Post([FromBody] Houses value)
        {
            if (ModelState.IsValid)
            {
                if (HouseList.Count == 0)
                {
                    value.ID = 0;
                }
                {
                    value.ID = HouseList[HouseList.Count - 1].ID + 1;
                }

                HouseList.Add(value);
                return Ok("Property has been added to the porfolio.");
            }
            else
            {
                return BadRequest("Data is invalid. Property has not been added.");
            }
        }

        // PUT api/<HouseController>/5
        //Update bedroom number based on ID of Property
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int value)
        {
            Houses hu = HouseList.FirstOrDefault(h => h.ID == id);
            if (hu != null)
            {
                hu.Bedrooms = value;
            }
        }

        // DELETE api/<HouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
