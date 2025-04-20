namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string full_name { get; set; }
        public string name_normalized { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
        public bool is_active { get; set; } = true;
    }

    public enum Role
    {
        Admin,
        Owner,
        Customer,
    }
}
