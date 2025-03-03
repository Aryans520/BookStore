using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Product
    {
        //public Product()
        //{
        //    Categories = new List<Category>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Category> Categories { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public int ItemId { get; set; } //ForeignKey

        public Item Item { get; set; } //Navigation property
    }
}