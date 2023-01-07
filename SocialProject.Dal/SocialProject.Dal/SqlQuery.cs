using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Dal
{
    public class SqlQuery
    {
        public static string ConnectionString = @"Integrated Security=SSPI;   Persist Security Info=False;    Initial Catalog=Social_Project;  Data Source=localhost\sqlexpress";

        public static DataTable ReadTableFormDB(string Sql_Query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(Sql_Query, ConnectionString);    
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void WriteToDB(string Sql_Query)
        {
            //הפעלת הצינור לפי ההגדרות שמופיעות בקונקטשן סטרינג
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Sql_Query, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
