using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            return View();
        }
    }
}

