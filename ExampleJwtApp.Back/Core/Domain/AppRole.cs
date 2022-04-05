namespace ExampleJwtApp.Back.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; } /*= string.Empty;*/
        public List<AppUser> AppUsers { get; set; }
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}
