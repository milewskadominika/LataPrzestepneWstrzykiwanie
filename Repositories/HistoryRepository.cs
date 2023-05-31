using LataPrzestepneWstrzykiwanie.Data;
using LataPrzestepneWstrzykiwanie.Interfaces;
using LataPrzestepneWstrzykiwanie.Models;

namespace LataPrzestepneWstrzykiwanie.Repositories
{
	public class HistoryRepository : ILeapYearRepository
	{
		private readonly ApplicationDbContext _context;

		public HistoryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IQueryable<History> GetRecords()
		{
			return _context.History;
		}
	}
}
