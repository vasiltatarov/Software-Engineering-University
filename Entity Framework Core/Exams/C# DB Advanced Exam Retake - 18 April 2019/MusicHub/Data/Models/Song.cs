using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public int WriterId { get; set; }

        public virtual Writer Writer { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
