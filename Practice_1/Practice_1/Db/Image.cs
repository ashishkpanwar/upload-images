using System.ComponentModel.DataAnnotations;

namespace Practice_1
{
    public class Image
    {
        [Key]
        public int FilesId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

    }
}
