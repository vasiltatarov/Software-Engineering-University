using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Za-z0-9]+$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        [Required]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }

}
