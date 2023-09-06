namespace GoldGym
{
    using GoldGym.Data;
    using GoldGym.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigurationExtension
    {
        public static void AddProjectDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<SqlDbConnection>(new SqlDbConnection(builder.Configuration.GetConnectionString("GoldConnString")));
            int? PaymentReminderDays = builder.Configuration.GetValue<int>("PaymentReminderDays");
            builder.Services.AddSingleton<MyConfiguration>(new MyConfiguration(PaymentReminderDays));
            string? EncryptionKey = builder.Configuration.GetValue<string>("EncryptionKey");
            builder.Services.AddSingleton(new Encryption(EncryptionKey));
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
