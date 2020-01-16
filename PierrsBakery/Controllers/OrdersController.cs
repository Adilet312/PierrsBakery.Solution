using Microsoft.AspNetCore.Mvc;
using PierrsBakery.Models;
using System.Collections.Generic;

namespace PierrsBakery.Controllers
{
    public class OrderController : Controller
    {
        /*Data or given id comes from form(browser)*/
        [HttpGet("/vendors/{categoryId}/orders/new")]
        public ActionResult New(int categoryId)
        {
            Vendor single_vendor = Vendor.findVendorById(categoryId);
            return View(single_vendor);
        }

        
        [HttpGet("/vendors/{categoryId}/orders/{orderId}")]
        public ActionResult Show(int categoryId, int orderId)
        {
            Order order = Order.findOrderById(orderId);
            Vendor vendor = Vendor.findVendorById(categoryId);
            Dictionary<string,object> model = new Dictionary<string, object>();
            model.Add("order",order);
            model.Add("vendor",vendor);
            return View(model);
        }

        // [HttpPost("/items/delete")]
        // public ActionResult DeleteAll()
        // {
        // Item.clearAllItems();
        // return View();
        // }
    }
}
