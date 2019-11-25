using System;
using Microsoft.EntityFrameworkCore;

namespace App
{

    public class Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Entity> Entities { get; set; }
    }
}
