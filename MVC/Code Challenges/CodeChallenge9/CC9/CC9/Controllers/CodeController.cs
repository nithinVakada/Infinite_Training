using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using CC9.Models;

namespace CC9.Controllers
{
    public class CodeController : Controller
    {

         NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();

            return View(customers);
        }

        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            return View(customer);
        }


    }
}