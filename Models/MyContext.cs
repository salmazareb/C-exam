using Microsoft.EntityFrameworkCore;

namespace Finalexam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options):base(options){}

        public DbSet<User> Users { get; set; }
         public DbSet<Hobby> Hobbies { get; set; }

         public DbSet<Relation> Relationes { get; set; }
    }
}