using BussinessObject.Models;
using DataAccessLayer;
using Responsitory.dal;

namespace Responsitory.Implementations
{
    public class UserResponsitory : IUser
    {
        public bool checkEmailExits(string email) => UserDAO.Instance.checkEmailExits(email);

        public bool checkUserNameExits(string username) => UserDAO.Instance.checkUserNameExits(username);

        public User GetUser(string username, string password) => UserDAO.Instance.getUser(username, password);

        public void InsertUser(User user) => UserDAO.Instance.insertUser(user);
    }
}
