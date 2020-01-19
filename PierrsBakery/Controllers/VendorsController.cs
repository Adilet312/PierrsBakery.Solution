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
    [HttpGet("vendors/new")]
    public ActionResult New()
    {
        return View();
    }
    [HttpPost("/vendors")]
    public ActionResult Create(string givenVendorName, string givenVendorDescription,string givenVendorPhone,string givenVendorAddress)
    {
        Vendor new_vendor = new Vendor(givenVendorName,givenVendorDescription,givenVendorPhone,givenVendorAddress);
        return RedirectToAction("Index");

    }
    [HttpGet("/venodrs/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.findVendorById(id);
        List<Order> ordersOfVendor = selectedVendor.getAllOrders();
        model.Add("vendorKey",selectedVendor);
        model.Add("orderKey",ordersOfVendor);
        return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId,string givenOrderTitle,string givenOrderDescription)
    {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Vendor foundVendor = Vendor.findVendorById(vendorId);
        Order new_order = new Order(givenOrderTitle, givenOrderDescription);
        foundVendor.addOrder(new_order);
        List<Order> ordersUnderSpecificVendor = foundVendor.getAllOrders();
        model.Add("order_KEY",ordersUnderSpecificVendor);
        model.Add("vendor_KEY",foundVendor);
        return View("Show",model);


    }
    [HttpPost("/vendors/delete")]
     public ActionResult DeleteAll()
      {
       Vendor.deleteVendors();
        return View();
      }
      [HttpGet("/vendors/search")]
      public ActionResult Search(int givenID)
      {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Vendor foundVendor = Vendor.findVendorById(givenID);
        List<Order> categoryItems = foundVendor.getAllOrders();
        model.Add("order_key",categoryItems);
        model.Add("vendor_key",foundVendor);
        
        return View(model);
      }

  }
}