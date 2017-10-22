using LibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}
