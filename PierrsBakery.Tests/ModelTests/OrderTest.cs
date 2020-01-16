using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierrsBakery.Models;
using System.Collections.Generic;
using System;

namespace PierrsBakery.Tests
{
  [TestClass]
  public class OrderTest
  {

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order();
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void TestFullConstructor()
    {
        DateTime date = new DateTime(2020,01,10);
        string dateTest = "January 10, 2020"; 
        Order TestOC = new Order("School","Learning,Reading,Writing",8400,date);
        Assert.AreEqual("School",TestOC.getTitle());
        Assert.AreEqual("Learning,Reading,Writing",TestOC.getDescription());
        Assert.AreEqual(8400,TestOC.getPrice());
        Assert.AreEqual(dateTest,TestOC.getDate());
        
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException),"if Price  is less then zero then it throws exception.")]
    public void InvalidPrice_CheckingForException()
    {
        Order orderTest = new Order();
        orderTest.setPrice(-111);
    }
    [TestMethod]
    public void testMutatorMethods()
    {
        DateTime date = new DateTime(2020,01,10);
        Order TestVC = new Order("Title-School","Learning,Reading,Writing",288.00,date);
        TestVC.setTitle("new Title");
        TestVC.setDescription("new description");
        TestVC.setPrice(2900);
        DateTime new_date = new DateTime(2000,02,20);
        TestVC.setDate(new_date);
        Assert.AreEqual("new Title",TestVC.getTitle());
        Assert.AreEqual("new description",TestVC.getDescription());
        Assert.AreEqual(2900,TestVC.getPrice());
        Assert.AreEqual(new_date.ToString("MMMM dd, yyyy"),TestVC.getDate());
    }
    
    

  }
}