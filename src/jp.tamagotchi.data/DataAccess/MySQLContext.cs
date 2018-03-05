using jp.tamagotchi.data.Entities;

using Microsoft.EntityFrameworkCore;

namespace jp.tamagotchi.data.DataAccess
{

    public class MySQLContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Developer> Developer { get; set; }

        public MySQLContext(DbContextOptions opts) : base(opts) => Database.EnsureCreated();

    }

}