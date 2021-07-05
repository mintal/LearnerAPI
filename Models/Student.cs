using System;
using System.ComponentModel.DataAnnotations;

namespace LearnerAPI.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        
        public int? StudentNumber { get; set; }
        public Study? Study { get; set; }

        [Required] public string Initials { get; set; }
        [Required] public string LastName { get; set; }
        
    }
}