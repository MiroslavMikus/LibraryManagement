using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using LibraryManagement.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            if(!_repository.Any()) return View("Empty");

            List<CustomerViewModel> customerVM = new List<CustomerViewModel>();

            var customers = _repository.GetAll();

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Find(x => x.BorrowerId == customer.CustomerId).Count()

                });
            }

            return View(customerVM);
        }

        public IActionResult Update(int id)
        {
            Customer customer = _repository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _repository.Update(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _repository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var customer = _repository.GetById(id);

            _repository.Delete(customer);

            return RedirectToAction("List");
        }
    }
}
