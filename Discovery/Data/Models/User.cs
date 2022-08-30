using Microsoft.AspNetCore.Identity;

namespace Discovery.Data.Models
{
    public class User : IdentityUser
    {


        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
