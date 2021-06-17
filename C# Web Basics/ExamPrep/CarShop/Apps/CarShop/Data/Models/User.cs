using SUS.MvcFramework;

namespace CarShop.Data.Models
{
    public class User : IdentityUser<string>
    {
        public bool IsMechanic { get; set; }
    }
}
