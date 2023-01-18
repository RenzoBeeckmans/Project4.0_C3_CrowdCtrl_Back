using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public int Threshold { get; set; }
        [JsonIgnore]
        public List<Event>? Events { get; set; } = new List<Event>();
    }
}
