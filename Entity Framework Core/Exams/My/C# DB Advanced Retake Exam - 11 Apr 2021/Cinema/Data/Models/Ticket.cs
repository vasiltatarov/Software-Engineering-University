using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }
    }
}
