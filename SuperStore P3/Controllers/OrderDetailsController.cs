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
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService _orderService;

        public OrderDetailsController(IOrderDetailsService orderService)
        {
            _orderService = orderService;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            ViewData["OrderDetailsID"] = new SelectList(_orderService.GetAllOrderDetail(), "OrderDetailsID");
            return View(_orderService.GetAllOrderDetail().ToList());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _orderService.GetOrderDetailById == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderDetailById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderDetailsID"] = new SelectList(_orderService.GetAllOrderDetail(), "OrderDetailsID", "OrderDetailsID");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            _orderService.AddOrderDetail(orderDetail);
            return RedirectToAction("Index");
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderDetailById(id);

            if (order == null)
            {
                return NotFound();
            }

            ViewData["OrderDetailsID"] = new SelectList(_orderService.GetAllOrderDetail(), "OrderDetailsID", "OrderDetailsID");
            return View(order);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderId)
            {
                return NotFound();
            }

            try
            {
                _orderService.UpdateOrderDetail(orderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(orderDetail.OrderId))
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

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderDetailById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _orderService.GetOrderDetailById(id);
            _orderService.RemoveOrderDetail(order);
            return RedirectToAction("Index");
        }

        private bool OrderDetailExists(int id)
        {
            return _orderService.GetOrderDetailById(id) != null;
        }
    }
}
