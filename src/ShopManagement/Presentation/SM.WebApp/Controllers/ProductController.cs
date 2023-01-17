﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Business.DataServices;
using SM.Business.Models;

namespace SM.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public ActionResult Index(string? search)
        {
            List<ProductModel> products = new List<ProductModel>();
            if(search == null)
            {
                products = _productService.GetAll();

            }
            else
            {
                products = _productService.GetAll().Where(x=>x.Name.ToLower()
                .Contains(search.Trim().ToLower())).ToList();
            }
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                _productService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                var product = _productService.GetAll().Where(x => x.Id == model.Id).FirstOrDefault();
                if (product != null) 
                {
                    product.Name = model.Name;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
