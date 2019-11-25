using System.Linq;
using App;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test
{
    public class Test
    {
        [Fact]
        public void Foo()
        {
            string cs = Program.ConnectionString;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(cs, options => options.MigrationsAssembly(typeof(Program).Assembly.FullName));

            using var db = new DataContext(builder.Options);

            db.Database.Migrate();

            db.Entities.Add(new Entity()
            {
                Name = "test",
            });

            db.SaveChanges();

            Assert.Equal("test", db.Entities.First().Name);
        }

        [Fact]
        public void Bar()
        {
            string cs = Program.ConnectionString;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(cs, options => options.MigrationsAssembly(typeof(Program).Assembly.FullName));

            using var db = new DataContext(builder.Options);

            db.Database.Migrate();

            db.Entities.Add(new Entity()
            {
                Name = "test",
            });

            db.SaveChanges();

            Assert.Equal("test123", db.Entities.First().Name);
        }
    }
}
