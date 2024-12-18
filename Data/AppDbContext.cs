// Data/AppDbContext.cs
using GestaoUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoUsuario.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
