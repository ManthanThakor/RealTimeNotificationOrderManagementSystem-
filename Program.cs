using System;

namespace RealTimeNotificationSystem
{
    public class Order
    {
        public event EventHandler<string> OrderPlaced;
        public event EventHandler<string> OrderShipped;
        public event EventHandler<string> OrderDelivered;

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
            OrderPlaced?.Invoke(this, message);
        }

        protected virtual void RaiseOrderShipped(string message)
        {
            OrderShipped?.Invoke(this, message);
        }

        protected virtual void RaiseOrderDelivered(string message)
        {
            OrderDelivered?.Invoke(this, message);
        }
    }

    public interface INotification
    {
        void OnOrderNotification(object sender, string message);
    }

    public class EmailService : INotification
    {
        public void OnOrderNotification(object sender, string message)
        {
            Console.WriteLine($"[*Email Notification*]: {message}");
        }
    }

    public class SMSService : INotification
    {
        public void OnOrderNotification(object sender, string message)
        {
            Console.WriteLine($"[*SMS Notification*]: {message}");
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
