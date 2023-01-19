using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class GroupGuard
    {
        public int GroupGuardId { get; set; }
        public int GroupId { get; set; }
        public int GuardId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
        [JsonIgnore]
        public Guard Guard { get; set; }
    }
}
