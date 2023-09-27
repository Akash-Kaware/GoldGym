namespace GoldGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using GoldGym.Data;
    using Microsoft.AspNetCore.Mvc;

    public class UserModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter name."), MaxLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [Remote("IsValidDateOfBirth", "Validation", HttpMethod = "POST", ErrorMessage = "Please provide a valid date of birth.")]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please enter address."), MaxLength(250)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter city."), MaxLength(50)]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please enter pincode.")]
        [MaxLength(6, ErrorMessage = "Please enter valid pincode.")]
        [MinLength(6, ErrorMessage = "Please enter valid pincode.")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid pincode.")]
        public string? Pincode { get; set; }

        [Required(ErrorMessage = "Please enter mobile number.")]
        [MaxLength(10, ErrorMessage = "Please enter mobile number.")]
        [MinLength(10, ErrorMessage = "Please enter mobile number.")]
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid mobile number.")]
        public string? Mobile1 { get; set; }

        [MaxLength(10, ErrorMessage = "Please enter valid mobile number.")]
        [MinLength(10, ErrorMessage = "Please enter valid mobile number.")]
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid mobile number.")]
        public string? Mobile2 { get; set; }

        [Required(ErrorMessage = "Please enter email Id.")]
        [EmailAddress(ErrorMessage = "Please enter valid email Id.")]
        [Remote("CheckDuplicateEmail", "Validation", HttpMethod = "POST", ErrorMessage = "Email already exists.", AdditionalFields = "Id")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 155 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password"), DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }

        public UserRole Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string? OldPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 155 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password"), DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}
