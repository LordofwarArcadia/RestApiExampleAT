using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestApiExampleAutomatedTests.Framework
{
    
    using static Config;
    public class PGDatabaseConnector//: DatabaseConnector
    {
        /// <summary>
        /// This is for connecting to the *some* database 
        /// </summary>
        private static string ConnectionString = "Host=" + DbHost
                                                + ";Username=" + DbLogin
                                                + ";Password=" + DbPassword
                                                + ";Database=";

        private NpgsqlConnection conn;      //Connector
        private NpgsqlCommand cmd;
        /// <summary>
        /// By default, DatabaseConnector connects to the term_service database
        /// </summary>
        public PGDatabaseConnector() : this(DbTerm)
        {
        }
        /// <summary>
        /// Initialize the DatabaseConnector with selected database and null command
        /// </summary>
        /// <param name="DbName">There should be a string identifies the database name taken from the Config class, e.g. Config.DbUsers</param>
        public PGDatabaseConnector(string DbName)
        {
            conn = new NpgsqlConnection(ConnectionString + DbName);
            cmd = new NpgsqlCommand();

        }
        public PGDatabaseConnector(string _dbHost, string _username, string _password, string _dbName)
        {
            conn = new NpgsqlConnection($"Host={_dbHost};Username={_username};Password={_password};Database={_dbName}");
            cmd = new NpgsqlCommand();
        }

        public void DisposeConnection()
        {
            conn.Close();
        }
        public List<string> QueryExecutor(string Command)
        {
            conn.Open();
            List<string> result = new List<string>();
            cmd.CommandText = Command;
            cmd.Connection = conn;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StringBuilder row = new StringBuilder();
                for (int i = 0; i <= reader.FieldCount - 1; i++)
                    row.Append(reader[i].ToString());

                result.Add(row.ToString());
            }
            reader.Close();
            if (conn.State == ConnectionState.Open) conn.Close();
            return result;
        }
        public string QueryExecutorScalar(string Command)
        {
            conn.Open();
            cmd.CommandText = Command;
            cmd.Connection = conn;
            try
            {
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (NpgsqlException)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public DataTable QueryExecutorTable(string Command)
        {
            conn.Open();
            var dSet = new DataSet();
            var dt = new DataTable();
            var da = new NpgsqlDataAdapter(Command, conn);

            try
            {
                da.Fill(dSet);
                dt = dSet.Tables[0];
            }
            catch (NpgsqlException)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return dt;
        }

        public int NonQueryExecutor(string Command)
        {
            conn.Open();
            cmd.CommandText = Command;
            cmd.Connection = conn;
            var result = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            return result;

        }
    }
}
