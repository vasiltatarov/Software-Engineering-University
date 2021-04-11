using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Range(12, 110)]
        public int Age { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
