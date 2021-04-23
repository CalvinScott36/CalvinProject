using CalvinProject.Models;
using System.Collections.Generic;

namespace CalvinProject.Interfaces
{
    public interface IUserInterface
    {
        bool AddNewUser(User newUser);
        List<User> GetAllUsers();
        User GetUser(string Email);
        User UpdateUser(User updatedUser);
    }
}
