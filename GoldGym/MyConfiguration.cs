namespace GoldGym
{
    public class MyConfiguration
    {
        public MyConfiguration(int? paymentReminderDays)
        {
            PaymentReminderDays = paymentReminderDays;
        }

        public int? PaymentReminderDays { get; set; }
    }
}
