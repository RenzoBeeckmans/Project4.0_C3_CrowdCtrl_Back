using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class MoodType
    {
        public int MoodTypeId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Mood>? Moods { get; set; } = new List<Mood>();
        [JsonIgnore]
        public List<Incident>? Incidents { get; set; } = new List<Incident>();
    }
}
