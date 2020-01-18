using System.Collections.Generic; 
using System;
using System.Text.RegularExpressions;

namespace PierrsBakery.Models
{
    public class Vendor
    {
        private string vendorName;
        private string vendorDescription;
        private string vendorPhoneNumber;
        private string vendorAddress;
        public int Id {get;}
        private static List<Vendor> vendorList = new List<Vendor>{};
        private  List<Order> vendorOrders;
        public Vendor()
        {}
        public  Vendor(string name, string description, string phone, string address)
        {
            this.vendorName = name;
            this.vendorDescription = description;
            setPhone(phone);
            this.vendorAddress = address;
            this.vendorOrders = new List<Order>{};
            vendorList.Add(this);
            Id = vendorList.Count;

        }
        public void setPhone(string given_phone)
        {
            if(!Regex.IsMatch(given_phone,"[0-9]{10}"))
            {
                throw new ArgumentException("Given phone number is not correct format!");

            }
            this.vendorPhoneNumber = given_phone;
        }
        public string getPhoneNumber()
        {
            return this.vendorPhoneNumber;
        }
        public void setVendorName(string name)
        {
            this.vendorName = name;
        }
        public string getVendorName()
        {
            return this.vendorName;
        }
        public void setVendorDescription(string description)
        {
            this.vendorDescription = description;
        }
        public string getVendorDescription()
        {
            return this.vendorDescription;
        }
        public void setVendorAddress(string given_address)
        {
            this.vendorAddress = given_address;
        }
        public string getVendorAddress()
        {
            return this.vendorAddress;
        }
        public  List<Order> getAllOrders()
        {
            return this.vendorOrders;
        }
        public void addOrder(Order given_order)
        {
            if(given_order==null)
            {
                throw new ArgumentException("Given order is empty!");
            }
            this.vendorOrders.Add(given_order);
        }
        /*Setting up static methods*/
        public static List<Vendor> getAllVendors()
        {
            return vendorList;
        }
        public static void deleteVendors()
        {
            vendorList.Clear();
        }
        public static Vendor findVendorById(int given_id)
        {
            if(given_id > vendorList.Count || given_id <=0)
            {
                return null;
            }
            return vendorList[given_id-1];
        }
        public string printPropertiesOfVendor()
        {
            string result = "Vendor Title: " + this.vendorName +
                            "Vendor Description: " + this.vendorDescription +
                            "Vendor Phone number: " + this.vendorPhoneNumber +
                            "Vendor Address: " + this.vendorAddress;
            return result;
        }



    }
}