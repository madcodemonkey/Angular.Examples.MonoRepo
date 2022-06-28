using Acme.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.Repositories
{
    public class AcmeContext : DbContext
    {
        /// <summary>Constructor</summary>
        public AcmeContext(DbContextOptions<AcmeContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}