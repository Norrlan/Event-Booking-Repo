using System.ComponentModel.DataAnnotations;
namespace soft20181_starter.Models
	
{
	public class TheEvent
	{
		[Key] 
		public int Id  { get; set; }

        public string Title { get; set; }
        public string EType { get; set; } = "General";
		public string ELocation { get; set; }
		public DateTime EventStartDate { get; set; } = DateTime.Now;
        public DateTime EventStartTime { get; set; } = DateTime.Now;
        public DateTime EventEndTime { get; set; } = DateTime.Now;
		public string EventDescription { get; set; } = string.Empty;
        public string CoverPhoto { get; set; } = string.Empty;
		public double Price { get; set; }
		public int TicketsAvailable { get; set; }




    }
}
