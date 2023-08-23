namespace GoldGym.Controllers
{
    using GoldGym.Data;
    using GoldGym.Models;
    using GoldGym.Repository;
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var result = await _customerRepository.GetAllCustomers();
            var genders = GoldStaticUtility.GetGenderList();
            foreach (var item in result)
            {
                item.Gender = genders.First(g => g.Value == item.Gender.Trim()).Text;
            }
            return View(result);
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await _customerRepository.GetCustomerById(id);
            return View(result);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.Genders = GoldStaticUtility.GetGenderList();
            return View(new Customer() { Id = Guid.NewGuid() });
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
        {
            try
            {
                _customerRepository.CreateCustomer(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _customerRepository.GetCustomerById(id);
            ViewBag.Genders = GoldStaticUtility.GetGenderList(result.Gender);
            return View(result);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer model)
        {
            try
            {
                _customerRepository.UpdateCustomer(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _customerRepository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
