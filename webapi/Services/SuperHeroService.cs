using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Services
{
	public class SuperHeroService
	{
		private readonly DataContext _context;

		public SuperHeroService(DataContext context)
		{
			_context = context;
		}

		public virtual async Task<List<SuperHero>> GetSuperHeroes()
		{
			return await _context.SuperHeros.ToListAsync();
		}

		public async Task<SuperHero?> GetSuperHero(SuperHero hero)
		{
			return await _context.SuperHeros.FindAsync(hero.Id);
		}

		public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
		{
			_context.SuperHeros.Add(hero);
			await _context.SaveChangesAsync();

			return await _context.SuperHeros.ToListAsync();
		}

		public async Task<List<SuperHero>?> UpdateSuperHero(SuperHero hero)
		{
			var dbHero = await GetSuperHero(hero);
			if (dbHero == null)
			{
				return null;
			}

			dbHero.Name = hero.Name;
			dbHero.FirstName = hero.FirstName;
			dbHero.LastName = hero.LastName;
			dbHero.Place = hero.Place;

			await _context.SaveChangesAsync();

			return await _context.SuperHeros.ToListAsync();
		}

		public async Task<List<SuperHero>?> DeleteSuperHero(SuperHero hero)
		{
			var dbHero = await GetSuperHero(hero);
			if (dbHero == null)
			{
				return null;
			}

			_context.SuperHeros.Remove(dbHero);
			await _context.SaveChangesAsync();
			return await _context.SuperHeros.ToListAsync();
		}
	}
}
