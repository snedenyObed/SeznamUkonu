using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeznamUkonu.Models;

namespace SeznamUkonu.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<SeznamUkonu.Models.SeznamCinnosti>? SeznamCinnosti { get; set; }
	}
}