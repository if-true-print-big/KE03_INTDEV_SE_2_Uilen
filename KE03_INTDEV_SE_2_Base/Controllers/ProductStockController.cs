using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			LowStockProductsViewModel model = new LowStockProductsViewModel();

			var products = _context.Products
			.Include(p => p.Stocks);
			List<Product> productslist = products.ToList();

			model.productsWithLowStock = _productrepository.GetProductsWithLowStock(productslist);
			foreach (Product product in model.productsWithLowStock)
			{
				product.Stock = product.StockAcrossLocations();
			}
			model.productsWithoutMinimumStock = _productrepository.GetAllProductsWithoutMinimumStock(productslist);
			foreach (Product product in model.productsWithoutMinimumStock)
			{
				product.Stock = product.StockAcrossLocations();
			}
			model.allproducts = productslist;
			return View(model);
		}
	}
}
