using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
	public class EventDetailModel : PageModel
	{
		private readonly EventAppDbContext dbContext;

		public EventDetailModel(EventAppDbContext _db)
		{
			dbContext = _db;
		}

		public TheEvent? theEvent { get; set; }

		[BindProperty]
		public int TicketQuantity { get; set; } = 1;

		[TempData]
		public string? TicketMessage { get; set; }

		[TempData]
		public string? TicketMessageType { get; set; }

		public IActionResult OnGet(int id)
		{
			theEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);

			if (theEvent == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostGetTicketsAsync(int id)
		{
			theEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);

			if (theEvent == null)
			{
				return NotFound();
			}

			if (TicketQuantity < 1)
			{
				TicketMessage = "Please select at least 1 ticket.";
				TicketMessageType = "error";
				return Page();
			}

			if (TicketQuantity > theEvent.TicketsAvailable)
			{
				TicketMessage = $"Only {theEvent.TicketsAvailable} tickets are available.";
				TicketMessageType = "error";
				return Page();
			}

			theEvent.TicketsAvailable -= TicketQuantity;
			await dbContext.SaveChangesAsync();

			TicketMessage = $"Success! You got {TicketQuantity} ticket{(TicketQuantity == 1 ? string.Empty : "s")} for {theEvent.Title}.";
			TicketMessageType = "success";

			return RedirectToPage("/EventDetail", new { id });
		}
	}
}



