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
    public class TextQuestionsController : ControllerBase
    {
        private readonly OnlineContext _context;

        public TextQuestionsController(OnlineContext context)
        {
            _context = context;
        }

        // GET: api/TextQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextQuestion>>> GetTextQuestion()
        {
            return await _context.TextQuestion.ToListAsync();
        }

        // GET: api/TextQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextQuestion>> GetTextQuestion(int id)
        {
            var textQuestion = await _context.TextQuestion.FindAsync(id);

            if (textQuestion == null)
            {
                return NotFound();
            }

            return textQuestion;
        }

        // PUT: api/TextQuestions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextQuestion(int id, TextQuestion textQuestion)
        {
            if (id != textQuestion.TextId)
            {
                return BadRequest();
            }

            _context.Entry(textQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextQuestionExists(id))
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

        // POST: api/TextQuestions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TextQuestion>> PostTextQuestion(TextQuestion textQuestion)
        {
            _context.TextQuestion.Add(textQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTextQuestion", new { id = textQuestion.TextId }, textQuestion);
        }

        // DELETE: api/TextQuestions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TextQuestion>> DeleteTextQuestion(int id)
        {
            var textQuestion = await _context.TextQuestion.FindAsync(id);
            if (textQuestion == null)
            {
                return NotFound();
            }

            _context.TextQuestion.Remove(textQuestion);
            await _context.SaveChangesAsync();

            return textQuestion;
        }

        private bool TextQuestionExists(int id)
        {
            return _context.TextQuestion.Any(e => e.TextId == id);
        }
    }
}
