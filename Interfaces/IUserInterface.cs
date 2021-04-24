using CalvinProject.Models;
using CalvinProject.Models.Response;
using System.Collections.Generic;

namespace CalvinProject.Interfaces
{
    public interface IUserInterface
    {
        bool AddNewUser(RegisterUserResponse newUser);
        List<User> GetAllUsers();
        User GetUser(LoginResponse loginRes);
        User UpdateUser(User updatedUser);
    }
}
