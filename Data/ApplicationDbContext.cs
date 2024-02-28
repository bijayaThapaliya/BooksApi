using Microsoft.EntityFrameworkCore;
using TheBookApp.Models;

namespace TheBookApp;

public class ApplicationDbContext:DbContext
{
    // private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration):base(options)
    // {
    //     _configuration = configuration;
    // }

    public DbSet<Book> Books {get; set;}
    public DbSet<Publisher> Publishers {get; set;}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // base.OnConfiguring(optionsBuilder);
    //     if(!optionsBuilder.IsConfigured){
    //         optionsBuilder.UseSqlite(_configuration.GetConnectionString("DbConnection"));
    //     }
    // }
}
