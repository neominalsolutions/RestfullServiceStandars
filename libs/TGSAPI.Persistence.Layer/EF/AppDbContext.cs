using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Persistence.Layer.EF
{
  public class AppDbContext : DbContext
  {

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }



    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=TGSDB;Integrated Security=True;TrustServerCertificate=True");

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
