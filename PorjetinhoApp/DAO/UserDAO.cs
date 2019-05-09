using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;

namespace PorjetinhoApp.DAO
{
    class UserDAO
    {
        private IList<User> userList = new List<User>();

        public User getResponsible(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM users WHERE id = @id";

            User u = null;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        u = new User((string)reader[1], (int)reader[0], (DateTime)reader[2], (DateTime)reader[3], (Boolean)reader[4], (Boolean)reader[5]);

                    }
                    reader.Close();
                    return u;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return u;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public IList<User> getUser()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM users";

            User u = null;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        u = new User((string)reader[1], (int)reader[0], (DateTime)reader[2], (DateTime)reader[3], (Boolean)reader[4], (Boolean)reader[5]);

                        this.userList.Add(u);
                    }
                    reader.Close();
                    return this.userList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.userList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void excludeUser(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "DELETE FROM users WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void insertUser(User u)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "INSERT INTO users VALUES (@name, GETDATE(), GETDATE(), @canCreatePlan, 0)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", u.Name);
                command.Parameters.AddWithValue("@canCreatePlan", u.CanCreatePlan);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void updateUser(User u)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "UPDATE users SET name = @name WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", u.Name);
                command.Parameters.AddWithValue("@id", u.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
