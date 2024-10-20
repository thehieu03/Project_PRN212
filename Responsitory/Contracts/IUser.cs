using BussinessObject.Models;

namespace Responsitory.dal
{
    public interface IUser
    {
        User GetUser(string username, string password);
    }
}
