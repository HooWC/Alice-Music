using Alice_DomainModelEntity.Models;
using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alice_MVC.Controllers
{
	public class MasterController : Controller
	{
		API api = new API();

		public IActionResult Home()
		{
			return View();
		}

		public IActionResult M_User()
		{
			return View();
		}

		public IActionResult M_Singer()
		{
			return View();
		}

		public IActionResult M_Music()
		{
			return View();
		}

		public IActionResult M_Video()
		{
			return View();
		}

		public IActionResult M_Transaction()
		{
			return View();
		}

		public IActionResult Master_Edit_User(int Uid)
		{
			var db = api.GetAlUser().Result;
			var newuser = db.Where(x => x.UserID == Uid).FirstOrDefault();
			return View(newuser);
		}

		public IActionResult Master_Delete_User(int Uid)
		{
			api.DeleteUserID(Uid);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		[HttpPost]
		public async Task<IActionResult> Master_User_Edit(User info)
		{
			var db = api.GetAlUser().Result;
			var newuser = db.Where(x => x.UserID == info.UserID).FirstOrDefault();
			newuser.UserName = info.UserName;
			newuser.Password = info.Password;
			newuser.UserGmail = info.UserGmail;
			newuser.Address = info.Address;
			newuser.Gender = info.Gender;
			api.EditUserData(newuser);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Edit_Singer(int SingerID)
		{
			var db = api.FindSingerData(SingerID).Result;

			return View(db);
		}

		[HttpPost]
		public async Task<IActionResult> Master_Edit_Singer(Singer singer)
		{
			var singerdata = api.FindSingerData(singer.SingerID).Result;

			singerdata.SingerName = singer.SingerName;
			singerdata.SingerImage = singer.SingerImage;
			singerdata.SingerInfo = singer.SingerInfo;
			singerdata.DebutTime = singer.DebutTime;
			singerdata.SingerType = singer.SingerType;
			singerdata.Type = singer.Type;

			api.EditSingerData(singerdata);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Delete_Singer(int SingerID)
		{
			var musicdata = api.GetAlMusic().Result;
			if (musicdata != null)
			{
				var videodata = api.GetAllVideo().Result;
				var musiclist = musicdata.Where(x => x.SingerID == SingerID).ToList();

				var videolist = (from cd in musiclist
								 join video in videodata on cd.MusicId equals video.MusicID
								 select new
								 {
									 videoid = video.VideoId
								 }).ToList();

				foreach (var i in musiclist)
					api.DeleteMusicID(i.MusicId);

				foreach (var i in videolist)
					api.DeleteVideoID(i.videoid);

			}

			api.DeleteSingerID(SingerID);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Edit_Music(int ID)
		{
			var music = api.FindMusicData(ID).Result;
			return View(music);
		}

		[HttpPost]
		public async Task<IActionResult> Master_Edit_Music(Music music)
		{
			var musicdata = api.FindMusicData(music.MusicId).Result;

			musicdata.SongName = music.SongName;
			musicdata.SongType = music.SongType;
			musicdata.SongImg = music.SongImg;
			musicdata.SongVIP = music.SongVIP;
			musicdata.SongPrice = Convert.ToDecimal(music.SongPrice);

			api.EditMusicData(musicdata);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Delete_Music(int MusicID)
		{
			var video = api.GetAllVideo().Result;
			var deleteVideo = video.Where(x => x.MusicID == MusicID).FirstOrDefault();
			api.DeleteMusicID(MusicID);
			api.DeleteVideoID(deleteVideo.VideoId);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Edit_Video(int ID)
		{
			var videodata = api.GetAllVideo().Result;


			var video = videodata.Where(x => x.MusicID == ID).FirstOrDefault();
			return View(video);
		}

		[HttpPost]
		public async Task<IActionResult> Master_Edit_Video(Video video)
		{
			var videodata = api.FindVideoData(video.VideoId).Result;
			videodata.Link = video.Link;

			api.EditVideoData(videodata);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Delete_Video(int VideoID)
		{
			var video = api.GetAllVideo().Result;
			var music = api.GetAlMusic().Result;
			var deleteVideo = video.Where(x => x.VideoId == VideoID).FirstOrDefault();
			var deleteMusic = music.Where(x => x.MusicId == deleteVideo.MusicID).FirstOrDefault();
			api.DeleteMusicID(deleteMusic.MusicId);
			api.DeleteVideoID(deleteVideo.VideoId);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Master_Tr_Page_View(string trID)
		{
			ViewBag.trID = trID;

			return View();
		}

		public IActionResult Create_Singer()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create_Singer(Singer singer)
		{
			api.MusicCreateData(singer);
			return RedirectToAction("Loading_To_Master", "Loading");
		}

		public IActionResult Create_Music_Video()
		{
			var singer = api.GetAllSinger().Result;

			ViewBag.list = new SelectList(singer, "SingerID", "SingerName");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create_Music_Video(Music music, string video)
		{
			api.MusicCreateData(music);
			var take = "slowing";

			return RedirectToAction("Loading_SaveData", "Loading", new { video = video });
		}

	}
}
