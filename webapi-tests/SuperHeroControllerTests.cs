using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers;
using Moq;
using webapi;
using webapi.Data;
using webapi.Services;

namespace webapi_tests
{
	[TestFixture]
	public class SuperHeroControllerTests
	{
		private SuperHeroController _controller = null!;
		private Mock<DataContext> _mockContext = null!;
		private Mock<SuperHeroService> _mockService = null!;
		private List<SuperHero> _superHeros = null!;

		[SetUp]
		public void Setup()
		{
			_mockContext = new Mock<DataContext>(new DbContextOptions<DataContext>());
			_mockService = new Mock<SuperHeroService>(_mockContext.Object);;
			_controller = new SuperHeroController(_mockService.Object);
		}

		[Test]
		public async Task ShouldGetSuperHeros()
		{
			_superHeros = new List<SuperHero>
			{
				new SuperHero
				{
					Id = 1,
					Name = "Superman",
					FirstName = "Clark",
					LastName = "Kent",
					Place = "Smallville"
				}
			};

			_mockService.Setup(x => x.GetSuperHeroes()).ReturnsAsync(_superHeros);
			
			var result = await _controller.GetSuperHeroes();

			Assert.IsInstanceOf<OkObjectResult>(result.Result);
			var model = result.Result as OkObjectResult;
			Assert.That(model.Value, Is.EquivalentTo(_superHeros));
		}
	}
}