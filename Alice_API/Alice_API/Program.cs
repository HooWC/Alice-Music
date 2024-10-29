using System.Text;
using Alice_DomainModelEntity.Models;
using Alice_Infrastructure;
using Alice_Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("AliceMusic")));

builder.Services.AddScoped<MusicRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<VideoRepository>();
builder.Services.AddScoped<SingerRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<SingerStoreRepository>();
builder.Services.AddScoped<VideoStoreRepository>();
builder.Services.AddScoped<CartRepository>();
builder.Services.AddScoped<TransactionRepository>();

var app = builder.Build();



//Music
app.MapGet("/GetAllMusic/", ([FromServices] MusicRepository repos) =>
{
	var s = repos.GetAllMusic();
	return s;
});

app.MapGet("/GetMusic/{id}", async (int id, [FromServices] MusicRepository repos) =>
{
	var music = await repos.GetMusic(id);
	return music is not null ? Results.Ok(music) : Results.NotFound();
});

app.MapPut("/EditMusic/{id}", (int id, Music music, [FromServices] MusicRepository repos) =>
{
	if (id != music.MusicId)
		return Results.BadRequest();

	repos.UpdateMusic(music);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteMusic/{id}", (int id, [FromServices] MusicRepository repos) =>
{
	repos.DeleteMusicAsync(id);
	return Results.Ok("Delete Successful");
});

app.MapPost("/CreateMusic/", (Music music, [FromServices] MusicRepository repos) =>
{
	repos.CreateMusic(music);
	return Results.Created($"/CreateMusic/", music);
});

//User
app.MapGet("/GetAllUser/", ([FromServices] UserRepository repos) =>
{
	return repos.GetAllUser();
});

app.MapGet("/GetUser/{id}", async (int id, [FromServices] UserRepository repos) =>
{
	var user = await repos.GetUser(id);
	return user is not null ? Results.Ok(user) : Results.NotFound();
});

app.MapPost("/CreateUser/", (User user, [FromServices] UserRepository repos) =>
{
	repos.CreateUser(user);
	return Results.Created($"/CreateUser/", user);
});

app.MapPut("/EditUser/{id}", (int id, User user, [FromServices] UserRepository repos) =>
{
	if (id != user.UserID)
		return Results.BadRequest();

	repos.UpdateUser(user);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteUser/{id}", (int id, [FromServices] UserRepository repos) =>
{
	repos.DeleteUserAsync(id);
	return Results.Ok("Delete Successful");
});

//Video
app.MapGet("/GetAllVideo/", ([FromServices] VideoRepository repos) =>
{
	return repos.GetAllVideo();
});

app.MapGet("/GetVideo/{id}", async (int id, [FromServices] VideoRepository repos) =>
{
	var video = await repos.GetVideo(id);
	return video is not null ? Results.Ok(video) : Results.NotFound();
});

app.MapPut("/EditVideo/{id}", (int id, Video video, [FromServices] VideoRepository repos) =>
{
	if (id != video.VideoId)
		return Results.BadRequest();

	repos.UpdateVideo(video);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteVideo/{id}", (int id, [FromServices] VideoRepository repos) =>
{
	repos.DeleteVideoAsync(id);
	return Results.Ok("Delete Successful");
});

app.MapPost("/CreateVideo/", (Video video, [FromServices] VideoRepository repos) =>
{
	repos.CreateVideo(video);
	return Results.Created($"/CreateVideo/", video);
});

//Singer
app.MapGet("/GetAllSinger/", ([FromServices] SingerRepository repos) =>
{
	return repos.GetAllSinger();
});

app.MapGet("/GetSinger/{id}", async (int id, [FromServices] SingerRepository repos) =>
{
	var video = await repos.GetSinger(id);
	return video is not null ? Results.Ok(video) : Results.NotFound();
});

app.MapPut("/EditSinger/{id}", (int id, Singer singer, [FromServices] SingerRepository repos) =>
{
	if (id != singer.SingerID)
		return Results.BadRequest();

	repos.UpdateSinger(singer);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteSinger/{id}", (int id, [FromServices] SingerRepository repos) =>
{
	repos.DeleteSingerAsync(id);
	return Results.Ok("Delete Successful");
});

app.MapPost("/CreateSinger/", (Singer singer, [FromServices] SingerRepository repos) =>
{
	repos.CreateSinger(singer);
	return Results.Created($"/CreateSinger/", singer);
});

//Comment
app.MapGet("/GetAllComment/", ([FromServices] CommentRepository repos) =>
{
	return repos.GetAllComment();
});

app.MapPost("/CreateComment/", (Comment comment, [FromServices] CommentRepository repos) =>
{
	repos.CreateComment(comment);
	return Results.Created($"/CreateComment/", comment);
});

//SingerStore
app.MapGet("/GetAllSingerStore/", ([FromServices] SingerStoreRepository repos) =>
{
	return repos.GetAllSingerStore();
});

app.MapPost("/CreateSingerStore/", (SingerStore singerStore, [FromServices] SingerStoreRepository repos) =>
{
	repos.CreateSingerStore(singerStore);
	return Results.Created($"/CreateSingerStore/", singerStore);
});

app.MapDelete("/DeleteSingerStore/{id}", (int id, [FromServices] SingerStoreRepository repos) =>
{
	repos.DeleteSingerStoreAsync(id);
	return Results.Ok("Delete Successful");
});

//VideoStore
app.MapGet("/GetAllVideoStore/", ([FromServices] VideoStoreRepository repos) =>
{
	return repos.GetAllVideoStore();
});

app.MapPost("/CreateVideoStore/", (VideoStore videoStore, [FromServices] VideoStoreRepository repos) =>
{
	repos.CreateVideoStore(videoStore);
	return Results.Created($"/CreateVideoStore/", videoStore);
});

app.MapDelete("/DeleteVideoStore/{id}", (int id, [FromServices] VideoStoreRepository repos) =>
{
	repos.DeleteVideoStoreAsync(id);
	return Results.Ok("Delete Successful");
});

//Cart
app.MapGet("/GetAllCart/", ([FromServices] CartRepository repos) =>
{
	return repos.GetAllCart();
});

app.MapPost("/CreateCart/", (Cart cart, [FromServices] CartRepository repos) =>
{
	repos.CreateCart(cart);
	return Results.Created($"/CreateCart/", cart);
});

app.MapPut("/EditCart/{id}", (int id, Cart cart, [FromServices] CartRepository repos) =>
{
	if (id != cart.CartID)
		return Results.BadRequest();

	repos.UpdateCart(cart);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteCart/{id}", (int id, [FromServices] CartRepository repos) =>
{
	repos.DeleteCart(id);
	return Results.Ok("Delete Successful");
});

app.MapGet("/GetCart/{id}", async (int id, [FromServices] CartRepository repos) =>
{
	var cart = await repos.GetCart(id);
	return cart is not null ? Results.Ok(cart) : Results.NotFound();
});

//Transaction
app.MapGet("/GetAllTransaction/", ([FromServices] TransactionRepository repos) =>
{
	return repos.GetAllTransaction();
});

app.MapPost("/CreateTransaction/", (Transaction tr, [FromServices] TransactionRepository repos) =>
{
	repos.CreateTransaction(tr);
	return Results.Created($"/CreateVideoStore/", tr);
});

app.MapPut("/EditTransaction/{id}", (int id, Transaction tr, [FromServices] TransactionRepository repos) =>
{
	if (id != tr.Id)
		return Results.BadRequest();

	repos.UpdateTransaction(tr);
	return Results.Ok("Update Successful");
});

app.MapDelete("/DeleteTransaction/{id}", (int id, [FromServices] TransactionRepository repos) =>
{
	repos.DeleteTransactionAsync(id);
	return Results.Ok("Delete Successful");
});

app.MapGet("/GetTransaction/{id}", async (int id, [FromServices] TransactionRepository repos) =>
{
	var tr = await repos.GetTransaction(id);
	return tr is not null ? Results.Ok(tr) : Results.NotFound();
});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
