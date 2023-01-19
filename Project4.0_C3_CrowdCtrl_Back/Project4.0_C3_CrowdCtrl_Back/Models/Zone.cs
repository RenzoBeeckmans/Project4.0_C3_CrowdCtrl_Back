using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<RecordingDevice> Devices { get; set; } = new List<RecordingDevice>();
        [JsonIgnore]
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
