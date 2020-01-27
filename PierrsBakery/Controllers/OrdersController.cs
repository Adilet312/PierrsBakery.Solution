using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierrsBakery.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace PierrsBakery.Controllers
{
  public class OrdersController : Controller
  {
    private readonly VendorOrderContext _dataBase;
    public OrdersController(VendorOrderContext database)
    {
      _dataBase = database;
    }
    [HttpGet]
    public ActionResult Index()
    {
        List<Order> orders = _dataBase.Orders.Include(rows => rows.Vendor).ToList();
        return View(orders);
    }
    [HttpGet]
    public ActionResult New()
    {
        ViewBag.VendorId = new SelectList(_dataBase.Vendors,"VendorId","VendorName");
        return View();
    }
    [HttpPost]
    public ActionResult New( Order new_order)
    {
        _dataBase.Orders.Add(new_order);
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Show(int readID)
    {
        Order foundOrder = _dataBase.Orders.FirstOrDefault(rows => rows.OrderId==readID);
        return View(foundOrder);
    }
    [HttpGet]
    public ActionResult Delete(int deleteID)
    {
        Order foundOrder = _dataBase.Orders.FirstOrDefault(rows => rows.OrderId==deleteID);
        return View(foundOrder);
    }
    [HttpPost,ActionName("Delete")]
    public ActionResult DeleteConfirmed(int deleteID)
    {
        Order foundOrder = _dataBase.Orders.FirstOrDefault(rows => rows.OrderId==deleteID);
        _dataBase.Remove(foundOrder);
        _dataBase.SaveChanges();
        return View("ConfirmedPage");
    }
    [HttpGet]
    public ActionResult Update(int updateID)
    {
        Order foundOrder = _dataBase.Orders.FirstOrDefault(rows => rows.OrderId==updateID);
        return View(foundOrder);
    }
    [HttpPost]
    public ActionResult Update(Order new_order)
    {
        _dataBase.Entry(new_order).State = EntityState.Modified;
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
    }


    
 }
}