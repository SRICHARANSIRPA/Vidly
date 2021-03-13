using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private MyDBContext _Context;
        private List<Customer> customers;

        public CustomerController()
        {
            _Context = new MyDBContext();
            customers = _Context.Customers.Include(c => c.MembershipType).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);
            return HttpNotFound();
        }

        public ActionResult New()
        {
            var membershiptypes = _Context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm",ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _Context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }



        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel)
        {
            var membershipType = _Context.MembershipTypes.Single(x => x.Id == viewModel.MembershipTypeId);
            Customer customer = new Customer
            {
                Name = viewModel.Customer.Name,
                IsSubscribeToNewsLetter = viewModel.Customer.IsSubscribeToNewsLetter,
                MembershipType = membershipType,
                BirthDate = viewModel.Customer.BirthDate,
            };
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
    }
}