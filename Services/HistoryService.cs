using LataPrzestepneWstrzykiwanie.Interfaces;
using LataPrzestepneWstrzykiwanie.ViewModels.History;
using Microsoft.AspNetCore.Mvc;

namespace LataPrzestepneWstrzykiwanie.Services
{
	public class HistoryService : ILeapYearInterface
	{
        private readonly ILeapYearRepository _historyRepo;

        public HistoryService(ILeapYearRepository historyRepo)
        {
            _historyRepo = historyRepo;
        }


        public ListHistoryForListVM GetRecords()
		{
            var records = _historyRepo.GetRecords();
            ListHistoryForListVM result = new ListHistoryForListVM();
            result.Records = new List<HistoryForListVM>();
            foreach (var record in records)
            {
                // mapowanie obiektów
                var pVM = new HistoryForListVM()
                {
                    Id = record.Id,
                    CreatedDate = record.CreatedDate,
                    IsLeap = record.IsLeap.ToString(),
                    UserId = record.UserId,
                    UserLogin = record.UserLogin,
                    Year = record.Year, 
                };
                result.Records.Add(pVM);
            }
            result.Count = result.Records.Count;
            return result;

        }
    }
}
