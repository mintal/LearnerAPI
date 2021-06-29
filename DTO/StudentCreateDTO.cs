using System.ComponentModel.DataAnnotations;

namespace LearnerAPI.DTO
{
    public class StudentCreateDTO
    {
        public int? StudentNumber { get; set; }

        public string Initials { get; set; }
        public string LastName { get; set; }
        
        public int? StudyId { get; set; }
    }
}