using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class UserManager
    {
        public User CurrentUser { get; set; }
        public Dictionary<string, string> Users { get; set; } = new();

        public UserManager() { }
        public UserManager(User currentUser)
        {
            CurrentUser = currentUser;
        }
        public void AddUser(User user)
        {
            Users[user.Username] = user.Password;
        }
        public void SaveUsersToFileJson(string filePath)
        {
            var json = JsonSerializer.Serialize(Users);
            File.WriteAllText(filePath, json);

        }
        public void LoadUsersFromFileJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Users = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
        }

    }
}
