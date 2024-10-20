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
    }
}
