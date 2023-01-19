using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int ZoneID { get; set; }
        public int EventID { get; set; }
        [JsonIgnore]
        public Zone Zone { get; set; }
        [JsonIgnore]
        public Event Event { get; set; }
        [JsonIgnore]
        public List<GroupGuard> GroupGuards { get; set; } = new List<GroupGuard>();
    }
}
