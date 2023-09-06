namespace GoldGym.Controllers
{
    using GoldGym.Data;
    using GoldGym.Models;
    using GoldGym.Repository;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly MyConfiguration _configuration;

        public PaymentController(ICustomerRepository customerRepository,
            IPaymentRepository paymentRepository,
            MyConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _paymentRepository.GetExpiringCustomers(_configuration.PaymentReminderDays);
            return View(result);
        }

        public async Task<IActionResult> Create(Guid id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            customer.Gender = GoldStaticUtility.GetGenderList().First(g => g.Value == customer.Gender.Trim()).Text;
            ViewBag.Payments = await _paymentRepository.GetPaymentsByCustomerId(customer.Id);
            var payment = new Payment()
            {
                CustomerId = customer.Id,
                Customer = customer
            };
            return View(payment);
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Payment model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                model.PaymentDate = DateTime.Now;
                model.CreatedBy = this.GetLoggedInUserId();
                await _paymentRepository.CreatePayment(model);
                return RedirectToAction(nameof(Create), new { id = model.CustomerId });
            }
            catch
            {
                return View();
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Guid customerId)
        {
            try
            {
                await _paymentRepository.DeletePayment(id);
                return RedirectToAction(nameof(Create), new { id = customerId });
            }
            catch
            {
                return View();
            }
        }
    }
}
