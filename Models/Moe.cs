using Microsoft.Data.SqlClient;
using System.Data;

using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace cis4951.sprint.w41._4.Models
{
     public class dataAccess
     {
          public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
          {
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<T> rows = new List<T>();

                    while (reader.Read())
                    {
                         rows.Add((T)(IDataRecord)reader);
                    }

                    return rows;
               }               
          }
          /*public void SaveData<T>(string sql, T parameters, string connectionString)
          {
               using (IDbConnection connection = new MySqlConnection(connectionString))
               {
                    connection.Execute(sql, parameters);
               }
          }*/

          private static void ReadOrderData(string connectionString)
          {
               string queryString =
                   "SELECT OrderID, CustomerID FROM dbo.Orders;";

               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                         ReadSingleRow((IDataRecord)reader);
                    }

                    // Call Close when done reading.
                    reader.Close();
               }
          }

          private static void ReadSingleRow(IDataRecord dataRecord)
          {
               Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
          }


     }

}
