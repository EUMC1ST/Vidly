using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public Customer customer { get; set; }
        // GET: Customers
        public ActionResult Index()
        {

            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult GetCustomerDetails(int id)
        {
            foreach (var customer in GetCustomers())
            {
                if (customer.Id == id)
                {
                    this.customer = customer;
                }
            }
            return View("Details",customer);
        }
        public List<Customer> GetCustomers()
        {

            return new List<Customer>{
                new Customer{ Id = 1,Name="Edgar"},
                new Customer{ Id = 2,Name="Anahi"}
            };
        }
    }
}