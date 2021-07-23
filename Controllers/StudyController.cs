using System.Collections.Generic;
using System.Threading.Tasks;
using LearnerAPI.Contexts;
using LearnerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private readonly StudentsContext _context;

        public StudyController(StudentsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Study>> GetAll()
        {
            return await _context.Studies.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Study> Get(int id)
        {
            return await _context.Studies.FindAsync(id);
        }

        [HttpGet("{id:int}/students")]
        public async Task<Study> GetWithStudents(int id)
        {
            Study s = await _context.Studies
                .Include(s => s.Students)
                .FirstAsync(study => study.StudyId == id);

            return s;
        }
    }
}