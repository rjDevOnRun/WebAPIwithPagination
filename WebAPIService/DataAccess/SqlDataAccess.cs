using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebAPIService.DataAccess
{
    public class SqlDataAccess
    {
        public static DataTable LoadData(string sqlQuery)
        {
            // Get Connection String to DB
            var connectionString = $"Data Source=RJI5PC; Initial Catalog = Northwind; User ID = sa; Password = Ladyinblue@123";

            // Build an Query
            sqlQuery = string.IsNullOrEmpty(sqlQuery) ? $"SELECT * FROM ContactList" : sqlQuery;

            DataTable dt = new DataTable();
            try
            {

                // Init
                SqlConnection sqlConnection = null;
                // Establish connection (will dispose automatically)
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    // Open connection
                    sqlConnection.Open();

                    // Init Command
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    // Execute the Query
                    IDataReader dr = sqlCommand.ExecuteReader();


                    dt.Load(dr, LoadOption.OverwriteChanges);
                    dr.Close();

                }
                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message + ex.StackTrace);
                return dt;
            }
        }

    }
}
