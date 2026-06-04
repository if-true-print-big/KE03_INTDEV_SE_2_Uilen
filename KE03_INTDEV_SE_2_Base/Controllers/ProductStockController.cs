using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
	public class ProductStockController : Controller
	{
		private readonly MatrixIncDbContext _context;
		private readonly IProductRepository _productrepository;
		public ProductStockController(MatrixIncDbContext context, IProductRepository productrepository) 
		{
			_context = context;
			_productrepository = productrepository;
		}
		public IActionResult Index()
		{
			ProductStockViewModel model = new ProductStockViewModel();
			model.productsWithLowStock = _productrepository.GetProductsWithLowStock();
			model.productsWithoutMinimumStock = _productrepository.GetAllProductsWithoutMinimumStock();
			model.allproducts = _productrepository.GetAllProducts().ToList();
			return View(model);
		}
	}
}
