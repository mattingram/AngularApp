using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : Controller
	{
		private readonly DataContext _context;

		public SuperHeroController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
		{
			return Ok(await _context.SuperHeros.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
		{
			_context.SuperHeros.Add(hero);
			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeros.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
		{
			var dbHero = await _context.SuperHeros.FindAsync(hero.Id);
			if (dbHero == null)
			{
				return NotFound();
			}

			dbHero.Name = hero.Name;
			dbHero.FirstName = hero.FirstName;
			dbHero.LastName = hero.LastName;
			dbHero.Place = hero.Place;

			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeros.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(SuperHero hero)
		{
			var dbHero = await _context.SuperHeros.FindAsync(hero.Id);
			if (dbHero == null)
			{
				return NotFound();
			}

			_context.SuperHeros.Remove(dbHero);
			await _context.SaveChangesAsync();
			return Ok(await _context.SuperHeros.ToListAsync());
		}
	}
}
