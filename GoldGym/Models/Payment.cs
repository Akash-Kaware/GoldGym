using System.ComponentModel.DataAnnotations;

namespace GoldGym.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? PaymentDate { get; set; }

        [Display(Name = "From Date")]
        [Required(ErrorMessage = "Please select from date.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime? FromDate { get; set; }

        [Display(Name ="To Date")]
        [Required(ErrorMessage = "Plese select to date.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime? ToDate { get; set; }

        [Required(ErrorMessage = "Please enter amount.")]
        public double? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
