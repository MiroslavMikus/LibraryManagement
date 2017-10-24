using LibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class CreateAuthorViewModel
    {
        [Required]
        public Author Author { get; set; }
        public string Referer { get; set; }
    }
}
