using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using PierrsBakery.Models;

namespace PierrsBakery.Controllers
{
  public class VendorsController : Controller
  {
    private readonly VendorOrderContext _dataBase;
    public VendorsController(VendorOrderContext database)
    {
      _dataBase = database;
    }
    [HttpGet]
    public ActionResult Index()
    {
      List<Vendor> vendors = _dataBase.Vendors.ToList();
      return View(vendors);
    }
    /*New functions that  one of them  for filling the form  and second one for creating object and redirecting to Index */
    [HttpGet]
    public ActionResult New()
    {
      return View();
    }
   
     [HttpPost]
     public ActionResult New(Vendor new_vendor)
    {
        _dataBase.Vendors.Add(new_vendor);
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Show(int readID)
    {
      Vendor vendor = _dataBase.Vendors.FirstOrDefault(rows => rows.VendorId==readID);
      vendor.Orders = _dataBase.Orders.Where(rows => rows.VendorId==readID).ToList();
      return View(vendor);

    }
   [HttpGet]
    public ActionResult Update(int updateID)
    {
      Vendor findVendor = _dataBase.Vendors.FirstOrDefault(vendors => vendors.VendorId==updateID);
      return View(findVendor);
    }
    [HttpPost]
    public ActionResult Update(Vendor new_vendor)
    {
        _dataBase.Entry(new_vendor).State = EntityState.Modified;
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Delete(int deleteID)
    {
      Vendor foundVendor = _dataBase.Vendors.FirstOrDefault(vendors => vendors.VendorId==deleteID);
      return View(foundVendor);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int deleteID)
    {
      Vendor foundVendor = _dataBase.Vendors.FirstOrDefault(vendors => vendors.VendorId==deleteID);
      _dataBase.Remove(foundVendor);
      _dataBase.SaveChanges();
      return View("ConfirmedPage");
    }
    [HttpGet]
    public ActionResult Search()
    {
      return View();
    }
    [HttpPost("/vendors/search")]
    public ActionResult Search(string givenName)
    {
      List<Vendor> foundVendor = _dataBase.Vendors.Where(vendors => vendors.VendorName==givenName).ToList();
      return View("ShowFound",foundVendor);

    }
    


  }
}
