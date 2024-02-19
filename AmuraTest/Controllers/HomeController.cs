using AmuraTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmuraTest.Models;
using AmuraTest.Repositories;
using AmuraTest.Services;

namespace AmuraTest.Controllers
{
    public class HomeController : Controller
    {
        ServiceApi api;
        ProductRepo repo;

        public HomeController(ServiceApi Api, ProductRepo Repo)
        {
            this.api = Api;
            this.repo = Repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> productList = await this.api.GetProductsAsync();
            ViewBag.Products = productList;
            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string TitleSelected)
        {
            List<Product> products = await this.api.GetProducts(TitleSelected);
            List<Product> productList = await this.api.GetProductsAsync();
            ViewBag.Products = productList;
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
