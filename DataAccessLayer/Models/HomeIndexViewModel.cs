using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class HomeIndexViewModel
	{
		public int numberOfProductsWithLowStock { get; set; }
		public int numberOfOrdersWithErrorStatus { get; set; }
		public int numberOfOpenComplaints { get; set; }
	}
}
