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
    }
}
