namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class RecordingDevice
    {
        public int RecordingDeviceId { get; set; }
        public string Name { get; set; }
        public List<EventRecordingDevice> EventRecordingDevices { get; set; } = new List<EventRecordingDevice>();
    }
}
