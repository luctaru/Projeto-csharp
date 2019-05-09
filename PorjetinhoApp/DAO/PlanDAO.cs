using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;
using PorjetinhoApp.DAO;

namespace PorjetinhoApp
{
    class PlanDAO
    {
        private IList<Plan> planList = new List<Plan>();

        private SortedDictionary<int, User> dictionaryStakeholders
            = new SortedDictionary<int, User>();

        public IDictionary<int, User> getStakeholders(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT u.* FROM users AS u INNER JOIN plan_interested_user AS piu ON u.id = piu.id_user AND piu.id_plan = @id";

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
                        User u = new User((string)reader[1], (int)reader[0], (DateTime)reader[2], (DateTime)reader[3], (Boolean)reader[4], (Boolean)reader[5]);

                        this.dictionaryStakeholders.Add(u.Id, u);
                    }
                    reader.Close();
                    return this.dictionaryStakeholders;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: "+ex.Message);
                    return this.dictionaryStakeholders;
                }
                finally
                {
                    connection.Close();

                }

            }
        }

        public IList<Plan> getPlans()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plans";

            PlanTypeDAO ptDAO = new PlanTypeDAO();
            PlanStatusDAO psDAO = new PlanStatusDAO();
            UserDAO userDAO = new UserDAO();

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
                        PlanType pt = ptDAO.getOneType((int)reader[2]);
                        User u = userDAO.getResponsible((int)reader[3]);
                        PlanStatus pu = psDAO.getOneStatus((int)reader[4]);

                        Plan p = new Plan((string)reader[1], (int)reader[0], pt, u, pu,
                            (DateTime)reader[5], (DateTime)reader[6], (string)reader[7],
                            (decimal)reader[8]);

                        this.planList.Add(p);
                    }
                    reader.Close();
                    return this.planList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.planList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public Plan getOnePlan(int id)
        {
            Plan p = null;

            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plans WHERE id = @id";


            PlanTypeDAO ptDAO = new PlanTypeDAO();
            PlanStatusDAO psDAO = new PlanStatusDAO();
            UserDAO userDAO = new UserDAO();

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
                        PlanType pt = ptDAO.getOneType((int)reader[2]);
                        User u = userDAO.getResponsible((int)reader[3]);
                        PlanStatus pu = psDAO.getOneStatus((int)reader[4]);

                        p = new Plan((string)reader[1], (int)reader[0], pt, u, pu,
                            (DateTime)reader[5], (DateTime)reader[6], (string)reader[7],
                            (decimal)reader[8]);
                    }
                    reader.Close();
                    return p;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return p;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void excludePlan(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "DELETE FROM plans WHERE id = @id";

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

        public void insertPlan(Plan p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "INSERT INTO plans VALUES (@name, @idType, @idUser, @idStatus, @startDate, @endDate, @description, @cost)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@idType", p.Type.Id);
                command.Parameters.AddWithValue("@idUser", p.Responsible.Id);
                command.Parameters.AddWithValue("@idStatus", p.Status.Id);
                command.Parameters.AddWithValue("@startDate", p.StartDate);
                command.Parameters.AddWithValue("@endDate", p.EndDate);
                command.Parameters.AddWithValue("@description", p.Description);
                command.Parameters.AddWithValue("@cost", p.Cost);

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

        public void updatePlan(Plan p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "UPDATE plans SET name = @name, id_type = @idType, id_user = @idUser, id_status = @idStatus, start_date = @startDate, end_date = @endDate, description = @description, cost = @cost WHERE id = @id";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@idType", p.Type.Id);
                command.Parameters.AddWithValue("@idUser", p.Responsible.Id);
                command.Parameters.AddWithValue("@idStatus", p.Status.Id);
                command.Parameters.AddWithValue("@startDate", p.StartDate);
                command.Parameters.AddWithValue("@endDate", p.EndDate);
                command.Parameters.AddWithValue("@description", p.Description);
                command.Parameters.AddWithValue("@cost", p.Cost);
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

        //public IDictionary<int, User> getAll()
        //{
        //    string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
        //        "Integrated Security=True";

        //    string sqlQuery = "SELECT * FROM users";

        //    using (SqlConnection connection =
        //        new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(sqlQuery, connection);

        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                User u = new User((String)reader[1], (int)reader[0]);

        //                this.dictionaryStakeholders.Add((int)reader[0], u);
        //            }
        //            reader.Close();
        //            return this.dictionaryStakeholders;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            return null;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }

        //    }

        //}

    }
}
