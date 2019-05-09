using PorjetinhoApp.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PorjetinhoApp.DAO
{
    class UserHistoryDAO
    {
        private IList<UserHistory> userHistoryList = new List<UserHistory>();

        public IList<UserHistory> getHistory()
        {
            string connectionString = "Data Source=FORLOGIC357;Initial Catalog=PLANNER;" +
                "Integrated Security=True";

            string sqlQuery = "SELECT * FROM user_history";

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
                        User u = userDAO.getResponsible((int)reader[1]);

                        Boolean statusAux = false;
                        Boolean canCreateAux = false;

                        if (reader[2] != DBNull.Value)
                        {
                            if((Boolean)reader[2])
                            {
                                statusAux = true;
                            }
                        }

                        if (reader[3] != DBNull.Value)
                        {
                            if ((Boolean)reader[3])
                            {
                                canCreateAux = true;
                            }
                        }

                        UserHistory uh = new UserHistory((int)reader[0], u, statusAux, canCreateAux, (DateTime)reader[4]);

                        this.userHistoryList.Add(uh);
                    }
                    reader.Close();
                    return this.userHistoryList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return this.userHistoryList;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
