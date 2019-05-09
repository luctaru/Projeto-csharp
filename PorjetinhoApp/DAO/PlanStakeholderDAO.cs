using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;
using PorjetinhoApp.model;

namespace PorjetinhoApp.DAO
{
    class PlanStakeholderDAO
    {
        private IList<PlanStakeholder> planStakeList = new List<PlanStakeholder>();

        public IList<PlanStakeholder> getRelations()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_interested_user";

            PlanStakeholder psk = new PlanStakeholder();
            UserDAO userDAO = new UserDAO();
            PlanDAO planDAO = new PlanDAO();

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
                        psk = new PlanStakeholder((int)reader[0], planDAO.getOnePlan((int)reader[1]), userDAO.getResponsible((int)reader[2]));

                        planStakeList.Add(psk);
                    }
                    reader.Close();
                    return this.planStakeList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.planStakeList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public IList<PlanStakeholder> getByUserId(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_interested_user WHERE id_user = @id";


            PlanStakeholder psk = null;
            UserDAO userDAO = new UserDAO();
            PlanDAO planDAO = new PlanDAO();

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
                        psk = new PlanStakeholder((int)reader[0], planDAO.getOnePlan((int)reader[1]), userDAO.getResponsible((int)reader[2]));
                        planStakeList.Add(psk);
                    }
                    reader.Close();
                    return this.planStakeList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.planStakeList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public IList<PlanStakeholder> getByPlanId(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
               "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_interested_user WHERE id_plan = @id";


            PlanStakeholder psk = null;
            UserDAO userDAO = new UserDAO();
            PlanDAO planDAO = new PlanDAO();

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
                        psk = new PlanStakeholder((int)reader[0], planDAO.getOnePlan((int)reader[1]), userDAO.getResponsible((int)reader[2]));
                        planStakeList.Add(psk);
                    }
                    reader.Close();
                    return this.planStakeList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.planStakeList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void exclude(int id)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "DELETE FROM plan_interested_user WHERE id = @id";

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

        public void insert(PlanStakeholder p)
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;Integrated Security=True";

            string sqlQuery = "INSERT INTO plan_interested_user VALUES (@idPlan, @idUser)";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@idPlan", p.Plan.Id);
                command.Parameters.AddWithValue("@idUser",p.User.Id);

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
