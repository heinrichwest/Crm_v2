using System;

namespace CRM
{
    public enum UserRole
    {
        Learner = 1,
        Sales = 2,
        Teacher = 3,
        Admin = 4,
        SuperAdmin = 5
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
