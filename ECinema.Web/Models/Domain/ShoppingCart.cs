using ECinema.Web.Models.Identity;
using System;
using System.Collections.Generic;

namespace ECinema.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerID { get; set; }
        public ECinemaUser Owner { get; set; }
        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }
        public virtual ICollection<OrderForShoppingCart> OrderForShoppingCarts { get; set; }
    }
}
