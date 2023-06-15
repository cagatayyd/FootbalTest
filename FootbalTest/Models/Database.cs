using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace FootballTeam.Models
{
    public class Database : IDisposable
    {
        private readonly string connectionString;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void executeNonQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public List<T> List<T>(string query, Func<SqlDataReader, T> mapFunc) //SQL sorgusundan dönen verileri bir C# Generic List'ine dönüştürmek için kullanılmış
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())

                        while (reader.Read())
                        {
                            T item = mapFunc(reader);
                            list.Add(item);
                        }
                }
            }

            return list;
        }

        public void Dispose()
        {
            //
        }
    }
}
