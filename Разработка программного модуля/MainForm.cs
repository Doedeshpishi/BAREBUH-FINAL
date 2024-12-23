using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using QRCoder;


namespace Разработка_программного_модуля
{
    public partial class MainForm : Form
    {
        // Строка подключения к базе данных PostgreSQL
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=danil2005;Database=repairdb"; // Укажите свой пароль
        private readonly DatabaseHelper dbHelper; // Объявление dbHelper
        public MainForm(string role)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Инициализация dbHelper

            LoadRequests();

            if (role == "Пользователь")
            {
                btnAddRequest.Visible = false;
                btnEditRequest.Visible = false;
                btnDeleteRequest.Visible = false;
                btnUpdateStats.Visible = false;
                btnExtendDeadline.Visible = false;   // Кнопка для продления срока
                txtQRCodeData.Visible = false;
            }
            else if (role == "Менеджер")
            {
                btnAddRequest.Visible = false;
                btnDeleteRequest.Visible = false;
                btnGenerateQRCode.Visible = false;
                txtQRCodeData.Visible = false;
            }
            if (role == "Менеджер")
            {
                btnExtendDeadline.Visible = true;   // Кнопка для продления срока
            }

        }

        /// <summary>
        /// Загружает все заявки из базы данных и отображает их в DataGridView.
        /// </summary>
        private void LoadRequests()
        {
            try
            {
                var query = "SELECT * FROM ЗаявкиНаРемонт"; // SQL-запрос для получения всех заявок
                var dataTable = ExecuteQuery(query); // Выполнение запроса и получение данных
                dgvRequests.DataSource = dataTable;
                dgvRequests.CellFormatting += dgvRequests_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выполнение SQL-запроса и возврат результатов в виде DataTable.
        /// </summary>
        private DataTable ExecuteQuery(string query)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var dataTable = new DataTable();
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return dataTable;
            }
        }

        /// <summary>
        /// Выполнение SQL-запроса без возврата данных (например, для удаления).
        /// </summary>
        private void ExecuteNonQuery(string query, NpgsqlParameter[] parameters)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        command.ExecuteNonQuery(); // Выполняем запрос без возврата данных
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки "Добавить заявку".
        /// </summary>
        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            var addForm = new RequestForm(); // Создаем форму для добавления заявки
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadRequests(); // Обновляем список заявок после добавления
            }
        }

        /// <summary>
        /// Обработчик кнопки "Редактировать заявку".
        /// </summary>
        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRequests.SelectedRows[0];
                var requestId = (int)selectedRow.Cells["Идентификатор"].Value; // Получаем ID выбранной заявки
                var editForm = new RequestForm(requestId); // Открываем форму для редактирования
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRequests(); // Обновляем список заявок после редактирования
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить заявку".
        /// </summary>
        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var row = dgvRequests.SelectedRows[0];
                var requestId = (int)row.Cells["Идентификатор"].Value;

                // Удаление записи
                var deleteQuery = "DELETE FROM ЗаявкиНаРемонт WHERE Идентификатор = @Идентификатор";
                var deleteParams = new[]
                {
            new NpgsqlParameter("@Идентификатор", requestId)
            };
                dbHelper.ExecuteNonQuery(deleteQuery, deleteParams);

                // Синхронизация последовательностей
                var resetIdSequenceQuery = "SELECT setval('ЗаявкиНаРемонт_Идентификатор_seq', (SELECT COALESCE(MAX(\"Идентификатор\"), 1) FROM \"ЗаявкиНаРемонт\"), false)";
                var resetNumSequenceQuery = "SELECT setval('ЗаявкиНаРемонт_НомерЗаявки_seq', (SELECT COALESCE(MAX(\"НомерЗаявки\")::integer, 1) FROM \"ЗаявкиНаРемонт\"), false)";

                dbHelper.ExecuteNonQuery(resetIdSequenceQuery);
                dbHelper.ExecuteNonQuery(resetNumSequenceQuery);

                // Перезагрузка списка заявок
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления.");
            }
        }
        private void SearchRequests(string searchQuery)
        {
            var query = "SELECT * FROM \"ЗаявкиНаРемонт\" WHERE \"НомерЗаявки\" LIKE @SearchQuery";
            var parameters = new[]
            {
        new NpgsqlParameter("@SearchQuery", "%" + searchQuery + "%")
        };

            var table = dbHelper.ExecuteQuery(query, parameters);
            dgvRequests.DataSource = table;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtStatusSearch.Text.Trim(); // Получаем текст из текстового поля
            string query;

            if (int.TryParse(searchText, out int номерЗаявки))
            {
                // Если введённое значение - это число, ищем по "НомерЗаявки"
                query = "SELECT * FROM \"ЗаявкиНаРемонт\" WHERE \"НомерЗаявки\" = @searchValue";

                var parameters = new[]
                {
            new NpgsqlParameter("@searchValue", номерЗаявки) // Передаём как integer
        };

                var table = dbHelper.ExecuteQuery(query, parameters);
                dgvRequests.DataSource = table;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Заявки с указанным номером не найдены.", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Если введённое значение - не число, ищем по другим параметрам
                query = "SELECT * FROM \"ЗаявкиНаРемонт\" WHERE \"Оборудование\" ILIKE @searchValue OR \"ТипНеисправности\" ILIKE @searchValue OR \"Клиент\" ILIKE @searchValue";

                var parameters = new[]
                {
            new NpgsqlParameter("@searchValue", $"%{searchText}%") // Используем подстановки для текстового поиска
        };

                var table = dbHelper.ExecuteQuery(query, parameters);
                dgvRequests.DataSource = table;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Заявки по указанным параметрам не найдены.", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что это колонка со статусом
            if (dgvRequests.Columns[e.ColumnIndex].Name == "Статус")
            {
                string статус = e.Value?.ToString();
                if (статус == "В работе")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (статус == "Выполнено")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void btnShowAllRequests_Click(object sender, EventArgs e)
        {
            LoadRequests();  // Метод для загрузки всех заявок
        }
        private void UpdateStatistics()
        {
            try
            {
                string updateCompletedQuery = @"
            UPDATE ""Статистика""
            SET ""КоличествоВыполненных"" = (
                SELECT COUNT(*) FROM ""ЗаявкиНаРемонт"" WHERE ""Статус"" = 'Выполнено'
            );";

                string updateAvgTimeQuery = @"
            UPDATE ""Статистика""
            SET ""СреднееВремяВыполнения"" = (
                SELECT AVG(""ДатаВыполнения"" - ""ДатаДобавления"")
                FROM ""ЗаявкиНаРемонт""
                WHERE ""Статус"" = 'Выполнено'
            );";

                string updateFaultTypeQuery = @"
            INSERT INTO ""Статистика"" (""ТипНеисправности"", ""КоличествоПоТипу"")
            SELECT ""ТипНеисправности"", COUNT(*)
            FROM ""ЗаявкиНаРемонт""
            GROUP BY ""ТипНеисправности""
            ON CONFLICT (""ТипНеисправности"")
            DO UPDATE SET ""КоличествоПоТипу"" = EXCLUDED.""КоличествоПоТипу"";";

                dbHelper.ExecuteNonQuery(updateCompletedQuery);
                dbHelper.ExecuteNonQuery(updateAvgTimeQuery);
                dbHelper.ExecuteNonQuery(updateFaultTypeQuery);

                MessageBox.Show("Статистика успешно обновлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении статистики: " + ex.Message);
            }
        }
        private void btnUpdateStats_Click(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void btnExtendDeadline_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRequests.SelectedRows[0];
                var requestId = (int)selectedRow.Cells["Идентификатор"].Value;

                var extendForm = new ExtendDeadlineForm(requestId); // Форма для продления срока
                extendForm.ShowDialog();

                // После продления срока обновляем таблицу
                LoadRequests();
            }
        }
        private void BtnGenerateQRCode_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстового поля
            string qrCodeText = this.txtQRCodeData.Text;

            if (string.IsNullOrEmpty(qrCodeText))
            {
                MessageBox.Show("Введите данные для генерации QR-кода.");
                return;
            }

            try
            {
                // Генерация QR-кода с помощью QRCoder
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q); // Создаем данные QR

                // Генерация QR-кода как изображение
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5); // 20 - это размер пикселей QR-кода

                // Отображаем QR-код в PictureBox
                pictureBoxQRCode.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации QR-кода: " + ex.Message);
            }
        }
    }
}