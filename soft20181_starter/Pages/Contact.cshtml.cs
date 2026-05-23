using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;
using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Pages
{
    public class ContactModel : PageModel
    {
        private readonly EventAppDbContext _context;

        [BindProperty]
        public Contact ContactInfo { get; set; }

        public ContactModel(EventAppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(ContactInfo);
                _context.SaveChanges();

                // Set the sender's name in TempData
                TempData["SenderName"] = ContactInfo.FName;

                TempData["SuccessMessage"] = "Contact information saved successfully!";

                return Page();
            }

            return Page();
        }
    }

}
