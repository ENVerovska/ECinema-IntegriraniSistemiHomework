using System;
using System.Collections.Generic;

namespace ECinema.Web.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public virtual ICollection<OrderForShoppingCart> OrderForShoppingCarts { get; set; }
    }
}
