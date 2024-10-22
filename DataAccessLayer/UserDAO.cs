using BussinessObject.Models;

namespace DataAccessLayer
{
    public class UserDAO : SingletonBase<UserDAO>
    {

        public List<User> GetUsers()
        {
            var connext = UserDAO.GetContext();
            return connext.Users.ToList();
        }
        public User getUser(string username, string password)
        {
            var connext = UserDAO.GetContext();
            return connext.Users.FirstOrDefault(c => c.UserName.Equals(username) && c.PassWord.Equals(password));
        }
        public void insertUser(User user)
        {
            var context = UserDAO.GetContext();
            context.Users.Add(user);
            context.SaveChanges();
        }
        public bool checkUserNameExits(string username)
        {
            var context = UserDAO.GetContext();
            return context.Users.Any(c => c.UserName.Equals(username));
        }
        public bool checkEmailExits(string username)
        {
            var context = UserDAO.GetContext();
            return context.Users.Any(c => c.Email.Equals(username));
        }
        public void updatePassword(string email, string password)
        {
            var context = UserDAO.GetContext();
            User user = context.Users.FirstOrDefault(c => c.Email.Equals(email));
            if (user != null)
            {
                user.PassWord = password;
                context.SaveChanges();
            }

        }
    }
}
