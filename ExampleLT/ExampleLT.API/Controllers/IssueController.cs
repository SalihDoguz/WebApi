using ExampleLT.API.Context;
using ExampleLT.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExampleLT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;

        public IssueController(IssueDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
            => await _context.Issues.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            //if (id != issue.Id)
            //{
            //    return BadRequest();
            //}

            // Kısa ve temizde yazılabilir.
            if (id != issue.Id) return BadRequest();


            //var updateIssue = await _context.Issues.FindAsync(id);
            //_context.Issues.Update(updateIssue);
            //await _context.SaveChangesAsync();

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);

            if (issueToDelete == null) return NotFound();   

            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }
        

    }
}
