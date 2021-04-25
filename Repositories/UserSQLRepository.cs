using CalvinProject.Helpers;
using CalvinProject.Interfaces;
using CalvinProject.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CalvinProject.Models
{
    public class UserSQLRepository : IUserInterface
    {
        private AppDbContext context;
        private IConfiguration configuration;
        private PasswordManager PasswordManager = new PasswordManager();
        public UserSQLRepository(IConfiguration configuration, AppDbContext context)
        {
            this.context = context;
            this.configuration = configuration;
        }


        public bool AddNewUser(RegisterUserResponse newUser)
        {
            newUser.NewUser.Password = PasswordManager.HashPassword(configuration, newUser.NewUser.Password);
            using (context)
            {
                try
                {
                    var user = context.Users.FirstOrDefault(usr => usr.UserName == newUser.NewUser.UserName || usr.Email == newUser.NewUser.Email);
                    if (user == null)
                    {
                        context.Users.Add(newUser.NewUser);
                        context.SaveChanges();
                        newUser.Success = true;
                    }
                    else
                    {
                        newUser.Success = false;
                        newUser.ErrorMesssage = $"User {newUser.NewUser.FirstName} already exists";
                    }
                }
                catch (Exception ex)
                {
                    newUser.Success = false;
                    newUser.ErrorMesssage = $"An Error has occured { ex.Message }";
                }
            }
            return newUser.Success;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(LoginResponse loginRes)
        {
            var passwordToCheck = PasswordManager.HashPassword(configuration, loginRes.User.Password);
            var user = new User();
            using (context)
            {
                user = context.Users.FirstOrDefault(
                    usr => (usr.Email == loginRes.User.UserName
                  || usr.UserName == loginRes.User.UserName)
                  && usr.Password == passwordToCheck);
                return user;
            }
        }


        public User UpdateUser(User updatedUser)
        {
            var user = context.Users.FirstOrDefault(usr => usr.Id == updatedUser.Id);
            user.FirstName = updatedUser.FirstName;
            user.Surname = updatedUser.Surname;
            user.UserName = updatedUser.UserName;
            user.Password = updatedUser.Password;
            user.Email = updatedUser.Email;
            context.SaveChanges();
            return user;
        }
    }
}