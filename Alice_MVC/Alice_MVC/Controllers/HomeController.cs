using System.Diagnostics;
using Alice_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alice_MVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Menu_Home()
		{
			return View();
		}

		public IActionResult Home()
		{
			return View();
		}

		public IActionResult Alice_Home()
		{
			return View();
		}
	}
}