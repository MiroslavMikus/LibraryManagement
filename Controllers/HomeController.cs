using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository, IAuthorRepository authorRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                CustomersCount = _customerRepository.Count(x => true),
                AuthorsCount = _authorRepository.Count(x => true),
                BooksCount = _bookRepository.Count(x => true),
                LendedBooksCount = _bookRepository.Count(x => x.Borrower != null)
            };

            return View(homeVM);
        }
    }
}
