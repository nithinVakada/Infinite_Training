using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10.Models;

namespace CC10.Controllers
{
    [RoutePrefix("api/cust")]
    public class CustController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("test")]
        public IHttpActionResult Test()
        {
            return Ok("API is working!");
        }


        // 1️⃣ Get all orders of employee with ID = 5
        [HttpGet]
        [Route("orders-by-employee")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.Customer.CompanyName,
                               o.OrderDate,
                               o.ShipCity,
                               o.ShipCountry
                           })
                           .ToList();

            return Ok(orders);
        }
        [HttpGet]
        [Route("customers-by-country/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();

            return Ok(customers);


        }
    }
}