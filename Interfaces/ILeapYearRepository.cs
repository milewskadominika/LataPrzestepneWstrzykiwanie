using LataPrzestepneWstrzykiwanie.Models;
using System;

namespace LataPrzestepneWstrzykiwanie.Interfaces
{
	public interface ILeapYearRepository
	{
        IQueryable<History> GetRecords();

    }
}
