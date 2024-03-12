using ChuckNoris.Api.DAL;
using ChuckNoris.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuckNoris.Api.Controllers
{
	[Route("Chuck")]
	[ApiController]
	public class ChuckController : Controller
	{
		private readonly ChuckContext _context;

		public ChuckController(ChuckContext context) 
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ChuckFact>> Chuck()
		{
			return _context.Facts;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ChuckFact>> Get(int id)
		{
			return await _context.Facts.SingleAsync(x => x.Id == id);
		}

		[HttpPost]
		public async Task<ActionResult<ChuckFact>> Post([FromBody] ChuckFact chuckFact)
		{
			_context.Facts.Add(chuckFact);
			await _context.SaveChangesAsync();
			return CreatedAtAction("Get", new { id = chuckFact.Id }, chuckFact);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<ChuckFact>> Put(int id, [FromBody] ChuckFact chuckFact)
		{
			if(id != chuckFact.Id)
			{
				return BadRequest();
			}

			_context.Facts.Entry(chuckFact).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return chuckFact;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ChuckFact>> Delete(int id)
		{
			ChuckFact? chuckFact = await _context.Facts.FindAsync(id);
			if (chuckFact == null) 
			{ 
				return NotFound(); 
			}

			_context.Facts.Remove(chuckFact);
			await _context.SaveChangesAsync();
			return chuckFact;
		}
	}
}
