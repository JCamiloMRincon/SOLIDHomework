using System;
using System.Configuration;
using SOLIDHomework.Core.Exceptions;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core
{
    //Order - check inventory, charge money for credit card and online payments, 
    //tips:
    //think about SRP, DI, OCP
    //maybe for each type of payment type make sense to have own Order-based class?
    public class OrderService
    {
        private InventoryService InventoryService;
        private NotifierService NotifierService;
        private PaymentProcessor PaymentProcessor;
        private MyLogger _logger;

        public OrderService(
            InventoryService InventoryService,
            NotifierService NotifierService,
            PaymentProcessor PaymentProcessor,
            MyLogger logger
        )
        {
            this.InventoryService = InventoryService;
            this.NotifierService = NotifierService;
            this.PaymentProcessor = PaymentProcessor;
            _logger = logger;
        }

        public void Checkout(string username, ShoppingCart shoppingCart, PaymentDetails paymentDetails, PaymentServiceType paymentServiceType, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard || paymentDetails.PaymentMethod == PaymentMethod.OnlineOrder)
            {
                PaymentProcessor.ChargeCard(paymentDetails, shoppingCart, paymentServiceType);
            }

            ReserveInventory(shoppingCart);

            if (paymentDetails.PaymentMethod == PaymentMethod.OnlineOrder)
            {
                if (notifyCustomer)
                {
                    NotifierService.NotifyCustomer(username);
                }
            }

            _logger.Write("Success checkout");
        }     

        public void ReserveInventory(ShoppingCart cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    InventoryService.Reserve(item.Code, item.Amount);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Code, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }
}
