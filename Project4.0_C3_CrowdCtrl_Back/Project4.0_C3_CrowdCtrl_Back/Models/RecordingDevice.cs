namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class RecordingDevice
    {
        public int RecordingDeviceId { get; set; }
        public string Name { get; set; }
        public int ZoneId { get; set; }

        public Zone Zone { get; set; }
        public List<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
