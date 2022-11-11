using cis4951.sprint.w41._4.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq;

namespace cis4951.sprint.w41._4.Services
{
     public class UsersDAO
     {
          string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

          public bool FindUserByNameAndPassword(UserModel user)
          {
               string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";
               bool success = false;

               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                    command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                    try
                    {
                         connection.Open();
                         SqlDataReader reader = command.ExecuteReader();

                         if (reader.HasRows)
                         {
                              success = true;
                         }
                    }
                    catch (Exception e)
                    {
                         Console.WriteLine(e.Message);
                    }

               }

               return success;

          }
          public List<UserModel> GetUser(List<int> idList)
          {
               string sqlStatement = "SELECT * FROM dbo.Users WHERE"; /// WHERE Id = @id
               string idVal = "";
               List<UserModel> userList = new List<UserModel>() { };       //Nonsense to initalize

               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);
                    SqlDataReader reader;

                    for (int i = 0; i < idList.Count; i++)
                    {
                         if (i != 0)
                              sqlStatement = sqlStatement + " OR";
                         idVal = "@id" + i;
                         sqlStatement = sqlStatement + " Id = " + idVal;

                         command.Parameters.Add(idVal, System.Data.SqlDbType.Int).Value = idList[i];
                    }
                    command.CommandText = sqlStatement;

                    try
                    {
                         connection.Open();

                         reader = command.ExecuteReader();
                         while (reader.Read())
                         {
                              userList.Add(new UserModel((int)reader["Id"], (string)reader["USERNAME"], (string)reader["PASSWORD"]));
                         }

                    }
                    catch (Exception e)
                    {
                         Console.WriteLine(e.Message);
                    }

               }

               return userList;
          }
     }

}
