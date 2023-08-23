namespace GoldGym.Data
{
    using Dapper;
    using GoldGym.Models;

    public static class DynamicParametersToDtos
    {
        public static DynamicParameters ToDynamicParameters(this Customer customer)
        {            
            var parameters = new DynamicParameters();
            parameters.Add("Id", customer.Id);
            parameters.Add("Name", customer.Name);
            parameters.Add("DOB", customer.DOB);
            parameters.Add("Gender", customer.Gender);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Pincode", customer.Pincode);
            parameters.Add("Mobile1", customer.Mobile1);
            parameters.Add("Mobile2", customer.Mobile2);
            parameters.Add("Email", customer.Email);
            parameters.Add("IsActive", customer.IsActive);
            return parameters;
        }

        public static DynamicParameters ToDynamicParameters(this Payment payment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", payment.Id);
            parameters.Add("CustomerId", payment.CustomerId);
            parameters.Add("PaymentDate", payment.PaymentDate);
            parameters.Add("FromDate", payment.FromDate);
            parameters.Add("ToDate", payment.ToDate);
            parameters.Add("Amount", payment.Amount);
            return parameters;
        }
    }
}
