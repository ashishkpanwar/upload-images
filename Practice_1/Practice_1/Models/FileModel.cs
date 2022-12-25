using System;
using Microsoft.AspNetCore.Http;
namespace Practice_1.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
