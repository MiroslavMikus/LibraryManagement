using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class HomeViewModel
    {
        public int CustomersCount { get; set; }
        public int AuthorsCount { get; set; }
        public int BooksCount { get; set; }
        public int LendedBooksCount { get; set; }
    }
}
