using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class AddEventModel : PageModel
    {
        private readonly EventAppDbContext dbContext;

        public AddEventModel(EventAppDbContext _db)
        {
            dbContext = _db;
        }

        [BindProperty]
        public TheEvent theEvent { get; set; } = new TheEvent();
        public List<TheEvent> Events { get; set; } = new List<TheEvent>();

        public void OnGet()
        {
            Events = dbContext.Events.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dbContext.Events.Add(theEvent);
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Events");
        }
    }
}
