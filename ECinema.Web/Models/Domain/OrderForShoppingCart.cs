using System;

namespace ECinema.Web.Models.Domain
{
    public class OrderForShoppingCart
    {
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ShoppingCartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
