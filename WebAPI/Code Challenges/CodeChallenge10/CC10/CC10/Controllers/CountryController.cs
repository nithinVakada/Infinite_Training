using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10.Models;

namespace CC10.Controllers
{
    public class CountryController : ApiController
    {
        //    // GET api/<controller>
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<controller>/5
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<controller>
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<controller>/5
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<controller>/5
        //    public void Delete(int id)
        //    {
        //    }

        static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "Pakistan", Capital = "Islamabad" },
            new Country { ID = 3, CountryName = "Sri Lanka", Capital = "Combo" },
            new Country { ID = 4, CountryName = "Russia", Capital = "Moscow" }
        };

        
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // POST: api/country
        [HttpPost]
        public IEnumerable<Country> Create(Country country)
        {
            country.ID = countries.Any() ? countries.Max(c => c.ID) + 1 : 1;

            countries.Add(country);

            return countries;
        }

        // PUT: api/country/5
        [HttpPut]
        public IHttpActionResult Update(int id, Country updated)
        {
            var existing = countries.FirstOrDefault(c => c.ID == id);
            

            existing.CountryName = updated.CountryName;
            existing.Capital = updated.Capital;

            return Ok(existing);
        }

        // DELETE: api/country/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok();
        }
    }
}