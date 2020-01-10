
using System.Collections.Generic; 
using System;
namespace PierrsBakery.Models
{
    public class Order
    {
        private string title;
        private string desciption;
        private double price;
        private DateTime date;
        public int OrderID;
        private static  List<Order> listOfOrders = new List<Order>{};
        /*Default constructor without any parametrs.*/
        public Order()
        {

        }
        /*Constructor with all parameters. */
        public Order(string title, string description, double price, DateTime date)
        {
            this.title = title;
            this.desciption = desciption;
            this.price = setPrice(price);
            this.date = setDate(date);
            listOfOrders.Add(this);
            OrderID = listOfOrders.Count;
        }

        public void setPrice(double new_price)
        {
           if(new_price<0)
           {
               throw new ArgumentException("Invalid data is given!");
           }
           this.price = new_price;
        }
        public getPrice()
        {
            return this.price;
        }
        public void setDate(DateTime new_date)
        {
            if(new_date==null )
            {
               throw new ArgumentException("Given date is epmty!"); 
            }
            this.date = new_date;
        }
        public string getDate()
        {
            return this.date.ToString("MMMM dd, yyyy");
        }
        public void setTitle(string new_title)
        {
            this.title = new_title;
        }
        public string getTitle()
        {
            return this.title;
        }
        public void setDescription(string new_description)
        {
            this.desciption = new_description;
        }

        public string printPropertiesOfOrders()
        {
            string result = "Title: " + this.title + 
                            ",Description: " + this.desciption +
                            ", Price: $" + this.price + 
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