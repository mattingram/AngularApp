using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Services;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : Controller
	{
		private readonly SuperHeroService _service;

		public SuperHeroController(SuperHeroService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
		{
			return Ok(await _service.GetSuperHeroes());
		}

		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
		{
			return Ok(await _service.CreateSuperHero(hero));
		}

		[HttpPut]
		public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
		{
			var dbHeroes = await _service.UpdateSuperHero(hero);
			if (dbHeroes == null)
			{
				return NotFound();
			}

			return Ok(dbHeroes);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(SuperHero hero)
		{
			var dbHero = await _service.DeleteSuperHero(hero);
			if (dbHero == null)
			{
				return NotFound();
			}

			return Ok(dbHero);
		}
	}
}
