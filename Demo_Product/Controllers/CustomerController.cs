using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDAL());

        public IActionResult Index()
        {
            var values = customerManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(c);
            if (results.IsValid)
            {
                customerManager.TInsert(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
           
        }
        public IActionResult DeleteCustomer(int Id)
        {
            var value = customerManager.TGetById(Id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int Id)
        {
            var value = customerManager.TGetById(Id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {
            customerManager.TUpdate(c);
            return RedirectToAction("Index");
        }
    }
}
