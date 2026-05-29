using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class LowStockProductsViewModel
	{
		public List<Product> productsWithLowStock { get; set; }

		public List<Product> productsWithoutMinimumStock { get; set; }
	}
}
