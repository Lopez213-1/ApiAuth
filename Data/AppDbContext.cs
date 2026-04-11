using Microsoft.EntityFrameworkCore;
using TaskApi.Models;
using TaskApi.Modesl;
namespace TaskApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}