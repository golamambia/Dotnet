using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RMS.Data.Common
{
    internal static class DataAccess
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        internal static DataTable GetData(SqlCommand command)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
            return dataTable;
        }
    }
}
