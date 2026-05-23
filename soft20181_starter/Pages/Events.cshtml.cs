using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class EventsModel : PageModel
    {

        private readonly EventAppDbContext dbContext;

        public EventsModel(EventAppDbContext _db)
        {
            dbContext = _db;
        }

        public List<TheEvent> Events { get; set; } = new List<TheEvent>();
        public void OnGet()
        {
            Events = dbContext.Events.ToList();
         }

        }

        


}

