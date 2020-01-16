using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using PierrsBakery.Models;

namespace PierrsBakery.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> allVendors = Vendor.getAllVendors();
            return View(allVendors);
        }
        /*After listing all Vendors in Index.cshtml file (View/Vendors/Index.cshtml) we have link there that directs  to New.cshtml file to create Vendor again.*/
        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }
        /*First data comes from the form that is in New.cshtml file*/
        [HttpPost("/vendors")]
        public ActionResult Create(string givenVendorName, string givenVendorDescription, string givenVendorPhone, string givenVendorAddress)
        {
            Vendor vendorObject = new Vendor(givenVendorName, givenVendorDescription, givenVendorPhone, givenVendorAddress);
            return RedirectToAction("Index");
        }
        /*After creating and redirecting vendor Object to Index page, we create Index Route below here to send A list of vendors.*/
      
        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();

            Vendor selectedVendor = Vendor.findVendorById(id);
            List<Order> vendorOrders = selectedVendor.getAllOrders();
            model.Add("vendor", selectedVendor);
            model.Add("orders", vendorOrders);
            return View(model);
        }
        [HttpPost("/vendors/{categoryId}/orders")]
        public ActionResult Create(int categoryId, string givenOrderTitle, string givenOrderDescription, double givenOrderPrice, DateTime givenOrderDate)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.findVendorById(categoryId);
            Order neworder = new Order(givenOrderTitle, givenOrderDescription, givenOrderPrice, givenOrderDate);
            foundVendor.addOrder(neworder);
            List<Order> vendorOrders = foundVendor.getAllOrders();
            model.Add("orders", vendorOrders);
            model.Add("vendor", foundVendor);
            return View("Show", model);
        }
        [HttpPost("/vendors/delete")]
        public ActionResult DeleteAll()
        {
            Vendor.deleteVendors();
                return View();
        }

    }

}