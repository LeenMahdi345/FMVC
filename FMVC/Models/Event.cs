namespace FMVC.Models

{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}

