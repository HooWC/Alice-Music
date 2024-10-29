using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alice_DomainModelEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Alice_Infrastructure
{
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Music> Musics { get; set; } = null!;
		public DbSet<Video> Videos { get; set; } = null!;
		public DbSet<Singer> Singers { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Comment> Comments { get; set; } = null!;
		public DbSet<SingerStore> SingerStores { get; set; } = null!;
		public DbSet<VideoStore> VideoStores { get; set; } = null!;
		public DbSet<Transaction> Transactions { get; set; } = null!;
		public DbSet<Cart> Carts { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=LAPTOP-75SCS0RS\\SQLEXPRESS;Database=AliceMusic;Trusted_Connection=True;TrustServerCertificate=true");
			}

		}
	}
}
