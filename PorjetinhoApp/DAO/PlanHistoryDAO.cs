using PorjetinhoApp.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PorjetinhoApp.DAO
{
    class PlanHistoryDAO
    {
        private IList<PlanHistory> planHistoryList = new List<PlanHistory>();

        public IList<PlanHistory> getHistory()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM plan_history";

            PlanStatusDAO psDAO = new PlanStatusDAO();
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
                        Plan p = planDAO.getOnePlan((int)reader[1]);
                        PlanStatus ps = psDAO.getOneStatus((int)reader[2]);

                        PlanHistory ph = new PlanHistory((int)reader[0], p, ps, (DateTime)reader[3]);

                        this.planHistoryList.Add(ph);
                    }
                    reader.Close();
                    return this.planHistoryList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.planHistoryList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
