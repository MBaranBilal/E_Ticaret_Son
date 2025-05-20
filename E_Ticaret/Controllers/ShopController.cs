using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Controllers
{
	public class ShopController : Controller
	{
		ETicaretDbContext context = new ETicaretDbContext();
		public IActionResult Shop(double? minPrice, double? maxPrice)
		{
			var products = context.Products.AsQueryable();

			if (minPrice != null)
				products = products.Where(p => p.Price >= minPrice);

			if (maxPrice != null)
				products = products.Where(p => p.Price <= maxPrice);

			var values = products.ToList();
			return View(values);
		}

	}
}
