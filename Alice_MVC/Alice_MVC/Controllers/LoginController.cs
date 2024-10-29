using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;

namespace Alice_MVC.Controllers
{
	public class LoginController : Controller
	{
		API api = new API();

		public IActionResult LoginPage()
		{
			return View();
		}

		public IActionResult SignUpPage()
		{
			return View();
		}

		public IActionResult SignOut()
		{
			UserController.user.Clear();
			return RedirectToAction("Alice_Home", "Home");
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
