using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class GiveBackController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public GiveBackController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult List()
        {
            var lendedBooks = _bookRepository.FindWithAuthorAndLender(x => x.BorrowerId != 0);

            if (lendedBooks == null || lendedBooks.ToList().Count() == 0)
            {
                return View("Empty");
            }

            return View(lendedBooks);
        }

        public IActionResult GiveBack(int bookId)
        {
            var book = _bookRepository.GetById(bookId);

            book.Borrower = null;

            book.BorrowerId = 0;

            _bookRepository.Update(book);

            return RedirectToAction("List");
        }
    }
}
