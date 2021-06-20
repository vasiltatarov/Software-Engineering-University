using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Data.Models
{
    using static DataConstants;

    public class Receipt
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
