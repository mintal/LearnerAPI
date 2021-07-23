using System;
using LearnerAPI.DTO;
using LearnerAPI.Models;

namespace LearnerAPI
{
    public static class StudentMapper
    {
        public static Student MapStudent(StudentCreateDTO ctx, Study study)
        {
            return new()
            {
                StudentId = Guid.NewGuid(),
                Initials = ctx.Initials,
                LastName = ctx.LastName,
                StudentNumber = ctx.StudentNumber,
                Study = study
            };
        }
    }
}