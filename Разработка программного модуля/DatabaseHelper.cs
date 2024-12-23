using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;


namespace Разработка_программного_модуля
{
    public class DatabaseHelper
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=danil2005;Database=repairdb";
        private NpgsqlConnection connection;

        public DatabaseHelper()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public void ExecuteNonQuery(string query, NpgsqlParameter[] parameters = null)
        {
            try
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query, NpgsqlParameter[] parameters = null)
        {
            var table = new DataTable();
            try
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
    }
}
