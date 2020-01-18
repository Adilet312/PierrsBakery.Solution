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
    public ActionResult CreateVendor(string givenVendorName, string givenVendorDescription,string givenVendorPhone,string givenVendorAddress)
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
        model.Add("vendor",selectedVendor);
        model.Add("orders",ordersOfVendor);
        return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult CreateOrdersUnderVendor(int vendorId,string givenOrderTitle,string givenOrderDescription)
    {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Vendor foundVendor = Vendor.findVendorById(vendorId);
        Order new_order = new Order(givenOrderTitle, givenOrderDescription);
        foundVendor.addOrder(new_order);
        List<Order> ordersUnderSpecificVendor = foundVendor.getAllOrders();
        model.Add("orders",ordersUnderSpecificVendor);
        model.Add("vendor",foundVendor);
        return View("Show",model);


    }
    [HttpPost("/vendors/delete")]
     public ActionResult DeleteAll()
      {
       Vendor.deleteVendors();
        return View();
      }

  }
}