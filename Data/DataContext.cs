using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
      
    }

    public DbSet<Livro> TB_LIVROS { get; set; }
    public DbSet<Serie> TB_SERIES { get; set; }
    
  }
}