using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace DataAccessLayer.Models
{
    public class Product
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }


        //this is the minimum amound the company can hold of a product before it gets added to a special list to help the admins keep stock.
        //TODO actually make this list
        public int? MinimumStock { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<Part> Parts { get; } = new List<Part>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        
        //deze functie werkt niet omdat hij de Stocks niet kan zien, hij geeft altijd een returnwaarde van 0.
        //.Include werkt niet bij products, ik weet niet waarom.
        public int StockAcrossLocations()
        {
            int stockAcrossLocations = 0;
            foreach(Stock  stock in Stocks)
            {     
                stockAcrossLocations += stock.Quantity;
            }
            return stockAcrossLocations;
        }

		//dit is om de resultaten van de bovenstaande functie in te doen
		[NotMapped]
        public int Stock { get; set; }
    }
}
