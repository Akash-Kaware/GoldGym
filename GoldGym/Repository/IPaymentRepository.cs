namespace GoldGym.Repository
{
    using GoldGym.Models;
    public interface IPaymentRepository
    {
        Task<IList<Payment>> GetAllPayments();
        Task<IList<Payment>> GetPaymentsByCustomerId(Guid id);
        Task<bool> CreatePayment(Payment payment);
        Task<bool> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(Guid id);
        Task<CustomerPaymentViewModel> GetExpiringCustomers(int? paymentReminderDays);
    }
}
