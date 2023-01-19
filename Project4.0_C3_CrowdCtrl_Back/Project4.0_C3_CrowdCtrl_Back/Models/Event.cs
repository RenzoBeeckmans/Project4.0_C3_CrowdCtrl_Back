using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int EventTypeId { get; set; }
        public string Description { get; set; }
        
        public EventType? EventType { get; set; }
        [JsonIgnore]
        public List<EventUser>? EventUsers { get; set; } = new List<EventUser>();
        [JsonIgnore]
        public List<Group>? Groups { get; set; } = new List<Group>();
        [JsonIgnore]
        public List<Incident>? Incidents { get; set; } = new List<Incident>();   
    }
}
