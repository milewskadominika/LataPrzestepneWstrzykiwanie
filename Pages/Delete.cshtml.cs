using LataPrzestepneWstrzykiwanie.Data;
using LataPrzestepneWstrzykiwanie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LataPrzestepneWstrzykiwanie.Pages
{
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public History? recordToDelete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            recordToDelete = _context.History.FirstOrDefault(x => x.Id == id);

            if (recordToDelete == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            recordToDelete = _context.History.FirstOrDefault(x => x.Id == id);

            if (recordToDelete != null)
            {
                _context.History.Remove(recordToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./History");
        }
    }
}
