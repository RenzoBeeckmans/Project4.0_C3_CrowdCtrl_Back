namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int ZoneID { get; set; }
        public int EventID { get; set; }
        public Zone Zone { get; set; }
        public Event Event { get; set; }
        public List<GroupGuard> GroupGuards { get; set; } = new List<GroupGuard>();
    }
}
