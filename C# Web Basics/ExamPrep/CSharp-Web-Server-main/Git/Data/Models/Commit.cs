using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    using static DataConstants;

    public class Commit
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
        
        [Required]
        public string RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
    }
}
