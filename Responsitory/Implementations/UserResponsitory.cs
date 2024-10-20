using BussinessObject.Models;
using DataAccessLayer;
using Responsitory.dal;

namespace Responsitory.Implementations
{
    public class UserResponsitory : IUser
    {
        public User GetUser(string username, string password) => UserDAO.Instance.getUser(username, password);
    }
}
