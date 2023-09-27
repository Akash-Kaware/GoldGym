namespace GoldGym
{
    public class MyConfiguration
    {
        public MyConfiguration(int? paymentReminderDays, string defaultPassword)
        {
            PaymentReminderDays = paymentReminderDays;
            DefaultPassword = defaultPassword;
        }

        public int? PaymentReminderDays { get; set; }

        public string DefaultPassword { get; set; }
    }
}
