using System;

namespace RealTimeNotificationSystem
{
    public class Order
    {
        public event EventHandler OrderPlaced;
        public event EventHandler OrderShipped;
        public event EventHandler OrderDelivered;

        public void PlaceOrder()
        {
            Console.WriteLine("Order has been placed.");
            RaiseOrderPlaced();
        }

        public void ShipOrder()
        {
            Console.WriteLine("Order has been shipped.");
            RaiseOrderShipped();
        }

        public void DeliverOrder()
        {
            Console.WriteLine("Order has been delivered.");
            RaiseOrderDelivered();
        }

        protected virtual void RaiseOrderPlaced()
        {
            OrderPlaced?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseOrderShipped()
        {
            OrderShipped?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseOrderDelivered()
        {
            OrderDelivered?.Invoke(this, EventArgs.Empty);
        }
    }

    public interface INotification
    {
        void OnOrderNotification(object sender, EventArgs e);
    }

    public class EmailService : INotification
    {
        public void OnOrderNotification(object sender, EventArgs e)
        {
            Console.WriteLine("[*Email Notification*]: Your order status has changed.");
        }
    }

    public class SMSService : INotification
    {
        public void OnOrderNotification(object sender, EventArgs e)
        {
            Console.WriteLine("[*SMS Notification*]: Your order status has changed.");
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
