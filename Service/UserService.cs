using Second.Model;
using Second.Enum;
using BikeServiceManagementSystem.Data.Utils;

namespace Second.Service
{
    public class UserService
    {
        private List<User> users;

        public UserService()
        {
            users = new List<User>
            {
                new User { Username = "admin", Password = HashPassword.HashSecret("admin"), Role = Role.Admin },
                new User { Username = "staff", Password = HashPassword.HashSecret("staff"), Role = Role.Staff }
            };
        }
 
        public User CurrentUser { get; private set; }

        public User Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && HashPassword.VerifyHash(password, user.Password))
            {
                CurrentUser = user;
                return CurrentUser;
            }

            return null;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
