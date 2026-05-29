using DataAccessLayer;
using DataAccessLayer.Repositories;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
	public class LowStockProductsController : Controller
	{
		private readonly MatrixIncDbContext _context;
		private readonly ProductRepository _productrepository;
		public LowStockProductsController(MatrixIncDbContext context, ProductRepository productrepository) 
		{
			_context = context;
			_productrepository = productrepository;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
