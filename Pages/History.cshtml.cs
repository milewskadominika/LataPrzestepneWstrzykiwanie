using LataPrzestepneWstrzykiwanie.Data;
using LataPrzestepneWstrzykiwanie.Interfaces;
using LataPrzestepneWstrzykiwanie.Models;
using LataPrzestepneWstrzykiwanie.ViewModels.History;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LataPrzestepneWstrzykiwanie.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ILogger<IndexModel>? _logger;
        private readonly ILeapYearInterface _leapInterface;
        private readonly IConfiguration? Configuration;
        public ListHistoryForListVM Records { get; set; }
        public string? currentUser { get; set; }


        public HistoryModel(ILogger<IndexModel> logger, ILeapYearInterface leapInterface, IConfiguration configuration)
        {
            _logger = logger;
            _leapInterface = leapInterface;
            Configuration = configuration;
        }


        public async Task OnGetAsync(int? pageIndex)
        {
            currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Records = _leapInterface.GetRecords();
        }




    }
}
