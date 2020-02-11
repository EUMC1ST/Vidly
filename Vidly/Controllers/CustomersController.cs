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
        public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer =_context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.AsEnumerable()
            };

            return View("CustomerForm",viewModel);
        }

        //CREATE POST METHOD
        //Attribute
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            //Validation Data En
            if (!ModelState.IsValid)
            {
                    var viewModel = new ViewModels.NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.AsEnumerable()
                };
                return View("CustomerForm", viewModel);
                
                //Enviarlo a CustomerForm para que lo edite y sea valido
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.BirthDay = customer.BirthDay;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        //CREATE FORM
        [HttpGet]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        //[HttpPost]
        //public ActionResult New(Customer customer)
        //{
        //    return View();
        //}


        public ActionResult GetCustomerDetails(int id)
        {
            var customerDetails = _context.Customers.SingleOrDefault(c => c.Id == id);
            return View("Details", customerDetails);
            //return View("Details", GetCustomers().SingleOrDefault(c => c.Id == id));
            //foreach (var customer in GetCustomers())
            //{
            //    if (customer.Id == id)
            //    {
            //        this.customer = customer;
            //    }
            //}
            //return View("Details", customer);
        }
    }
}