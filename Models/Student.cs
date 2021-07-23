using System;
using System.ComponentModel.DataAnnotations;

namespace LearnerAPI.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public int? StudentNumber { get; set; }

        //binds StudyId to Study.StudyId
        public int StudyId { get; set; }
        public Study Study { get; set; }

        [Required] public string Initials { get; set; }
        [Required] public string LastName { get; set; }
    }
}