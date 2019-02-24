using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IdRole { get; set; }

        public Role Role { get; set; }
    }
}
