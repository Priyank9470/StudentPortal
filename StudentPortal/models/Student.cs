using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Enter Valid First Name")]
        [MaxLength(20, ErrorMessage = "First Name should not exceed 20 letters")]
        [MinLength(2, ErrorMessage = "First Name should not of One letter")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Enter Valid Last Name")]
        [MaxLength(20, ErrorMessage = "Last Name should not exceed 20 letters")]
        [MinLength(2, ErrorMessage = "Last Name should not of One letter")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Age must be a valid integer number")]
        [Range(5, 75, ErrorMessage = "Age must between 5 and 75")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}", ErrorMessage = "Enter valid number of 10 digits")]
        public double? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        [MaxLength(80, ErrorMessage = "Please do not enter big address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Standard is required")]
        [Display(Name = "Standard")]
        [Range(1, 12, ErrorMessage = "Enter standard between 1 and 12")]
        public int? Standard { get; set; }

        [Required]
        public string Course { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*~]{8,20}$", ErrorMessage = "Password must contain One special character, One Upper Case letter,One Lower Case letter, One Number and length should be in between 8 and 20")]
        [Display(Name = "Set Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password must be same as password")]
        public string ConfirmPassword { get; set; }

       public List<Student> oldStudents { get; set; }
    }
}