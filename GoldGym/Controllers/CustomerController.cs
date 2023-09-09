namespace GoldGym.Controllers
{
    using GoldGym.Data;
    using GoldGym.Models;
    using GoldGym.Repository;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(IWebHostEnvironment webHostEnvironment,
            ICustomerRepository customerRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _customerRepository = customerRepository;
        }

        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var result = await _customerRepository.GetAllCustomers();
            var genders = GoldStaticUtility.GetGenderList();
            foreach (var item in result)
            {
                item.Gender = genders.FirstOrDefault(g => g.Value == item.Gender?.Trim())?.Text;
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
        public async Task<ActionResult> Create(Customer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = model.Id.ToString() + "_" + model.Name?.Replace(" ", "_");
                    model.Photo = ImageUploadUtil.UploadedFile(_webHostEnvironment.WebRootPath, model.ProfileImage, uniqueFileName);
                    model.CreatedBy = this.GetLoggedInUserId();
                    await _customerRepository.CreateCustomer(model);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Genders = GoldStaticUtility.GetGenderList(model.Gender);
                return View(model);
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
        public async Task<ActionResult> Edit(Customer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer existingDetails = await _customerRepository.GetCustomerById(model.Id);
                    if (existingDetails == null)
                    {
                        return View(model);
                    }
                    if (model.ProfileImage != null)
                    {
                        ImageUploadUtil.DeleteFile(_webHostEnvironment.WebRootPath, existingDetails.Photo);
                        string uniqueFileName = model.Id.ToString() + "_" + model.Name?.Replace(" ", "_");
                        model.Photo = ImageUploadUtil.UploadedFile(_webHostEnvironment.WebRootPath, model.ProfileImage, uniqueFileName);
                    }
                    else
                    {
                        model.Photo = existingDetails.Photo;
                    }
                    model.UpdatedBy = this.GetLoggedInUserId();
                    await _customerRepository.UpdateCustomer(model);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Genders = GoldStaticUtility.GetGenderList(model.Gender);
                return View(model);
            }
            catch (Exception ex)
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
                await _customerRepository.DeleteCustomer(id, this.GetLoggedInUserId());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
