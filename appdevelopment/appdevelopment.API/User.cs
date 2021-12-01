using System;
using System.Collections.Generic;

#nullable disable

namespace appdevelopment.API
{
    public partial class User
    {
        public User()
        {
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
