using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
	public class LowStockProductsController : Controller
	{
		private readonly MatrixIncDbContext _context;
		private readonly IProductRepository _productrepository;
		public LowStockProductsController(MatrixIncDbContext context, IProductRepository productrepository) 
		{
			_context = context;
			_productrepository = productrepository;
		}
		public IActionResult Index()
		{
			LowStockProductsViewModel model = new LowStockProductsViewModel();
			model.productsWithLowStock = _productrepository.GetProductsWithLowStock();
			model.productsWithoutMinimumStock = _productrepository.GetAllProductsWithoutMinimumStock();
			return View(model);
		}
	}
}
