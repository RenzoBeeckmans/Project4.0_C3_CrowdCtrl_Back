using Microsoft.AspNetCore.Identity;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public List<EventUser> EventUsers { get; set; } = new List<EventUser>();
    }
}
