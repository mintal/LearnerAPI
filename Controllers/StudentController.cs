using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnerAPI.Contexts;
using LearnerAPI.DTO;
using LearnerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsContext _context;
        private readonly IMapper _mapper;

        public StudentController(StudentsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtain all students
        /// </summary>
        /// <returns>All students in DTO form</returns>
        [HttpGet]
        public async Task<List<StudentDTO>> GetAll()
        {
            return await _context.Students.Include(s => s.Study).ProjectTo<StudentDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Obtain student by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StudentDTO>> Get(Guid id)
        {
            Student student = await _context.Students.Include(s => s.Study).FirstAsync(s => s.StudentId == id);
            return _mapper.Map<StudentDTO>(student);
        }

        /// <summary>
        /// Create a student following the StudentCreateDTO credentials
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>created student</returns>
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Post(StudentCreateDTO ctx)
        {
            //map DTO to Student
            Student s = _mapper.Map<Student>(ctx);
            s.Study = await _context.Studies.FindAsync(ctx.StudyId);

            //add to database
            //todo: catch duplicate entry exception
            _context.Students.Add(s);
            await _context.SaveChangesAsync();

            //return database result
            return await Get(s.StudentId);
        }
    }
}