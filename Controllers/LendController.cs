using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModels;
using LibraryManagement.Data.Model;

namespace LibraryManagement.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult List()
        {
            Func<Book, bool> myFilter = x => x.BorrowerId == 0;

            // check collection
            if (!_bookRepository.Any(myFilter))
            {
                return View("Empty");
            }

            // load all available books
            var availableBooks = _bookRepository.FindWithAuthor(myFilter);

            return View(availableBooks);
        }


        public IActionResult LendBook(int bookId)
        {
            var lendVM = new LendViewModel
            {
                Book = _bookRepository.GetById(bookId),
                Customers = _customerRepository.GetAll()
            };

            return View(lendVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LendBook(LendViewModel lendVM)
        {
            var book = _bookRepository.GetById(lendVM.Book.BookId);

            book.BorrowerId = lendVM.Book.BorrowerId;

            _bookRepository.Update(book);

            return RedirectToAction("List");
        }
    }
}
