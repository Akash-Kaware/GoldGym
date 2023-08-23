namespace GoldGym.Repository
{
    using Dapper;
    using GoldGym.Data;
    using GoldGym.Models;

    public class PaymentRepository : IPaymentRepository
    {
        private readonly SqlDbConnection _connection;

        public PaymentRepository(SqlDbConnection connection)
        {
            _connection = connection;
        }
        public Task<bool> CreatePayment(Payment payment)
        {
            var parameters = payment.ToDynamicParameters();
            parameters.Add("CreatedBy", payment.CreatedBy);
            return _connection.ExecuteQueryAsync("[gold].[Payment_Create]", parameters);
        }

        public Task<bool> DeletePayment(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            return _connection.ExecuteQueryAsync("[gold].[Payment_Delete]", parameters);
        }

        public async Task<IList<Payment>> GetAllPayments()
        {
            return await _connection.GetAll<Payment>("[gold].[Payment_GetAll]");
        }

        public async Task<IList<Payment>> GetPaymentsByCustomerId(Guid customerId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);
            return await _connection.GetById<Payment>("[gold].[Payment_GetByCustomerId]", parameters);
        }

        public Task<bool> UpdatePayment(Payment payment)
        {
            var parameters = payment.ToDynamicParameters();
            parameters.Add("UpdatedBy", payment.UpdatedBy);
            return _connection.ExecuteQueryAsync("[gold].[Payment_Update]", parameters);
        }

        public async Task<CustomerPaymentViewModel> GetExpiringCustomers(int? paymentReminderDays)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PaymentReminderDays", paymentReminderDays);
            var result = await _connection.ExecuteMultipleAsync<Customer, Payment>("[gold].[Customer_ExpiringPkg]", parameters);
            return new CustomerPaymentViewModel() { Customers = result.Item1, Payments = result.Item2 };
        }
    }
}
