namespace GoldGym
{
    using GoldGym.Data;
    using GoldGym.Repository;
    using Microsoft.Extensions.DependencyInjection;
    using System.Configuration;

    public static class ConfigurationExtension
    {
        public static void AddProjectDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<SqlDbConnection>(new SqlDbConnection(builder.Configuration.GetConnectionString("GoldConnString")));
            int? PaymentReminderDays = builder.Configuration.GetValue<int>("PaymentReminderDays");
            builder.Services.AddSingleton<MyConfiguration>(new MyConfiguration(PaymentReminderDays));
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
        }
    }
}
