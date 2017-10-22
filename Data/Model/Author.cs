using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}