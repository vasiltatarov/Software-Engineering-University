using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data.Models
{
    using static DataConstants;

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CardMaxName)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(CardMaxDescription)]
        public string Description { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; } = new HashSet<UserCard>();
    }
}
