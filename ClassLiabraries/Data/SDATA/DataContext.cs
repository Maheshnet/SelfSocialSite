using Microsoft.EntityFrameworkCore;
using SDomain;

namespace SDATA
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                new Value { ID = 1, Name = "Value 101" },
                new Value { ID = 2, Name = "Value 102" },
                new Value { ID = 3, Name = "Value 103" },
                new Value { ID = 4, Name = "Value 104" },
                new Value { ID = 5, Name = "Value 105" }
                );
        }
    }
}
