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

        public DbSet<Country> Counties { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}