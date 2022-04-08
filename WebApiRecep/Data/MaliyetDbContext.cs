using Microsoft.EntityFrameworkCore;
using WebApiRecep.Entities.MaliyetEntity;

namespace WebApiRecep.Data
{
    public class MaliyetDbContext : DbContext
    {
       public MaliyetDbContext()
        {

        }

        public MaliyetDbContext(DbContextOptions<MaliyetDbContext> options) : base(options)
        {

        }

        public DbSet<AlisTipi>? AlisTipis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlisTipi>().HasKey(x => x.Id);
        }
    }



}



