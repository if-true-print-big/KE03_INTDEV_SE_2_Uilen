using System.Diagnostics;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MatrixIncDbContext _context;
        private readonly IProductRepository _productrepository;

        public HomeController(ILogger<HomeController> logger, MatrixIncDbContext context, IProductRepository productrepository)
        {
            _logger = logger;
            _context = context;
            _productrepository = productrepository;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

			var products = _context.Products
            .Include(p => p.Stocks);
			List<Product> productslist = products.ToList();
			foreach (Product product in productslist)
			{
				product.Stock = product.StockAcrossLocations();
			}

            var orders = _context.Orders;
            int ordersWithErrorStatus = 0;
            foreach (Order order in orders)
            {
                if (order.Status == Order.OrderStatus.Error)
                {
                    ordersWithErrorStatus++;
                }
            }

			var complaints = _context.Complaints;
			int openComplaints = 0;
			foreach (Complaint complaint in complaints)
			{
				if (complaint.Status == Complaint.ComplaintStatus.Open)
				{
					openComplaints++;
				}
			}


			model.numberOfProductsWithLowStock = _productrepository.GetProductsWithLowStock(productslist).Count();
            model.numberOfOrdersWithErrorStatus = ordersWithErrorStatus;
            model.numberOfOpenComplaints = openComplaints;

			return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
