using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;

namespace PorjetinhoApp.DAO
{
    class PlanStatusDAO
    {
        private IList<PlanStatus> statusList = new List<PlanStatus>();

        public PlanStatus getOneStatus(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_status WHERE id = @id";

            PlanStatus ps = null;

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
                        ps = new PlanStatus((string)reader[1], (int)reader[0]);

                    }
                    reader.Close();
                    return ps;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ps;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public IList<PlanStatus> getStatus()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_status";

            PlanStatus ps = null;

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
                        ps = new PlanStatus((string)reader[1], (int)reader[0]);

                        this.statusList.Add(ps);
                    }
                    reader.Close();
                    return this.statusList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.statusList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void excludeStatus(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "DELETE FROM plan_status WHERE id = @id";

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

        public void insertStatus(PlanStatus p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "INSERT INTO plan_status VALUES (@name)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", p.Name);

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

        public void updateStatus(PlanStatus p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "UPDATE plan_status SET name = @name WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@id", p.Id);

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
