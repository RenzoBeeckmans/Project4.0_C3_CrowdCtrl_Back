using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class EventUser
    {
        public int EventUserId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public Event Event { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
