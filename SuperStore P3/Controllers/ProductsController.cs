using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Services;

namespace Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _prodService;

        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewData["ProductId"] = new SelectList(_prodService.GetAllProducts(), "ProductId");
            return View(_prodService.GetAllProducts().ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _prodService.GetProductById == null)
            {
                return NotFound();
            }

            var product = _prodService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            _prodService.AddProduct(product);
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _prodService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(_prodService.GetAllProducts(), "ProductId");
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            try
            {
                _prodService.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _prodService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _prodService.GetProductById(id);
            _prodService.RemoveProduct(product);
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _prodService.GetProductById(id) != null;
        }
    }
}
