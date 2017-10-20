using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            var customers = _repository.GetAll();
            return View(customers);
        }

        public IActionResult Detail(int id)
        {
            Customer customer = _repository.GetById(id);

            if (customer == null)
            {
                ModelState.AddModelError("", "Customer doesnt exist");
                return List();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _repository.Update(customer);

            var customers = _repository.GetAll();

            return View("List", customers);
        }
    }
}
