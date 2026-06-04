using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        //this is the minimum amound the company can hold of a product before it gets added to a special list to help the admins keep stock.
        //TODO actually make this list
        public int? MinimumStock { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<Part> Parts { get; } = new List<Part>();

        public ICollection<Review> Reviews { get; } = new List<Review>();
    }
}
