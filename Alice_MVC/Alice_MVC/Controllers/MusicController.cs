using Alice_DomainModelEntity.Models;
using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;

namespace Alice_MVC.Controllers
{
	public class MusicController : Controller
	{
		public static API api = new API();

		public IActionResult Music(string songtype)
		{
			if (UserController.user.Count() == 0)
			{
				return RedirectToAction("LoginPage", "Login");
			}

			if (songtype != null)
				ViewBag.songtype = songtype;
			else
				ViewBag.songtype = "none";

			return View();
		}

		public IActionResult MusicDetail(int SongID)
		{
			if (UserController.user.Count() == 0)
			{
				return RedirectToAction("LoginPage", "Login");
			}

			var video = api.GetAllVideo().Result;
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var vr = video.Where(x => x.MusicID == SongID).FirstOrDefault();
			ViewBag.Video = vr.Link;
			ViewBag.VideoID = vr.VideoId;

			var data = (from cd in musicdata
						where cd.MusicId == SongID
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							singerid = singer.SingerID
						}).FirstOrDefault();

			MusicDetail md = new MusicDetail()
			{
				mid = data.mid,
				SongName = data.SongName,
				SongType = data.SongType,
				SongImg = data.SongImg,
				singer = data.singer,
				singerid = data.singerid
			};

			return View(md);


		}

		public IActionResult SingerPage()
		{
			if (UserController.user.Count() == 0)
			{
				return RedirectToAction("LoginPage", "Login");
			}
			return View();
		}

		public IActionResult SingerDetail(int SongID)
		{
			if (UserController.user.Count() == 0)
				return RedirectToAction("LoginPage", "Login");

			var singerdata = api.GetAllSinger().Result;

			var pro = singerdata.Where(x => x.SingerID == SongID).FirstOrDefault();

			return View(pro);
		}

		public IActionResult AddtoCart(int SongID)
		{
			if (UserController.user.Count() == 0)
			{
				return RedirectToAction("LoginPage", "Login");
			}

			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var ispaid = api.GetAllCart().Result;
			var findispaid = ispaid.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.MusicID == SongID && x.IsPaid == true).FirstOrDefault();
			if (findispaid != null)
				return RedirectToAction("MusicDetail", "Music", new { SongID = SongID });

			var cart = ispaid.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.MusicID == SongID && x.IsPaid == false).FirstOrDefault();
			if (cart != null)
				return RedirectToAction("Loading_To_Cart", "Loading");

			var musicdetail = musicdata.Where(x => x.MusicId == SongID).FirstOrDefault();
			var name = singerdata.Where(x => x.SingerID == musicdetail.SingerID).FirstOrDefault();
			ViewBag.singername = name.SingerName;

			return View(musicdetail);
		}

	}
}
