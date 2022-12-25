using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Practice_1.Models;
using System.IO;
using WebApi.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Practice_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {

        private readonly ILogger<FilesController> _logger;
        private readonly DataContext _context;
        protected readonly IConfiguration Configuration;
        public FilesController(ILogger<FilesController> logger, DataContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
            
        }

        [HttpGet(Name = "GetFiles")]
        public async Task<IActionResult> Get()
        {
            var images = _context.Images.ToList();
            return Ok(images);
        }
        [HttpPost(Name = "PostFiles")]
        public async Task<IActionResult> Save([FromForm] FileModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var fileName = model.FileName;
                var folderName = Path.Combine("pratice_one_fe", "src/assets");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                using (var fileStream = new FileStream(Path.Combine(pathToSave, model.File.FileName), FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }
                var con = new SqliteConnection(Configuration.GetConnectionString("WebApiDatabase"));
                await con.OpenAsync();
                SqliteCommand command = new SqliteCommand("CREATE TABLE IF NOT EXISTS Images([FilesId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [FileName] NVARCHAR(100) NOT NULL, [Path] NVARCHAR(128) NOT NULL)", con);
                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
                var Image = new Image
                {
                    FileName = model.FileName,
                    Path = model.File.FileName
                };
                await _context.Images.AddAsync(Image);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return BadRequest();
        }
    }
}