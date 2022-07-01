using databeses.Entities;
using Microsoft.EntityFrameworkCore;

namespace databeses.Data;

public class AppDbContext: DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
  public DbSet<Movie>? Movies { get; set; }
}