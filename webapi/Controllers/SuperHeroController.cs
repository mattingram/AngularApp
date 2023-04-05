using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : Controller
	{
		[HttpGet]
		public async Task<List<SuperHero>> GetSuperHeros()
		{
			return new List<SuperHero>()
			{
				new SuperHero()
				{
					Name = "Spider Man",
					FirstName = "Peter",
					LastName = "Parker",
					Place = "New York"
				}
			};
		}
	}
}
