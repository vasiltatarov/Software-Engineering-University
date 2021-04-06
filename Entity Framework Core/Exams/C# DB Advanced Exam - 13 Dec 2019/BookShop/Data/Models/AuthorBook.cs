namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}