# Real-Time Notification System for Order Management Using Events and Delegates in C#

This is a simple implementation of a Real-Time Notification System in C# for order management. The system uses C# events and delegates to notify different services (Email, SMS) when an order is placed, shipped, or delivered.

## Problem Statement

Real-Time Notification System Using Events and Delegates in C#

Scenario:
An online shopping application needs a notification system to inform users about the progress of their orders. Notifications should be sent via email and SMS when the following events occur:

1. Order Placed: Notify when the order is successfully placed.
2. Order Shipped: Notify when the order is shipped.
3. Order Delivered: Notify when the order is delivered.

The application should use delegates and events to handle the notifications efficiently. Multiple subscribers (like email and SMS services) should receive updates whenever an event occurs.

## Features

- **Real-time notifications**: The system notifies via Email and SMS using events when certain actions (Order Placed, Order Shipped, Order Delivered) occur.
- **Custom Event Handling**: Events are triggered for each order action, and notifications are sent to the corresponding services (Email and SMS).
- **Separation of Concerns**: The notification logic is decoupled from the order management logic, making it easy to extend and maintain.

## Technologies Used

- C#
- Events and Delegates
- Interfaces for Notification Services

## Setup Instructions

To run the Real-Time Notification System locally:

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/ManthanThakor/RealTimeNotificationOrderManagementSystem-.git

2. Navigate to the project folder:

		cd RealTimeNotificationSystem

3. Open the project in your preferred C# IDE (e.g., Visual Studio or Visual Studio Code).

4. Build and run the project.

## Code Structure

 - Order: This class contains methods for placing, shipping, and delivering orders. It raises events when any of these actions occur.
 - INotification: This interface defines the OnOrderNotification method, which is implemented by the EmailService and SMSService classes to send notifications.
 - EmailService & SMSService: These classes implement the INotification interface and handle the sending of notifications through Email and SMS.

## Example Usage

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

## Output Example

	Real-Time Notification System for Order Management Using Events and Delegates in C#

	Order has been placed.
	[*Email Notification*]: Your order has been successfully placed.
	[*SMS Notification*]: Your order has been successfully placed.

	Order has been shipped.
	[*Email Notification*]: Your order is on its way!
	[*SMS Notification*]: Your order is on its way!

	Order has been delivered.
	[*Email Notification*]: Your order has been delivered.
	[*SMS Notification*]: Your order has been delivered.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
