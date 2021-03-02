using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ExamOne.Validations;

namespace ExamOne.Models
{
    public class Gathering
    {
        [Key]
        public int GatheringId {get;set;}

        [Required]
        [Display(Name="Title: ")]
        public string Title {get;set;}

        [Required]
        [Display(Name="Date and Time: ")]
        [Future]
        public DateTime Start {get;set;}

        [Required]
        [Display(Name="Duration: ")]
        [Range(0,59)]
        public int DurationInt {get;set;}

        [Required]
        [Display(Name="Duration Type: ")]
        public string DurationString {get;set;}

        [Required]
        [Display(Name="Description: ")]
        [MinLength(10,ErrorMessage="Description must be at least 10 charcters")]
        public string Description {get;set;}
        public int UserId {get;set;}
        public User Creator {get;set;}
        public List<Participation> Participants {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
    }
}