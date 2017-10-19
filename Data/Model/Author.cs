using System.Collections;
using System.Collections.Generic;

namespace LibraryManagement.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}