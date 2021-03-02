using System.ComponentModel.DataAnnotations;

namespace ExamOne.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="Please enter a valid Email")]
        [Display(Name="Email:")]
        public string LoginEmail{get;set;}
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        [Display(Name="Password:")]
        public string LoginPassword{get;set;}
    }
}