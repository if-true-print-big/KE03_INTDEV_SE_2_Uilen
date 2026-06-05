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
			ProductStockViewModel model = new ProductStockViewModel();

			var products = _context.Products
			.Include(p => p.Stocks);
			List<Product> productslist = products.ToList();
			foreach (Product product in productslist)
			{
				product.Stock = product.StockAcrossLocations();
			}

			model.allproducts = productslist;
			model.productsWithLowStock = _productrepository.GetProductsWithLowStock(productslist);
			model.productsWithoutMinimumStock = _productrepository.GetAllProductsWithoutMinimumStock(productslist);t;
			return View(model);
		}
	}
}
