using System;

namespace RealTimeNotificationSystem
{
    public delegate void OrderNotifi(string message);


    public class Order
    {
        public event OrderNotifi OrderPlaced;
        public event OrderNotifi OrderShipped;
        public event OrderNotifi OrderDelivered;

        public void PlaceOrder()
        {
           Console.WriteLine("Order has been placed.");
            RaiseOrderPlaced("Your order has been successfully placed.");
        }

        public void ShipOrder()
        {
            Console.WriteLine("Order has been shipped.");
            RaiseOrderShipped("Your order is on its way!");

        }

        public void DeliverOrder()
        {
            Console.WriteLine("Order has been delivered.");
            RaiseOrderDelivered("Your order has been delivered.");
        }

        protected virtual void RaiseOrderPlaced(string message)
        {
            OrderPlaced?.Invoke(message);
        }
        protected virtual void RaiseOrderShipped(string message)
        {
            OrderShipped?.Invoke(message);
        }
        protected virtual void RaiseOrderDelivered(string message)
        {
            OrderDelivered?.Invoke(message);
        }
            
    }

    public interface INotification
    {
        void OnOrderNotification(string message);
    }

    public class EmailService : INotification
    {
        public void OnOrderNotification(string message)
        {
            Console.WriteLine($"[*Email Notification*]: {message}");
        }
    }

    public class SMSService : INotification
    { 
        public void OnOrderNotification(string messge)
        {
            Console.WriteLine($"[*SMS Notification*]: {messge}");
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("\n Real-Time Notification System for Order Management Using Events and Delegates in C# \n");

            Order order = new Order();
            INotification emailService = new EmailService();
            INotification smsService = new SMSService();

            order.OrderPlaced += emailService.OnOrderNotification;
            order.OrderPlaced += smsService.OnOrderNotification;

            order.OrderShipped += emailService.OnOrderNotification;
            order.OrderShipped += smsService.OnOrderNotification;

            order.OrderDelivered += emailService.OnOrderNotification;
            order.OrderDelivered += smsService.OnOrderNotification;

            order.PlaceOrder();
            Console.WriteLine();

            order.ShipOrder();
            Console.WriteLine();

            order.DeliverOrder();

            Console.ReadLine();
        }
    }
}