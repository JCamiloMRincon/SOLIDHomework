using System;
using System.Configuration;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework
{
    public class Program
    {
        //Entry point to program
        //You don't have to change logic there
        //Tip: that is good place for composition root
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService(
                new InventoryService(),
                new NotifierService(new UserService()),
                new PaymentProcessor(),
                new MyLogger()
            );

            PaymentServiceType paymentServiceType;
            Enum.TryParse(ConfigurationManager.AppSettings["paymentType"], out paymentServiceType);

            ShoppingCart shoppingCart = new ShoppingCart("US");
            shoppingCart.Add(new OrderItem()
                {
                    Amount = 1,
                    SeassonEndDate =  DateTime.Now,
                    Code =  "Test",
                    Price =  10,
                    Type = OrderItemType.Unit
                });
            orderService.Checkout("TestUser",shoppingCart,new PaymentDetails()
                {
                   CardholderName = "haha",
                   CreditCardNumber =  "41111111111111",
                   ExpiryDate =  DateTime.Now.AddDays(10),
                   PaymentMethod = PaymentMethod.Cash
            },
            paymentServiceType, true);
        }
    }
}
