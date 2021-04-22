using CalvinProject.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace CalvinProject.Models
{
    public class UserSQLRepository : IUserInterface
    {
        public AppDbContext context;

        public UserSQLRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User AddNewUser(User newUser)
        {
            using (context)
            {
                var user = context.Users.FirstOrDefault(usr => usr.Name == newUser.Name || usr.Email == newUser.Email);
                if(user == null){
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
            }
            return newUser;
        }

        public List<User> GetAllUsers()
        {
            var users = context.Users.ToList();
            return users;
        }

        public User GetUser(string Email)
        {
            var user = new User();
            using (context) {
              user = context.Users.FirstOrDefault(usr => usr.Email == Email || user.UserName == Email);
            }
            return user;
        }

        public User UpdateUser(User updatedUser )
        {
            var user = context.Users.FirstOrDefault(usr => usr.Id == updatedUser.Id);
            user.Name = updatedUser.Name;
            user.Password = updatedUser.Password;
            user.Email = updatedUser.Email;
            context.SaveChanges();
            return user;
        }
    }
}