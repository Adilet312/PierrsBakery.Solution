
using System.Collections.Generic; 
using System;
namespace PierrsBakery.Models
{
    public class Order
    {
        public string orderTitle;
        private string orderDesciption;
        private double orderPrice;
        private DateTime orderDate;
        public int Id;
        private static  List<Order> listOfOrders = new List<Order>{};
        /*Default constructor without any parametrs.*/
        public Order(string title, string description)
        {
            this.orderTitle = title;
            this.orderDesciption = description;

        }
        /*Constructor with all parameters. */
        public Order(string title, string description, double price, DateTime date)
        {
            this.orderTitle = title;
            this.orderDesciption = description;
            setPrice(price);
            setDate(date);
            listOfOrders.Add(this);
            Id = listOfOrders.Count;
        }

        public void setPrice(double new_price)
        {
           if(new_price<0)
           {
               throw new ArgumentException("Invalid price is given!");
           }
           this.orderPrice = new_price;
        }
        public double getPrice()
        {
            return this.orderPrice;
        }
        public void setDate(DateTime new_date)
        {
            try
            {
                
                this.orderDate = new_date;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            
        }
        public string getDate()
        {
            return this.orderDate.ToString("MMMM dd, yyyy");
        }
        public void setTitle(string new_title)
        {
            this.orderTitle = new_title;
        }
        public string getTitle()
        {
            return this.orderTitle;
        }
        public void setDescription(string new_description)
        {
            this.orderDesciption = new_description;
        }
        public string getDescription()
        {
            return this.orderDesciption;
        }

        public string printPropertiesOfOrders()
        {
            string result = "Title: " + this.orderTitle + 
                            ",Description: " + this.orderDesciption +
                            ", Price: $" + this.orderPrice + 
                            ", Date: " + getDate();
            return result;
        }
        /* Static methods for List of orders*/
        public static List<Order> getAllOrders()
        {
            return listOfOrders;
        }
        public static Order findOrderById(int given_id)
        {
            if(given_id > listOfOrders.Count || given_id <=0)
            {
                return null;
            }
            return listOfOrders[given_id-1];
        }
        public static void deleteAllOrders()
        {
            listOfOrders.Clear();
        }

        

    }
}