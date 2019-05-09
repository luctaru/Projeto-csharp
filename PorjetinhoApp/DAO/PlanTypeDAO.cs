using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;

namespace PorjetinhoApp
{
    class PlanTypeDAO
    {
        private IList<PlanType> typeList = new List<PlanType>();

        public PlanType getOneType(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_type WHERE id = @id";

            PlanType pt = null;

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
                        pt = new PlanType((string)reader[1], (int)reader[0]);

                    }
                    reader.Close();
                    return pt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return pt;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public IList<PlanType> getType()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_type";

            PlanType pt = null;

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
                        pt = new PlanType((string)reader[1], (int)reader[0]);

                        this.typeList.Add(pt);
                    }
                    reader.Close();
                    return this.typeList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.typeList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void excludeType(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "DELETE FROM plan_type WHERE id = @id";

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

        public void insertType(PlanType p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "INSERT INTO plan_type VALUES (@name)";

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

        public void updateType(PlanType p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "UPDATE plan_type SET name = @name WHERE id = @id";

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
