using Mapster;

using Microsoft.EntityFrameworkCore;

using System;

namespace AspNetCoreAndMapster.Models;

public class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasKey(i => i.Id);
    }
}
