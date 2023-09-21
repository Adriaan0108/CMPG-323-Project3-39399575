using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Services;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _custService;
        private readonly IProductService _prodService;

        public OrdersController(IOrderService orderService, ICustomerService custService, IProductService prodService)
        {
            _orderService = orderService;
            _custService = custService;
            _prodService = prodService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            ViewData["CustomerId"] = new SelectList(_custService.GetAllCustomers(), "CustomerId");
            return View(_orderService.GetAllOrders().ToList());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _orderService.GetOrderById == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var cust = _custService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            _orderService.AddOrder(order);
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_custService.GetAllCustomers(), "CustomerId", "CustomerId");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            try
            {
                _orderService.UpdateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.OrderId))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _orderService.GetOrderById(id);
            _orderService.RemoveOrder(order);
            return RedirectToAction("Index");
        }

        private bool OrderExists(int id)
        {
            return _orderService.GetOrderById(id) != null;
        }
    }
}
