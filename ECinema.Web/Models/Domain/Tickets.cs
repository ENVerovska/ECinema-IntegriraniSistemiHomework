using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECinema.Web.Models.Domain
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public string MovieImage { get; set; }
        public string MovieDescription { get; set; }
        public int Rating { get; set; }

        public int TicketPrice { get; set; }

        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }

        

    }
}
