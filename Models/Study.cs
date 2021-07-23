using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnerAPI.Models
{
    public class Study
    {
        public int StudyId { get; set; }
        [Required] public string StudyName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}