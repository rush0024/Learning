using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learning.Models;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningPractisesController : ControllerBase
    {
        private readonly LearningContext _context;

        public LearningPractisesController(LearningContext context)
        {
            _context = context;
        }

        // GET: api/LearningPractises
        [HttpGet]
        public IEnumerable<LearningPractise> GetLearningPractises()
        {
            return _context.LearningPractises;
        }

        // GET: api/LearningPractises/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLearningPractise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var learningPractise = await _context.LearningPractises.FindAsync(id);

            if (learningPractise == null)
            {
                return NotFound();
            }

            return Ok(learningPractise);
        }

        // PUT: api/LearningPractises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearningPractise([FromRoute] int id, [FromBody] LearningPractise learningPractise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != learningPractise.Id)
            {
                return BadRequest();
            }

            _context.Entry(learningPractise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningPractiseExists(id))
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

        // POST: api/LearningPractises
        [HttpPost]
        public async Task<IActionResult> PostLearningPractise([FromBody] LearningPractise learningPractise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LearningPractises.Add(learningPractise);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetLearningPractise", new { id = learningPractise.Id }, learningPractise);
        }

        // DELETE: api/LearningPractises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningPractise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var learningPractise = await _context.LearningPractises.FindAsync(id);
            if (learningPractise == null)
            {
                return NotFound();
            }

            _context.LearningPractises.Remove(learningPractise);
            await _context.SaveChangesAsync();

            return Ok(learningPractise);
        }

        private bool LearningPractiseExists(int id)
        {
            return _context.LearningPractises.Any(e => e.Id == id);
        }
    }
}