using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp_CoreWebAPI.Models;

namespace QuizApp_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class McqQuestionsController : ControllerBase
    {
        private readonly McqDBContext _context;

        public McqQuestionsController(McqDBContext context)
        {
            _context = context;
        }

        // GET: api/McqQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<McqQuestion>>> GetMcqQuestion()
        {
            return await _context.McqQuestion.ToListAsync();
        }

        // GET: api/McqQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<McqQuestion>> GetMcqQuestion(int id)
        {
            var mcqQuestion = await _context.McqQuestion.FindAsync(id);

            if (mcqQuestion == null)
            {
                return NotFound();
            }

            return mcqQuestion;
        }

        // PUT: api/McqQuestions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMcqQuestion(int id, McqQuestion mcqQuestion)
        {
            if (id != mcqQuestion.McqId)
            {
                return BadRequest();
            }

            _context.Entry(mcqQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!McqQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/McqQuestions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<McqQuestion>> PostMcqQuestion(McqQuestion mcqQuestion)
        {
            _context.McqQuestion.Add(mcqQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMcqQuestion", new { id = mcqQuestion.McqId }, mcqQuestion);
        }

        // DELETE: api/McqQuestions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<McqQuestion>> DeleteMcqQuestion(int id)
        {
            var mcqQuestion = await _context.McqQuestion.FindAsync(id);
            if (mcqQuestion == null)
            {
                return NotFound();
            }

            _context.McqQuestion.Remove(mcqQuestion);
            await _context.SaveChangesAsync();

            return mcqQuestion;
        }

        private bool McqQuestionExists(int id)
        {
            return _context.McqQuestion.Any(e => e.McqId == id);
        }
    }
}
