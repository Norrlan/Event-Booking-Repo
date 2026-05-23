using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace soft20181_starter.Models
{
    public class EventAppDbContext : DbContext
    {
        public EventAppDbContext(DbContextOptions<EventAppDbContext> options)
        : base(options) { }
        public DbSet<TheEvent> Events { get; set; }
        public DbSet<Contact> Contact{ get; set; }
    }

}
