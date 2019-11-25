using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string cs = Program.ConnectionString;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(cs, options => options.MigrationsAssembly(typeof(Program).Assembly.FullName));
            return new DataContext(builder.Options);
        }
    }
}
