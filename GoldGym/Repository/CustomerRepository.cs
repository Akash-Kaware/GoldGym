namespace GoldGym.Repository
{
    using Dapper;
    using GoldGym.Data;
    using GoldGym.Models;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDbConnection _connection;
        public CustomerRepository(SqlDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            return await _connection.GetAll<Customer>("[gold].[Customer_GetAll]");
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            var result = await _connection.GetById<Customer>("[gold].[Customer_GetById]", parameters);
            return result.FirstOrDefault();
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            var parameters = customer.ToDynamicParameters();
            parameters.Add("CreatedBy", customer.CreatedBy);
            parameters.Add("IsActive", true);
            return await _connection.ExecuteQueryAsync("[gold].[Customer_Create]", parameters);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var parameters = customer.ToDynamicParameters();
            parameters.Add("UpdatedBy", customer.UpdatedBy);
            return await _connection.ExecuteQueryAsync("[gold].[Customer_Update]", parameters);
        }

        public async Task<bool> DeleteCustomer(Guid id, Guid userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("UpdatedBy", userId);
            return await _connection.ExecuteQueryAsync("[gold].[Customer_Delete]", parameters);
        }
    }
}
