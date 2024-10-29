using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;
using Newtonsoft.Json;

namespace Alice_Infrastructure.Repository.Api
{
	public class API
	{
		const string baseUrl = "http://localhost:5181/";
		HttpClient httpclient = new HttpClient();

		//Singer
		public async Task<List<Singer>> GetAllSinger()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllSinger/");
			return JsonConvert.DeserializeObject<List<Singer>>(jsonStr);
		}

		public async Task<Singer> FindSingerData(int id)
		{
			var jsonString = await httpclient.GetStringAsync(baseUrl + "GetSinger/" + id);
			return JsonConvert.DeserializeObject<Singer>(jsonString);
		}

		public void EditSingerData(Singer singer)
		{
			var jsonstring = new StringContent(JsonConvert.SerializeObject(singer), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditSinger/" + singer.SingerID, jsonstring);
		}

		public void DeleteSingerID(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteSinger/" + id);
		}

		public async void MusicCreateData(Singer singer)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(singer), Encoding.UTF8, "application/json");
			await httpclient.PostAsync(baseUrl + "CreateSinger/", stringContent);
		}

		//Music
		public async Task<List<Music>> GetAlMusic()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllMusic/");
			return JsonConvert.DeserializeObject<List<Music>>(jsonStr);
		}

		public async Task<Music> FindMusicData(int id)
		{
			var jsonString = await httpclient.GetStringAsync(baseUrl + "GetMusic/" + id);
			return JsonConvert.DeserializeObject<Music>(jsonString);
		}

		public void EditMusicData(Music music)
		{
			var jsonstring = new StringContent(JsonConvert.SerializeObject(music), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditMusic/" + music.MusicId, jsonstring);
		}

		public void DeleteMusicID(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteMusic/" + id);
		}

		public void MusicCreateData(Music music)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(music), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateMusic/", stringContent);
		}

		//User
		public async Task<List<User>> GetAlUser()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllUser/");
			return JsonConvert.DeserializeObject<List<User>>(jsonStr);
		}

		public async void UserCreateData(User user)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			await httpclient.PostAsync(baseUrl + "CreateUser/", stringContent);
		}

		public void EditUserData(User user)
		{
			var jsonstring = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditUser/" + user.UserID, jsonstring);
		}

		public void DeleteUserID(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteUser/" + id);
		}

		//Video
		public async Task<List<Video>> GetAllVideo()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllVideo/");
			return JsonConvert.DeserializeObject<List<Video>>(jsonStr);
		}

		public async Task<Video> FindVideoData(int id)
		{
			var jsonString = await httpclient.GetStringAsync(baseUrl + "GetVideo/" + id);
			return JsonConvert.DeserializeObject<Video>(jsonString);
		}

		public void EditVideoData(Video video)
		{
			var jsonstring = new StringContent(JsonConvert.SerializeObject(video), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditVideo/" + video.VideoId, jsonstring);
		}

		public void DeleteVideoID(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteVideo/" + id);
		}

		public void MusicCreateData(Video video)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(video), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateVideo/", stringContent);
		}

		//Comment
		public async Task<List<Comment>> GetAlComment()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllComment/");
			return JsonConvert.DeserializeObject<List<Comment>>(jsonStr);
		}

		public void CommentCreateData(Comment comment)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateComment/", stringContent);
		}

		//SingerStore
		public async Task<List<SingerStore>> GetAllSingerStore()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllSingerStore/");
			return JsonConvert.DeserializeObject<List<SingerStore>>(jsonStr);
		}

		public void SingerStoreCreateData(SingerStore singerStore)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(singerStore), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateSingerStore/", stringContent);
		}

		public void DeleteSingerStoreID(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteSingerStore/" + id);
		}

		//VideoStore
		public async Task<List<VideoStore>> GetAllVideoStore()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllVideoStore/");
			return JsonConvert.DeserializeObject<List<VideoStore>>(jsonStr);
		}

		public void VideoStoreCreateData(VideoStore videoStore)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(videoStore), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateVideoStore/", stringContent);
		}

		public void DeleteVideoStore(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteVideoStore/" + id);
		}

		//Cart
		public async Task<List<Cart>> GetAllCart()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllCart/");
			return JsonConvert.DeserializeObject<List<Cart>>(jsonStr);
		}

		public void CartCreateData(Cart cart)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateCart/", stringContent);
		}

		public void EditCartData(Cart cart)
		{
			var jsonString = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditCart/" + cart.CartID, jsonString);
		}

		public void DeleteCart(int id)
		{
			httpclient.DeleteAsync(baseUrl + "DeleteCart/" + id);
		}

		public async Task<Cart> FindCartData(int id)
		{
			var jsonString = await httpclient.GetStringAsync(baseUrl + "GetCart/" + id);
			return JsonConvert.DeserializeObject<Cart>(jsonString);
		}

		//Transaction
		public async Task<List<Transaction>> GetAllTransaction()
		{
			var jsonStr = await httpclient.GetStringAsync(baseUrl + "GetAllTransaction/");
			return JsonConvert.DeserializeObject<List<Transaction>>(jsonStr);
		}

		public void TransactionCreateData(Transaction tr)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(tr), Encoding.UTF8, "application/json");
			httpclient.PostAsync(baseUrl + "CreateTransaction/", stringContent);
		}

		public void EditTransactionData(Transaction tr)
		{
			var jsonString = new StringContent(JsonConvert.SerializeObject(tr), Encoding.UTF8, "application/json");
			httpclient.PutAsync(baseUrl + "EditTransaction/" + tr.Id, jsonString);
		}

		public async Task<Transaction> FindTransactionData(int id)
		{
			var jsonString = await httpclient.GetStringAsync(baseUrl + "GetTransaction/" + id);
			return JsonConvert.DeserializeObject<Transaction>(jsonString);
		}


	}
}
