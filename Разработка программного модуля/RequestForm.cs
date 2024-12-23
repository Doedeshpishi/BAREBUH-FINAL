using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Разработка_программного_модуля
{
    public partial class RequestForm : Form
    {
        private readonly DatabaseHelper dbHelper;
        private int? requestId = null;

        // Конструктор для добавления новой заявки
        public RequestForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        // Конструктор для редактирования заявки
        public RequestForm(int requestId)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.requestId = requestId;
            LoadRequestData();
        }

        /// <summary>
        /// Загрузка данных заявки для редактирования
        /// </summary>
        private void LoadRequestData()
        {
            if (requestId.HasValue)
            {
                string query = "SELECT * FROM ЗаявкиНаРемонт WHERE Идентификатор = @Идентификатор";
                var parameters = new[]
                {
                    new NpgsqlParameter("@Идентификатор", requestId.Value)
                };

                DataTable table = dbHelper.ExecuteQuery(query, parameters);
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];

                    // Заполняем поля формы данными заявки
                    txtEquipment.Text = row["Оборудование"].ToString();
                    cmbFaultType.SelectedItem = row["ТипНеисправности"].ToString();
                    txtDescription.Text = row["ОписаниеПроблемы"].ToString();
                    txtClient.Text = row["Клиент"].ToString();
                    cmbStatus.SelectedItem = row["Статус"].ToString();
                    dtpRequestDate.Value = Convert.ToDateTime(row["ДатаДобавления"]);
                }
            }
        }

        /// <summary>
        /// Сохранение данных заявки в базу данных
        /// </summary>
        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(txtEquipment.Text) ||
                string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtClient.Text) ||
                string.IsNullOrEmpty(txtResponsible.Text) || // Проверка заполненности нового поля
                string.IsNullOrEmpty(txtComments.Text) ||    // Проверка заполненности нового поля
                cmbFaultType.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            // Собираем данные из полей
            string equipment = txtEquipment.Text;
            string faultType = cmbFaultType.SelectedItem.ToString();
            string description = txtDescription.Text;
            string client = txtClient.Text;
            string status = cmbStatus.SelectedItem.ToString();
            DateTime requestDate = dtpRequestDate.Value;
            string responsible = txtResponsible.Text; // Новый параметр
            string comments = txtComments.Text;       // Новый параметр

            string query;
            NpgsqlParameter[] parameters;

            // Если это новая заявка, формируем запрос на добавление
            if (!requestId.HasValue)
            {
                query = @"
            INSERT INTO ЗаявкиНаРемонт 
            (
                Оборудование, ТипНеисправности, ОписаниеПроблемы, Клиент, Статус, 
                ДатаДобавления, Ответственный, Комментарии
            ) 
            VALUES 
            (
                @Оборудование, @ТипНеисправности, @ОписаниеПроблемы, @Клиент, @Статус, 
                @ДатаДобавления, @Ответственный, @Комментарии
            )";
                parameters = new[]
                {
            new NpgsqlParameter("@Оборудование", equipment),
            new NpgsqlParameter("@ТипНеисправности", faultType),
            new NpgsqlParameter("@ОписаниеПроблемы", description),
            new NpgsqlParameter("@Клиент", client),
            new NpgsqlParameter("@Статус", status),
            new NpgsqlParameter("@ДатаДобавления", requestDate),
            new NpgsqlParameter("@Ответственный", responsible),
            new NpgsqlParameter("@Комментарии", comments)
        };
            }
            else
            {
                // Если это редактирование заявки, формируем запрос на обновление
                query = @"
            UPDATE ЗаявкиНаРемонт 
            SET 
                Оборудование = @Оборудование, 
                ТипНеисправности = @ТипНеисправности, 
                ОписаниеПроблемы = @ОписаниеПроблемы, 
                Клиент = @Клиент, 
                Статус = @Статус, 
                ДатаДобавления = @ДатаДобавления, 
                Ответственный = @Ответственный, 
                Комментарии = @Комментарии
            WHERE Идентификатор = @Идентификатор";
                parameters = new[]
                {
            new NpgsqlParameter("@Оборудование", equipment),
            new NpgsqlParameter("@ТипНеисправности", faultType),
            new NpgsqlParameter("@ОписаниеПроблемы", description),
            new NpgsqlParameter("@Клиент", client),
            new NpgsqlParameter("@Статус", status),
            new NpgsqlParameter("@ДатаДобавления", requestDate),
            new NpgsqlParameter("@Ответственный", responsible),
            new NpgsqlParameter("@Комментарии", comments),
            new NpgsqlParameter("@Идентификатор", requestId.Value)
        };
            }

            // Выполняем запрос для сохранения данных в базе данных
            try
            {
                dbHelper.ExecuteNonQuery(query, parameters);  // Вставка или обновление данных в базе
                MessageBox.Show("Заявка успешно сохранена!");  // Уведомление об успешном сохранении
                this.DialogResult = DialogResult.OK;  // Закрытие формы с возвратом результата
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении заявки: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы без сохранения
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
