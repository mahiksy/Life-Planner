namespace cis4951.sprint.w41._4.Models
{
     public class UserModel
     {
          public int Id { get; set; }
          public string UserName { get; set; }
          public string Password { get; set; }

          public UserModel(int id, string userName, string password)
          {
               Id = id;
               UserName = userName;
               Password = password;
          }
          //22.11.11 temp?
          public UserModel()
          {

          }
          public UserModel(object id, object userName, object password)
          {
               Id = (int)id;
               UserName = (string?)userName;
               Password = (string?)password;
          }
     }
}
