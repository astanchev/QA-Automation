namespace Library.Models
{
    using System.Collections.Generic;

    public class Wishlist
    {
        public Wishlist()
        {
            Books = new List<Book>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books {get;set;}
    }
}