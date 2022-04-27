using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.MVVM.Model.DB
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
#nullable enable
        public string? DisplayName { get; set; }
        public string Password { get; set; }
        public Settings Settings { get; set; }
        public User(string username, string? displayName, string password)
        {
            Username = username;
            DisplayName = displayName;
            Password = password;
            Settings = new Settings();
        }
#nullable disable

        public User()
        {
        }
    }
}
