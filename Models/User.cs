using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ExamOne.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="Name is required")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters long")]
        [Display(Name="Name:")]
        public string Name{get;set;}

        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="Please enter a valid Email")]
        [Display(Name="Email:")]
        public string Email{get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password is required")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        [Display(Name="Password:")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain a minimum of one lowercase, one uppercase, one number, and one special character")]
        public string Password{get;set;}

        public List<Gathering> CreatedGatherings {get;set;}

        public List<Participation> GoingTo {get;set;}

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name="Confirm Password:")]
        [NotMapped]
        public string ConfirmPassword{get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}