using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtilities_CS_yoni;

namespace SocialProject.Dal
{
    public class SqlQuery: BaseDal
    {
        public static string ConnectionString = @"Integrated Security=SSPI;   Persist Security Info=False;    Initial Catalog=Social_Project;  Data Source=localhost\sqlexpress";

        public SqlQuery(LogManager log) : base(log) { }

        public static DataTable Read_Table_FormDB(string Sql_Query)
        {
            try
            {
                Log.LogEvent(@"Dal \ SqlQuery \ Read_Table_FormDB ran Successfully - ");
                SqlDataAdapter adapter = new SqlDataAdapter(Sql_Query, ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                throw;
            }
          
        }

        public static void Write_ToDB(string Sql_Query)
        {
            try
            {
                Log.LogEvent(@"Dal \ SqlQuery \ Write_ToDB ran Successfully - ");
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
            catch (SqlException ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                throw;
            }
        }


        public static object Read_Scalar_FromDB(string SqlQuery)
        {
            try
            {
                Log.LogEvent(@"Dal \ SqlQuery \ Read_Scalar_FromDB ran Successfully - ");
                object result;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        connection.Open();

                        result = command.ExecuteScalar();
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                throw;
            }
        }

        public static void WriteWithValuesToDB(string query, Dictionary<string, object> parameters)
        {
            try
            {
                Log.LogEvent(@"Dal \ SqlQuery \ WriteWithValuesToDB ran Successfully - ");
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
                throw;
            }
        }
    }
}
