using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_программного_модуля
{
    public partial class ExtendDeadlineForm : Form
    {
        private readonly int requestId;
        private readonly DatabaseHelper dbHelper;

        public ExtendDeadlineForm(int requestId)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Убедитесь, что dbHelper инициализирован
            this.requestId = requestId;
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            try
            {
                // Убедитесь, что requestId был передан и не равен 0
                if (requestId == 0)
                {
                    MessageBox.Show("Идентификатор заявки не задан.");
                    return;
                }

                // Проверка, что новая дата не пустая
                if (dtpNewDeadline.Value == null)
                {
                    MessageBox.Show("Пожалуйста, выберите новый срок выполнения.");
                    return;
                }

                // Убедитесь, что dbHelper инициализирован
                if (dbHelper == null)
                {
                    MessageBox.Show("Ошибка базы данных: не удалось инициализировать соединение.");
                    return;
                }

                // Подготовка SQL-запроса для обновления нового срока
                string query = @"
            UPDATE ЗаявкиНаРемонт 
            SET НовыйСрокВыполнения = @НовыйСрокВыполнения 
            WHERE Идентификатор = @Идентификатор";

                var parameters = new List<NpgsqlParameter>
        {
            new NpgsqlParameter("@НовыйСрокВыполнения", NpgsqlTypes.NpgsqlDbType.Date) { Value = dtpNewDeadline.Value },
            new NpgsqlParameter("@Идентификатор", NpgsqlTypes.NpgsqlDbType.Integer) { Value = requestId }
        };

                // Выполнение запроса с параметрами
                dbHelper.ExecuteNonQuery(query, parameters.ToArray());

                MessageBox.Show("Срок выполнения заявки продлен!");
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при обновлении срока заявки: {ex.Message}");
            }
        }

        // Метод для получения заявки по ее идентификатору
        private Request GetRequestById(int id)
        {
            try
            {
                string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=danil2005;Database=repairdb";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ЗаявкиНаРемонт WHERE Идентификатор = @Идентификатор";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Идентификатор", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Создаем объект заявки
                                var request = new Request
                                {
                                    Id = Convert.ToInt32(reader["Идентификатор"]),
                                    // Проверка на DBNull перед конвертацией
                                    Deadline = reader["ДатаВыполнения"] != DBNull.Value ? Convert.ToDateTime(reader["ДатаВыполнения"]) : DateTime.MinValue // Если NULL, задаем значение по умолчанию
                                };
                                return request;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении заявки: {ex.Message}");
            }
            return null;
        }

        // Метод для обновления заявки в базе данных
        private void UpdateRequest(Request request)
        {
            try
            {
                using (var conn = new NpgsqlConnection("YourConnectionString"))
                {
                    conn.Open();
                    string query = "UPDATE ЗаявкиНаРемонт SET ДатаВыполнения = @ДатаВыполнения WHERE Идентификатор = @Идентификатор";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ДатаВыполнения", request.Deadline);
                        cmd.Parameters.AddWithValue("@Идентификатор", request.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении заявки: {ex.Message}");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  // Закрытие формы при нажатии на кнопку
        }
    }
}
