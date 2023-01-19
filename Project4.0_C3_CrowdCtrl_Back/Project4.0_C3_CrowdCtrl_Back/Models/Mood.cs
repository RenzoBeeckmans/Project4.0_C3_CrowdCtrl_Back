using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Mood
    {
        public int MoodId { get; set; }
        public double Accuracy { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MoodTypeId { get; set; }
        public int EventRecordingDeviceId { get; set; }

        [JsonIgnore]
        public MoodType MoodType { get; set; }
        [JsonIgnore]
        public EventRecordingDevice EventRecordingDevice { get; set; }
    }
}
