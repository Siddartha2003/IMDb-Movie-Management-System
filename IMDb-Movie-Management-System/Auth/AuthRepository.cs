using IMDb_Movie_Management_System.Models.DB;

namespace IMDb_Movie_Management_System.Auth
{
    public class AuthRepository
    {
        private static List<User> _users = new List<User>();

        public void Add(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }

        public User Get(string email, string password)
        {
            return _users.FirstOrDefault(u =>
                u.MailId == email && u.Password == password);
        }
    }
}
