﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {

        ProductManager productManager = new ProductManager(new EfProductDAL());

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = productManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
                 
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.TGetById(id);

            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            
            productManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}

