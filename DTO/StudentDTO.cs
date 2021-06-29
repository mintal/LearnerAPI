using System;

namespace LearnerAPI.DTO
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public int? StudentNumber { get; set; }

        public string Initials { get; set; }
        public string LastName { get; set; }
        
        public int? StudyId { get; set; }
    }
}