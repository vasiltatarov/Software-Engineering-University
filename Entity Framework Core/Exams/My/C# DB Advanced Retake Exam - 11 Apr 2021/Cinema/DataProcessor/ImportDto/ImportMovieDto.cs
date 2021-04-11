using System.ComponentModel.DataAnnotations;
using Cinema.Data.Models.Enums;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMovieDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public Genre? Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }
    }
}
