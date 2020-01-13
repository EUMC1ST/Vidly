using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public Model _context;
        public CustomersController()
        {
            _context = new Model();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public Customer customer { get; set; }
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.ToList();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult GetCustomerDetails(int id)
        {
            return View("Details", _context.Customers.SingleOrDefault(c => c.Id == id));
            return View("Details", GetCustomers().SingleOrDefault(c => c.Id == id));
            //foreach (var customer in GetCustomers())
            //{
            //    if (customer.Id == id)
            //    {
            //        this.customer = customer;
            //    }
            //}
            //return View("Details", customer);
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