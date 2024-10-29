using Alice_DomainModelEntity.Models;
using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;

namespace Alice_MVC.Controllers
{
	public class UserController : Controller
	{
		public static API api = new API();
		public static List<User> user = new List<User>();

		public IActionResult UserPage()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			var userapi = api.GetAlUser().Result;
			var newuser = userapi.Where(x => x.UserID == user.FirstOrDefault().UserID).FirstOrDefault();
			var trdata = api.GetAllTransaction().Result;

			ViewBag.tr = trdata.Where(x => x.UserID == user.FirstOrDefault().UserID).Count();
			ViewBag.trs = trdata.Where(x => x.UserID == user.FirstOrDefault().UserID && x.TransactionStatus == EnumTransation.Paid).Count();
			ViewBag.trf = trdata.Where(x => x.UserID == user.FirstOrDefault().UserID && x.TransactionStatus == EnumTransation.Pending).Count();
			return View(newuser);
		}

		public IActionResult SingerStorePage()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			return View();
		}

		public IActionResult VideoStorePage()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			return View();
		}

		public IActionResult Unsubscribe_Singer(int sid)
		{
			var singerfollow = api.GetAllSingerStore().Result;
			var data = singerfollow.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.SingerID == sid).FirstOrDefault();
			api.DeleteSingerStoreID(data.SingerStoreID);
			return RedirectToAction("Loading_SingerStorePage", "Loading");
		}

		public IActionResult CartPage()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			return View();
		}

		public IActionResult User_Cart_Buy(double Total)
		{

			ViewBag.Total = Total.ToString("0.00");
			return View();
		}

		public IActionResult User_Tr_Page()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			return View();
		}

		public IActionResult User_Tr_Page_View(string trID)
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("HomePage", "MyHomeMovie");
			}
			ViewBag.trID = trID;

			return View();
		}

		public IActionResult User_Edit()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("HomePage", "MyHomeMovie");
			}

			var userdata = api.GetAlUser().Result;
			var newuser = userdata.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).FirstOrDefault();
			return View(newuser);
		}

		[HttpPost]
		public async Task<IActionResult> User_Edit(IFormFile file, User info)
		{
			var u = user.FirstOrDefault();

			if (file != null)
			{
				string filePath = $@"wwwroot/Image/UserHead/{u.UserID + file.FileName}";
				var db = api.GetAlUser().Result;
				var newuser = db.Where(x => x.UserID == u.UserID).FirstOrDefault();

				newuser.Head = u.UserID + file.FileName;
				newuser.UserName = info.UserName;
				newuser.Password = info.Password;
				newuser.UserGmail = info.UserGmail;
				newuser.Address = info.Address;
				newuser.Gender = info.Gender;

				api.EditUserData(newuser);

				using (var stream = System.IO.File.Create(filePath))
				{
					await file.CopyToAsync(stream);
				};

				var listuser = db.Where(x => x.UserID == u.UserID).FirstOrDefault();
				user.Clear();
				user.Add(listuser);

				return RedirectToAction("Loading_To_User", "Loading");
			}
			else
			{
				var db = api.GetAlUser().Result;
				var newuser = db.Where(x => x.UserID == u.UserID).FirstOrDefault();
				newuser.UserName = info.UserName;
				newuser.Password = info.Password;
				newuser.UserGmail = info.UserGmail;
				newuser.Address = info.Address;
				newuser.Gender = info.Gender;
				api.EditUserData(newuser);


				var listuser = db.Where(x => x.UserID == u.UserID).FirstOrDefault();
				user.Clear();
				user.Add(listuser);

				return RedirectToAction("Loading_To_User", "Loading");
			}
		}

		public IActionResult Get_API()
		{
			if (user.Count() == 0)
			{
				return RedirectToAction("Home", "Home");
			}

			return View();
		}
	}
}
