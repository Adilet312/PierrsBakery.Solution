using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PierrsBakery.Models;

namespace  PierrsBakery.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
        public ActionResult Show(int vendorId, int orderId)
        {
            Order order = Order.findOrderById(orderId);
            Vendor vendor = Vendor.findVendorById(vendorId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("order", order);
            model.Add("vendor", vendor);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
           Vendor vendor = Vendor.findVendorById(vendorId);

            return View(vendor);
        }
        [HttpPost("/orders/delete")]
        public ActionResult DeleteAll()
        {
            Order.deleteAllOrders();
            return View();
        }
    }
}