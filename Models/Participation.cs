using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ExamOne.Models
{
    public class Participation
    {
        [Key]
        public int ParticipationId {get;set;}
        public int UserId{get;set;}
        public int GatheringId{get;set;}
        public User Participant {get;set;}
        public Gathering Event {get;set;}
    }
}