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
	}
}
