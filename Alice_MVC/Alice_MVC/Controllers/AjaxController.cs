using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Alice_DomainModelEntity.Models;
using Alice_Infrastructure.Repository.Api;
using Microsoft.AspNetCore.Mvc;
using Alice_Infrastructure.Repository.CreditCartFunction;
using Stripe;
using Stripe.Issuing;
using System.Transactions;

namespace Alice_MVC.Controllers
{
	public class AjaxController : Controller
	{
		public static API api = new API();
		public static string TrID = "";
		private readonly DtoStripeSecrets _stripeSecrets;
		static DtoStripeSecrets stripeSecrets = new DtoStripeSecrets()
		{
			SecretKey = "sk_test_51LFrBPCDMjmOjphDkCD5knDL4oLcb1bb6XMIOHIZ3AizXlVnzdS6xcgVYbkxPTdg35VrT5Rd5xME04Cq5PoOt7D100pS55JR49",
			PublishableKey = "pk_test_51LFrBPCDMjmOjphDmhCWgsFP5QXCXxv0p1oFE0ySjBUHQ0CwKAeuxeCNEYl8gtkXo4NZsYTDiD8Hf0KPQKVUA2mJ00FWY79rOk"
		};

		public IActionResult GetPop_Home()
		{
			List<Music> mlist2 = api.GetAlMusic().Result;

			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Pop")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetRock_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Rock")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetSoft_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Soft")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetSad_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Sad")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetChinese_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Chinese")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetEnglish_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("English")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetJapanese_Home()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Japanese")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		public IActionResult GetAllMusic()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Pop()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Pop")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Rock()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Rock")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Soft()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Soft")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Sad()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Sad")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Chinese()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Chinese")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_English()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("English")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetAll_Japanese()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Japanese")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		public IActionResult GetRightMusic(string MCID)
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.MusicId != Convert.ToInt32(MCID)
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(20).ToList();
			return Json(data);
		}

		public IActionResult GetSingerTake()
		{
			var singerdata = api.GetAllSinger().Result;
			var data = singerdata.Take(10).ToList();
			return Json(data);
		}

		public IActionResult GetAllSinger()
		{
			var singerdata = api.GetAllSinger().Result;
			return Json(singerdata);
		}

		public IActionResult GetOneSingerSong(int SingerID)
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SingerID == SingerID
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();


			return Json(data);
		}

		[HttpPost]
		public IActionResult SignUp_Post(string Passwordinput)
		{
			if (Passwordinput == null)
				return Json(false);
			else
			{
				if (Passwordinput.Length < 6)
					return Json(false);
				else
				{
					var db = api.GetAlUser().Result;
					var xm = db.Where(x => x.Password == Passwordinput).FirstOrDefault();
					if (xm != null)
						return Json(false);
					else
						return Json(true);
				}
			}

		}

		[HttpPost]
		public IActionResult SignUp_Post_Gmail(string Gmailinpu)
		{
			if (Gmailinpu == null)
				return Json(false);
			else
			{
				if (!Gmailinpu.Contains("@gmail.com"))
					return Json(false);
				else
				{
					var db = api.GetAlUser().Result;
					var xm = db.Where(x => x.UserGmail == Gmailinpu).FirstOrDefault();
					if (xm != null)
						return Json(false);
					else
						return Json(true);
				}
			}

		}

		[HttpPost]
		public IActionResult SignUp(User user)
		{
			User ur = new User()
			{
				UserName = user.UserName,
				UserGmail = user.UserGmail,
				Password = user.Password,
				Gender = user.Gender,
				Address = user.Address,
				CreateDate = DateTime.Now,
				Head = "Hear.jpg"
			};

			api.UserCreateData(ur);

			return Json(true);

		}

		[HttpPost]
		public IActionResult LoginPost(string myGmail, string myPassword)
		{
			if (myGmail == "." && myPassword == "084487")
			{
				return Json("Master");
			}

			var db = api.GetAlUser().Result;
			var checkUser = db.Where(x => x.UserGmail == myGmail && x.Password == myPassword).FirstOrDefault();
			if (checkUser == null)
				return Json(false);
			else
			{
				UserController.user = db.Where(x => x.UserGmail == myGmail && x.Password == myPassword).ToList();
				var user = UserController.user.FirstOrDefault();
				return Json(true);
			}
		}

		public IActionResult GetComment(int MusicID)
		{
			List<Comment> com = api.GetAlComment().Result;
			var userlist = api.GetAlUser().Result;

			var data = (from cd in com
						where cd.Movie_Id == MusicID
						join user in userlist on cd.User_Id equals user.UserID
						select new
						{
							commentID = cd.CommentID,
							head = user.Head,
							username = user.UserName,
							comment = cd.CommentWord,
							commenttime = cd.CreatedDate.ToString("dddd, dd MMMM yyyy")
						}).OrderByDescending(x => x.commentID).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult AddComment(int MusicID, string commenttext)
		{

			Comment com = new Comment()
			{
				Movie_Id = MusicID,
				User_Id = UserController.user.FirstOrDefault().UserID,
				CreatedDate = DateTime.Now,
				CommentWord = commenttext
			};

			List<Comment> commentlist = new List<Comment>() { com };

			api.CommentCreateData(com);

			var userlist = api.GetAlUser().Result;

			var data = (from cd in userlist
						join c in commentlist on cd.UserID equals c.User_Id
						select new
						{
							head = cd.Head,
							username = cd.UserName,
							comment = c.CommentWord,
							commenttime = c.CreatedDate.ToString("dddd, dd MMMM yyyy")
						});



			return Json(data);

		}

		public IActionResult GETFollow(int SingerID)
		{
			var singerfollow = api.GetAllSingerStore().Result;
			var data = singerfollow.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.SingerID == SingerID).FirstOrDefault();
			if (data != null)
				return Json(true);
			else
				return Json(false);

		}

		[HttpPost]
		public IActionResult FollowSinger(int SingerID)
		{
			var singerfollow = api.GetAllSingerStore().Result;
			var data = singerfollow.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.SingerID == SingerID).FirstOrDefault();
			if (data != null)
			{
				api.DeleteSingerStoreID(data.SingerStoreID);
				return Json(false);//follow button
			}
			else
			{
				SingerStore store = new SingerStore()
				{
					SingerID = SingerID,
					UserID = UserController.user.FirstOrDefault().UserID
				};

				api.SingerStoreCreateData(store);
				return Json(true);
			}

		}

		public IActionResult GETCollet(int VideoID)
		{
			var videodata = api.GetAllVideoStore().Result;
			var data = videodata.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.VideoID == VideoID).FirstOrDefault();
			if (data != null)
				return Json(true);
			else
				return Json(false);

		}

		[HttpPost]
		public IActionResult GETNewCollet(int VideoID)
		{
			var videodata = api.GetAllVideoStore().Result;
			var data = videodata.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.VideoID == VideoID).FirstOrDefault();
			if (data != null)
			{
				api.DeleteVideoStore(data.VideoStoreID);
				return Json(false);
			}
			else
			{
				VideoStore store = new VideoStore()
				{
					VideoID = VideoID,
					UserID = UserController.user.FirstOrDefault().UserID
				};

				api.VideoStoreCreateData(store);
				return Json(true);
			}

		}

		[HttpPost]
		public IActionResult Search_Get_SingerStore(string Search)
		{

			var singerfollow = api.GetAllSingerStore().Result;
			var data = singerfollow.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();
			var singerdata = api.GetAllSinger().Result;

			if (Search == null)
			{

				var storedata1 = from cd in singerdata
								 join store in data on cd.SingerID equals store.SingerID
								 select new
								 {
									 SingerID = cd.SingerID,
									 SingerName = cd.SingerName,
									 SingerImage = cd.SingerImage,
									 SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
									 DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
								 };

				return Json(storedata1);
			}
			else
			{

				var storedata2 = (from cd in singerdata
								  where cd.SingerName.ToLower().Contains(Search.ToLower())
								  join store in data on cd.SingerID equals store.SingerID
								  select new
								  {
									  SingerID = cd.SingerID,
									  SingerName = cd.SingerName,
									  SingerImage = cd.SingerImage,
									  SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
									  DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
								  }).ToList();

				if (storedata2.Count() == 0)
				{

					var storedata3 = from cd in singerdata
									 join store in data on cd.SingerID equals store.SingerID
									 select new
									 {
										 SingerID = cd.SingerID,
										 SingerName = cd.SingerName,
										 SingerImage = cd.SingerImage,
										 SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
										 DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
									 };

					return Json(storedata3);
				}

				return Json(storedata2);
			}
		}

		public IActionResult Get_SingerStore()
		{
			var singerdata = api.GetAllSinger().Result;
			var singerfollow = api.GetAllSingerStore().Result;
			var data = singerfollow.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();
			if (data.Count() > 0)
			{
				List<int> saveid = new List<int>();
				foreach (var item in data)
				{
					saveid.Add(item.SingerID);
				}

				var storedata = from cd in singerdata
								join store in data on cd.SingerID equals store.SingerID
								select new
								{
									SingerID = cd.SingerID,
									SingerName = cd.SingerName,
									SingerImage = cd.SingerImage,
									SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
									DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
								};

				return Json(storedata);
			}

			return Json(true);
		}

		public IActionResult GetVideoStore()
		{
			var videostorelist = api.GetAllVideoStore().Result;
			var videolist = api.GetAllVideo().Result;
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;

			var result = videostorelist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();

			var data = (from cd in result
						join video in videolist on cd.VideoID equals video.VideoId
						join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
						join singer in singerdata on music.SingerID equals singer.SingerID
						select new
						{
							mid = music.MusicId,
							videoid = video.VideoId,
							itemimg = music.SongImg,
							songname = music.SongName,
							singer = singer.SingerName,
							team = singer.SingerType == 0 ? "Orchestra" : "Individual",
							category = music.SongType,
							status = music.SongVIP == 0 ? "FREE" : "VIP",
							price = music.SongPrice.ToString("0.00")
						}).ToList();

			return Json(data);
		}

		public IActionResult GetVideoStore_List_Filter(string myselect)
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (myselect == "All Categories")
			{
				var videostorelist = api.GetAllVideoStore().Result;
				var videolist = api.GetAllVideo().Result;
				var result = videostorelist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();
				var data = (from cd in result
							join video in videolist on cd.VideoID equals video.VideoId
							join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								mid = music.MusicId,
								videoid = video.VideoId,
								itemimg = music.SongImg,
								songname = music.SongName,
								singer = singer.SingerName,
								team = singer.SingerType == 0 ? "Orchestra" : "Individual",
								category = music.SongType,
								status = music.SongVIP == 0 ? "FREE" : "VIP",
								price = music.SongPrice.ToString("0.00")
							}).ToList();

				return Json(data);
			}
			else
			{
				var videostorelist = api.GetAllVideoStore().Result;
				var videolist = api.GetAllVideo().Result;
				var result = videostorelist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();

				var data = (from cd in result
							join video in videolist on cd.VideoID equals video.VideoId
							join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
							where music.SongType.Contains(myselect)
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								videoid = video.VideoId,
								itemimg = music.SongImg,
								songname = music.SongName,
								singer = singer.SingerName,
								team = singer.SingerType == 0 ? "Orchestra" : "Individual",
								category = music.SongType,
								status = music.SongVIP == 0 ? "FREE" : "VIP",
								price = music.SongPrice.ToString("0.00")
							}).ToList();

				return Json(data);
			}


		}

		[HttpPost]
		public IActionResult GetVideoStore_List_Search(string Search)
		{
			var videostorelist = api.GetAllVideoStore().Result;
			var videolist = api.GetAllVideo().Result;
			var result = videostorelist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (Search == null)
			{
				var data = (from cd in result
							join video in videolist on cd.VideoID equals video.VideoId
							join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								mid = music.MusicId,
								videoid = video.VideoId,
								itemimg = music.SongImg,
								songname = music.SongName,
								singer = singer.SingerName,
								team = singer.SingerType == 0 ? "Orchestra" : "Individual",
								category = music.SongType,
								status = music.SongVIP == 0 ? "FREE" : "VIP",
								price = music.SongPrice.ToString("0.00")
							}).ToList();

				return Json(data);
			}
			else
			{
				var data = (from cd in result
							join video in videolist on cd.VideoID equals video.VideoId
							join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
							where music.SongName.ToLower().Contains(Search.ToLower())
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								videoid = video.VideoId,
								itemimg = music.SongImg,
								songname = music.SongName,
								singer = singer.SingerName,
								team = singer.SingerType == 0 ? "Orchestra" : "Individual",
								category = music.SongType,
								status = music.SongVIP == 0 ? "FREE" : "VIP",
								price = music.SongPrice.ToString("0.00")
							}).ToList();

				return Json(data);
			}
		}

		[HttpPost]
		public IActionResult GetVideoStore_Price(bool data)
		{
			var videostorelist = api.GetAllVideoStore().Result;
			var videolist = api.GetAllVideo().Result;
			var result = videostorelist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (data == true)
			{
				var res = (from cd in result
						   join video in videolist on cd.VideoID equals video.VideoId
						   join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
						   join singer in singerdata on music.SingerID equals singer.SingerID
						   select new
						   {
							   mid = music.MusicId,
							   videoid = video.VideoId,
							   itemimg = music.SongImg,
							   songname = music.SongName,
							   singer = singer.SingerName,
							   team = singer.SingerType == 0 ? "Orchestra" : "Individual",
							   category = music.SongType,
							   status = music.SongVIP == 0 ? "FREE" : "VIP",
							   price = music.SongPrice.ToString("0.00")
						   }).OrderByDescending(x => x.price).ToList();

				return Json(res);
			}
			else
			{
				var res = (from cd in result
						   join video in videolist on cd.VideoID equals video.VideoId
						   join music in musicdata on Convert.ToInt32(video.MusicID) equals music.MusicId
						   join singer in singerdata on music.SingerID equals singer.SingerID
						   select new
						   {
							   videoid = video.VideoId,
							   itemimg = music.SongImg,
							   songname = music.SongName,
							   singer = singer.SingerName,
							   team = singer.SingerType == 0 ? "Orchestra" : "Individual",
							   category = music.SongType,
							   status = music.SongVIP == 0 ? "FREE" : "VIP",
							   price = music.SongPrice.ToString("0.00")
						   }).OrderBy(x => x.price).ToList();

				return Json(res);
			}
		}

		[HttpPost]
		public IActionResult AddMusicToCart(string ProductID)
		{

			var musicdata = api.GetAlMusic().Result;
			var music = musicdata.Where(x => x.MusicId == Convert.ToInt32(ProductID)).FirstOrDefault();
			Cart cart = new Cart()
			{
				UserID = UserController.user.FirstOrDefault().UserID,
				MusicID = music.MusicId,
				MusicPrice = music.SongPrice,
				IsPaid = false,
				IsSelected = false
			};

			api.CartCreateData(cart);

			return Json(true);
		}

		public IActionResult GetCartInfo()
		{
			var cartlist = api.GetAllCart().Result;
			var cart = cartlist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.IsPaid == false).ToList();
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (cart.Count() == 0)
			{
				return Json(false);
			}
			else
			{
				var data = (from cd in cart
							join music in musicdata on cd.MusicID equals music.MusicId
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								cartid = cd.CartID,
								SongImg = music.SongImg,
								SongType = music.SongType,
								SongVIP = "VIP",
								SongPrice = music.SongPrice,
								SongName = music.SongName,
								Isselect = cd.IsSelected,
								Singer = singer.SingerName
							}).ToList();

				return Json(data);
			}
		}

		[HttpPost]
		public IActionResult CheckSelectCart(bool Check, int ID)
		{
			var cartlist = api.GetAllCart().Result;
			var cart = cartlist.Where(x => x.CartID == ID).FirstOrDefault();
			cart.IsSelected = Check;

			api.EditCartData(cart);

			var Get_New_cartlist = api.GetAllCart().Result;
			var Get_New_cart = Get_New_cartlist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.IsPaid == false).ToList();
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (Get_New_cart.Count() == 0)
			{
				return Json(false);
			}
			else
			{
				var data = (from cd in Get_New_cart
							join music in musicdata on cd.MusicID equals music.MusicId
							join singer in singerdata on music.SingerID equals singer.SingerID
							select new
							{
								cartid = cd.CartID,
								SongImg = music.SongImg,
								SongType = music.SongType,
								SongVIP = "VIP",
								SongPrice = music.SongPrice,
								SongName = music.SongName,
								Isselect = cd.CartID == ID ? Check : cd.IsSelected,
								Singer = singer.SingerName
							}).ToList();

				return Json(data);
			}
		}

		[HttpPost]
		public IActionResult CartDeleteItem(int CartID)
		{

			api.DeleteCart(CartID);

			var Get_New_cartlist = api.GetAllCart().Result;
			var Get_New_cart = Get_New_cartlist.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID && x.IsPaid == false).ToList();

			return Json(true);


		}

		[HttpPost]
		public IActionResult MakeNewPY(double TotalPricePost, string CartListPost)
		{
			if (CartListPost == null || TotalPricePost == 0)
			{
				return Json(false);
			}

			var db = api.GetAllTransaction().Result;
			var trid = db.OrderByDescending(x => x.Id).FirstOrDefault();
			if (trid == null)
				TrID = "1";
			else
				TrID = (trid.Id + 1).ToString();

			Alice_DomainModelEntity.Models.Transaction tr = new Alice_DomainModelEntity.Models.Transaction()
			{
				PaidTime = DateTime.Now,
				TransactionStatus = EnumTransation.Pending,
				CartIDList = CartListPost,
				UserID = UserController.user.FirstOrDefault().UserID
			};

			api.TransactionCreateData(tr);

			return Json(true);
		}

		[HttpPost]
		public IActionResult PY(double Total, CreditCard data)
		{
			if (data.number != "4242424242424242" || data.name == null || data.Cvc == null || data.ExpMonth == 0 || data.expYear == 0)
			{
				return Json(false);
			}

			try
			{
				long amount = Convert.ToInt64(Total * 100);

				StripePayment stripePayment = new StripePayment(new CreditCard
				{
					Name = data.Name,
					Email = UserController.user.FirstOrDefault().UserGmail,
					AddressLine1 = UserController.user.FirstOrDefault().Address,
					AddressLine2 = UserController.user.FirstOrDefault().Address,
					AddressCity = "Pinang",
					AddressState = "True",
					AddressZip = "1234",//地址邮编
					Descripcion = $"Purchase on {DateTime.Now}",
					DetailsDescripcion = $"test {DateTime.Now:d}",
					Amount = amount, //2000 = 20.00   10000 == ??
					Currency = "MYR",
					Number = data.number,//4242 4242 4242 4242
					ExpMonth = data.ExpMonth,
					ExpYear = data.ExpYear,
					Cvc = data.Cvc //123
				}, stripeSecrets);
				Charge charge = stripePayment.ProccessPayment();

				var cart = api.GetAllCart().Result;
				var newcart = cart.Where(x => x.IsPaid == false && x.UserID == UserController.user.FirstOrDefault().UserID && x.IsSelected == true).ToList();
				foreach (var i in newcart)
				{
					i.IsPaid = true;
					api.EditCartData(i);
				}

				var trdata = api.FindTransactionData(Convert.ToInt32(TrID)).Result;
				trdata.TransactionStatus = EnumTransation.Paid;
				trdata.PaidTime = DateTime.Now;
				api.EditTransactionData(trdata);

			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}


			return Json(true);
		}

		public IActionResult GetTr()
		{
			var trList = api.GetAllTransaction().Result;
			var dataList = trList.Where(x => x.UserID == UserController.user.FirstOrDefault().UserID).ToList();

			var data = (from cd in dataList
						select new
						{
							id = cd.Id,
							PaidTime = cd.PaidTime.ToString("dddd, dd MMMM yyyy"),
							TransactionStatus = cd.TransactionStatus == 0 ? "Pending" : "Paid",
							CartIDList = cd.CartIDList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Count()
						}).OrderByDescending(x => x.id).Take(5).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult TransactionDetailData(int trid)
		{
			var trList = api.GetAllTransaction().Result;
			var dataList = trList.Where(x => x.Id == trid).FirstOrDefault();
			var dataList2 = trList.Where(x => x.Id == trid).ToList();
			var userlist = api.GetAlUser().Result;

			string[] cartlist = dataList.CartIDList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			decimal totalprice = 0;
			foreach (var i in cartlist)
			{
				var getcartdata = api.FindCartData(Convert.ToInt32(i)).Result;
				totalprice += getcartdata.MusicPrice;
			}

			var data = (from cd in dataList2
						join user in userlist on cd.UserID equals user.UserID
						select new
						{
							Trid = cd.Id,
							PaidTime = cd.PaidTime.ToString("dddd, dd MMMM yyyy"),
							TransactionStatus = cd.TransactionStatus == 0 ? "Pending" : "Paid",
							CartIDList = cd.CartIDList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Count(),
							Username = user.UserName,
							Totalprice = totalprice.ToString("0.00"),
							gst = (Convert.ToDouble(totalprice) * 0.06).ToString("0.00"),
							grandtotal = (Convert.ToDouble(totalprice) * 1.06).ToString("0.00")
						}).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult GetTr_View(int trID)
		{
			var trList = api.GetAllTransaction().Result;
			var trdataList = trList.Where(x => x.Id == trID).FirstOrDefault();
			var cartlist = api.GetAllCart().Result;

			var musicdata = api.GetAlMusic().Result;
			string[] stringlist = trdataList.CartIDList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

			var data = (from cd in stringlist
						join cart in cartlist on Convert.ToInt32(cd) equals cart.CartID
						join music in musicdata on cart.MusicID equals music.MusicId
						select new
						{
							musicimg = music.SongImg,
							musicname = music.SongName,
							musicid = music.MusicId,
							price = music.SongPrice
						}).ToList();

			return Json(data);
		}

		public IActionResult GetCommentHead()
		{
			var data = UserController.user.FirstOrDefault().Head;

			return Json(data);
		}

		public IActionResult GetResidentSinger()
		{
			var singerdata = api.GetAllSinger().Result;
			var data = singerdata.Take(5).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult Edit_Post_Password(string Password)
		{

			if (Password == null)
				return Json(false);
			else
			{
				if (Password.Length < 6)
					return Json(false);
				else
				{
					var db = api.GetAlUser().Result;
					var xm = db.Where(x => x.Password == Password).FirstOrDefault();

					if (xm != null)
					{
						if (xm.Password == UserController.user.FirstOrDefault().Password)
							return Json(true);
						else
							return Json(false);
					}
					else
						return Json(true);
				}
			}

		}

		[HttpPost]
		public IActionResult Edit_Post_Gmail(string Gmail)
		{
			if (Gmail == null)
				return Json(false);
			else
			{
				if (!Gmail.Contains("@gmail.com"))
					return Json(false);
				else
				{
					var db = api.GetAlUser().Result;
					var xm = db.Where(x => x.UserGmail == Gmail).FirstOrDefault();

					if (xm != null)
					{
						if (xm.UserGmail == UserController.user.FirstOrDefault().UserGmail)
							return Json(true);
						else
							return Json(false);
					}
					else
						return Json(true);
				}
			}

		}

		public IActionResult GetLeaderboard()
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			var data = (from cd in musicdata
						where cd.SongType.Contains("Top")
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							mid = cd.MusicId,
							SongName = cd.SongName,
							SongType = cd.SongType,
							SongImg = cd.SongImg,
							singer = singer.SingerName,
							ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).OrderByDescending(x => x.mid).Take(8).ToList();


			return Json(data);
		}

		[HttpPost]
		public IActionResult User_ForgotPassword(string myGmail, string myPassword)
		{
			var db = api.GetAlUser().Result;
			var gmail = db.Where(x => x.UserGmail == myGmail).FirstOrDefault();

			if (gmail == null)
				return Json(false);
			else
			{
				var samepassword = db.Where(x => x.Password == myPassword).FirstOrDefault();
				if (samepassword != null)
					return Json(false);
				else
				{
					gmail.Password = myPassword;
					api.EditUserData(gmail);
				}
			}


			return Json(true);
		}

		[HttpPost]
		public IActionResult Master_Search_User(string Search)
		{

			var db = api.GetAlUser().Result;

			if (Search == null)
				return Json(db);
			else
			{

				var data = db.Where(x => x.UserName.ToLower().Contains(Search.ToLower())).ToList();

				if (data.Count() == 0)
					return Json(db);


				return Json(data);
			}
		}

		public IActionResult Master_Get_User()
		{
			var db = api.GetAlUser().Result;

			return Json(db);
		}

		public IActionResult Master_Get_All_Singer()
		{
			List<Singer> listsinger = api.GetAllSinger().Result;

			var data = from cd in listsinger
					   select new
					   {
						   SingerID = cd.SingerID,
						   SingerName = cd.SingerName,
						   SingerImage = cd.SingerImage,
						   SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
						   DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
					   };

			return Json(data);
		}

		[HttpPost]
		public IActionResult Master_Search_Singer(string Search)
		{

			var singerfollow = api.GetAllSinger().Result;

			if (Search == null)
			{

				var storedata1 = from cd in singerfollow
								 select new
								 {
									 SingerID = cd.SingerID,
									 SingerName = cd.SingerName,
									 SingerImage = cd.SingerImage,
									 SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
									 DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
								 };

				return Json(storedata1);
			}
			else
			{

				var storedata2 = (from cd in singerfollow
								  where cd.SingerName.ToLower().Contains(Search.ToLower())
								  select new
								  {
									  SingerID = cd.SingerID,
									  SingerName = cd.SingerName,
									  SingerImage = cd.SingerImage,
									  SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
									  DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
								  }).ToList();

				if (storedata2.Count() == 0)
				{

					var storedata3 = from cd in singerfollow
									 select new
									 {
										 SingerID = cd.SingerID,
										 SingerName = cd.SingerName,
										 SingerImage = cd.SingerImage,
										 SingerType = cd.SingerType == 0 ? "Orchestra" : "Individual",
										 DebutTime = cd.DebutTime.ToString("MM/dd/yyyy")
									 };

					return Json(storedata3);
				}

				return Json(storedata2);
			}
		}

		public IActionResult Get_Master_Music()
		{
			var musicdata = api.GetAlMusic().Result;
			var singerdata = api.GetAllSinger().Result;

			var data = (from cd in musicdata
						join singer in singerdata on cd.SingerID equals singer.SingerID
						select new
						{
							musicid = cd.MusicId,
							singername = singer.SingerName,
							songname = cd.SongName,
							songType = cd.SongType,
							songimg = cd.SongImg,
							songprice = cd.SongPrice,
							vip = cd.SongVIP == 0 ? "FREE" : "VIP"
						}).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult Master_Search_Music(string Search)
		{

			var musicdata = api.GetAlMusic().Result;
			var singerdata = api.GetAllSinger().Result;

			if (Search == null)
			{
				var storedata1 = (from cd in musicdata
								  join singer in singerdata on cd.SingerID equals singer.SingerID
								  select new
								  {
									  musicid = cd.MusicId,
									  singername = singer.SingerName,
									  songname = cd.SongName,
									  songType = cd.SongType,
									  songimg = cd.SongImg,
									  songprice = cd.SongPrice,
									  vip = cd.SongVIP == 0 ? "FREE" : "VIP"
								  }).ToList();

				return Json(storedata1);
			}
			else
			{

				var storedata2 = (from cd in musicdata
								  where cd.SongName.ToLower().Contains(Search.ToLower())
								  join singer in singerdata on cd.SingerID equals singer.SingerID
								  select new
								  {
									  musicid = cd.MusicId,
									  singername = singer.SingerName,
									  songname = cd.SongName,
									  songType = cd.SongType,
									  songimg = cd.SongImg,
									  songprice = cd.SongPrice,
									  vip = cd.SongVIP == 0 ? "FREE" : "VIP"
								  }).ToList();

				if (storedata2.Count() == 0)
				{

					var storedata3 = (from cd in musicdata
									  join singer in singerdata on cd.SingerID equals singer.SingerID
									  select new
									  {
										  musicid = cd.MusicId,
										  singername = singer.SingerName,
										  songname = cd.SongName,
										  songType = cd.SongType,
										  songimg = cd.SongImg,
										  songprice = cd.SongPrice,
										  vip = cd.SongVIP == 0 ? "FREE" : "VIP"
									  }).ToList();

					return Json(storedata3);
				}

				return Json(storedata2);
			}
		}

		public IActionResult Master_GetTr()
		{
			var trList = api.GetAllTransaction().Result;

			var data = (from cd in trList
						select new
						{
							id = cd.Id,
							PaidTime = cd.PaidTime.ToString("dddd, dd MMMM yyyy"),
							TransactionStatus = cd.TransactionStatus == 0 ? "Pending" : "Paid",
							CartIDList = cd.CartIDList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Count()
						}).OrderByDescending(x => x.id).ToList();

			return Json(data);
		}

		[HttpPost]
		public IActionResult GetSongtype(string songtype)
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (songtype == "All")
			{
				var data = (from cd in musicdata
							join singer in singerdata on cd.SingerID equals singer.SingerID
							select new
							{
								mid = cd.MusicId,
								SongName = cd.SongName,
								SongType = cd.SongType,
								SongImg = cd.SongImg,
								singer = singer.SingerName,
								ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
							}).ToList();
				return Json(data);
			}
			else
			{
				var data = (from cd in musicdata
							where cd.SongType.Contains(songtype)
							join singer in singerdata on cd.SingerID equals singer.SingerID
							select new
							{
								mid = cd.MusicId,
								SongName = cd.SongName,
								SongType = cd.SongType,
								SongImg = cd.SongImg,
								singer = singer.SingerName,
								ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
							}).ToList();
				return Json(data);
			}


			return Json(false);

		}

		[HttpPost]
		public IActionResult Music_Search_Input(string search, string choose)
		{
			var singerdata = api.GetAllSinger().Result;
			var musicdata = api.GetAlMusic().Result;
			if (search == null)
			{
				if (choose != "All")
				{
					var Notdata = (from cd in musicdata
								   where cd.SongType.Contains(choose)
								   join singer in singerdata on cd.SingerID equals singer.SingerID
								   select new
								   {
									   mid = cd.MusicId,
									   SongName = cd.SongName,
									   SongType = cd.SongType,
									   SongImg = cd.SongImg,
									   singer = singer.SingerName,
									   ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
								   }).ToList();
					return Json(Notdata);
				}
				else
				{
					var Notdata = (from cd in musicdata
								   join singer in singerdata on cd.SingerID equals singer.SingerID
								   select new
								   {
									   mid = cd.MusicId,
									   SongName = cd.SongName,
									   SongType = cd.SongType,
									   SongImg = cd.SongImg,
									   singer = singer.SingerName,
									   ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
								   }).ToList();
					return Json(Notdata);
				}
			}
			else
			{
				int count = 0;
				if (choose != "All")
				{
					var Havedata = (from cd in musicdata
									where cd.SongType.Contains(choose) && cd.SongName.ToLower().Contains(search.ToLower())
									join singer in singerdata on cd.SingerID equals singer.SingerID
									select new
									{
										mid = cd.MusicId,
										SongName = cd.SongName,
										SongType = cd.SongType,
										SongImg = cd.SongImg,
										singer = singer.SingerName,
										ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
									}).ToList();

					count = Havedata.Count;
					if (count != 0)
						return Json(Havedata);
				}
				else
				{
					var Havedata = (from cd in musicdata
									where cd.SongName.ToLower().Contains(search.ToLower())
									join singer in singerdata on cd.SingerID equals singer.SingerID
									select new
									{
										mid = cd.MusicId,
										SongName = cd.SongName,
										SongType = cd.SongType,
										SongImg = cd.SongImg,
										singer = singer.SingerName,
										ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
									}).ToList();
					count = Havedata.Count;
					if (count != 0)
						return Json(Havedata);
				}

				if (count == 0)
				{

					if (choose != "All")
					{
						var Notdata = (from cd in musicdata
									   where cd.SongType.Contains(choose)
									   join singer in singerdata on cd.SingerID equals singer.SingerID
									   select new
									   {
										   mid = cd.MusicId,
										   SongName = cd.SongName,
										   SongType = cd.SongType,
										   SongImg = cd.SongImg,
										   singer = singer.SingerName,
										   ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
									   }).ToList();
						return Json(Notdata);
					}
					else
					{
						var Notdata = (from cd in musicdata
									   join singer in singerdata on cd.SingerID equals singer.SingerID
									   select new
									   {
										   mid = cd.MusicId,
										   SongName = cd.SongName,
										   SongType = cd.SongType,
										   SongImg = cd.SongImg,
										   singer = singer.SingerName,
										   ispaid = cd.SongVIP == 0 ? "FREE" : "VIP"
									   }).ToList();
						return Json(Notdata);
					}
				}

				return Json(false);

			}

		}











	}
}