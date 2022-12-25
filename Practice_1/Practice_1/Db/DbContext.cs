namespace WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Practice_1;
using static System.Net.Mime.MediaTypeNames;
using Image = Practice_1.Image;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;
    private static bool _created = false;

    public DataContext(IConfiguration configuration)
    {
        if (!_created)
        {
            _created = true;
            Database.EnsureDeleted();
        }
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Image> Images { get; set; }
}