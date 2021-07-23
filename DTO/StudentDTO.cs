using System;

namespace LearnerAPI.DTO
{
    public record StudentDTO
    {
        public Guid StudentId { get; init; }
        public int? StudentNumber { get; init; }

        public string Initials { get; init; }
        public string LastName { get; init; }

        public int? StudyId { get; init; }
    }
}