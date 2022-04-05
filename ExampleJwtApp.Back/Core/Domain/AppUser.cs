﻿namespace ExampleJwtApp.Back.Core.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
        public AppUser()
        {
            AppRole = new AppRole(); // Null olamaz en kötü boş bir nesne örneği taşır anlamında yapıyoruz.
        }
    }
}
