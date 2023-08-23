namespace GoldGym.Repository
{
    using GoldGym.Models;

    public interface ICustomerRepository
    {
        Task<IList<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task<bool> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Guid id);
    }
}
