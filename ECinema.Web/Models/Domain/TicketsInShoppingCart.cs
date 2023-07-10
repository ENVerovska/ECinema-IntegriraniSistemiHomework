using System;

namespace ECinema.Web.Models.Domain
{
    public class TicketsInShoppingCart
    {
        public Guid TicketID { get; set; }
        public Tickets Ticket { get; set; }
        public Guid ShoppingCartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }

    }
}
