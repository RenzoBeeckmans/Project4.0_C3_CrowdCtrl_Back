namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Guard : User
    {
        public string PhoneNumber { get; set; }

        public List<GroupGuard> GroupGuards { get; set; } = new List<GroupGuard>();
    }
}
