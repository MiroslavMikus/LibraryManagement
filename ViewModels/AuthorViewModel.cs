using LibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class AuthorViewModel
    {
        public Author Author { get; set; }
        public int? BookCount { get; set; }
    }
}
