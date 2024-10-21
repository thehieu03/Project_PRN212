using BussinessObject.Models;

namespace Responsitory.dal
{
    public interface IUser
    {
        User GetUser(string username, string password);
        void InsertUser(User user);
        bool checkUserNameExits(string username);
        bool checkEmailExits(string email);
    }
}
