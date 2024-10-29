using Alice_DomainModelEntity.Models;
using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;

namespace Alice_MVC.Controllers
{
	public class LoadingController : Controller
	{
		API api = new API();

		public IActionResult Loading_MusicDetail(int id)
		{
			ViewBag.Id = id;
			return View();
		}

		public IActionResult Loading_SingerStorePage()
		{
			return View();
		}

		public IActionResult Loading_To_Cart()
		{
			return View();
		}

		public IActionResult Loading_To_User()
		{
			return View();
		}

		public IActionResult Loading_To_Login()
		{
			return View();
		}

		public IActionResult Loading_To_Master(string video)
		{
			if (video != null)
			{
				var musiclist = api.GetAlMusic().Result;
				var musicid = musiclist.LastOrDefault().MusicId;
				Video v = new Video()
				{
					MusicID = musicid,
					Link = video
				};

				api.MusicCreateData(v);
			}
			return View();
		}

		public IActionResult Loading_SaveData(string video)
		{
			ViewBag.Link = video;
			return View();
		}

		public IActionResult Loading_Home()
		{
			return View();
		}

	}
}
