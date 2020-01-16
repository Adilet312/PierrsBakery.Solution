using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierrsBakery.Models;
using System.Collections.Generic;
using System;

namespace PierrsBakery.Tests
{
  [TestClass]
  public class VendorTest
  {

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newCategory = new Vendor();
      Assert.AreEqual(typeof(Vendor), newCategory.GetType());
    }
    [TestMethod]
    public void TestFullConstructor()
    {
        Vendor TestVC = new Vendor("School","Learning,Reading,Writing","2062901212","1212 NE 95th St");
        Assert.AreEqual("School",TestVC.getVendorName());
        Assert.AreEqual("Learning,Reading,Writing",TestVC.getVendorDescription());
        Assert.AreEqual("2062901212",TestVC.getPhoneNumber());
        Assert.AreEqual("1212 NE 95th St",TestVC.getVendorAddress());
        
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException),"Phone number is invalid format!")]
    public void InvalidPhoneFormat_CheckingForException()
    {
        Vendor TestVC = new Vendor("School","Learning,Reading,Writing","206290AAAA1212","1212 NE 95th St");
    
    }

    [TestMethod]
    public void testMutatorMethods()
    {
        Vendor TestVC = new Vendor("School","Learning,Reading,Writing","2062901212","1212 NE 95th St");
        TestVC.setVendorName("Sport");
        TestVC.setVendorDescription("It is running about 5 miles a day.");
        TestVC.setPhone("3000000000");
        TestVC.setVendorAddress("123 NE 98th ST ,Seattle");
        Assert.AreEqual("Sport",TestVC.getVendorName());
        Assert.AreEqual("It is running about 5 miles a day.",TestVC.getVendorDescription());
        Assert.AreEqual("3000000000",TestVC.getPhoneNumber());
        Assert.AreEqual("123 NE 98th ST ,Seattle",TestVC.getVendorAddress());
    
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException),"If Given Order object parameter is null then throws Argumentexception.")]
    public void GivenParameterObjectIsNull()
    {

        Vendor TestVC = new Vendor();
        Order newOrder = null;
        TestVC.addOrder(newOrder);

    }
    

  }
}