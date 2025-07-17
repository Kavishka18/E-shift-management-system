using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Shift_Management_Sytem.DB
{
    class DatabaseConnection
    {
        //private static string connectionString = "Server=database-1.cb0w4qy62yea.eu-north-1.rds.amazonaws.com\r\n;Database=Kavishka;User Id=admin;Password=ESOFT2025TopUp";

        private static string connectionString = "Data Source=DESKTOP-SEFLEBJ;Initial Catalog=GrifindoToysSystem;Integrated Security=True"; 

        // Method to execute queries that don't return data (Insert, Update, Delete)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Method to execute queries that return data (Select)
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
