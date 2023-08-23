namespace GoldGym.Models
{
    public class CustomerPaymentViewModel
    {
        public IList<Customer> Customers { get; set; }
        public IList<Payment> Payments { get; set; }
    }
}
