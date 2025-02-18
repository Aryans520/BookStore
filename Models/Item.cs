using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}