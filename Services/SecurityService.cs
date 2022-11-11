using cis4951.sprint.w41._4.Models;

namespace cis4951.sprint.w41._4.Services
{
    public class SecurityService
    {
           UsersDAO usersDAO = new UsersDAO();

          public SecurityService()
          {          }

          public bool isValid(UserModel user)
          {
               return usersDAO.FindUserByNameAndPassword(user);

          }
    }
}
