namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class GroupGuard
    {
        public int GroupGuardId { get; set; }
        public int GroupId { get; set; }
        public int GuardId { get; set; }
        public Group Group { get; set; }
        public Guard Guard { get; set; }
    }
}
