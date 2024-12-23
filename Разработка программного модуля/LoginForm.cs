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
    using System.Security.Cryptography;

    namespace Разработка_программного_модуля
    {
        public partial class LoginForm : Form
        {
            private readonly string connectionString = "Host=localhost;Username=postgres;Password=danil2005;Database=repairdb";
            private readonly DatabaseHelper dbHelper;
            public string CurrentUserRole { get; private set; }

            public LoginForm()
            {
                InitializeComponent();
                dbHelper = new DatabaseHelper();
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите логин и пароль!");
                    return;
                }

                string query = "SELECT Роль FROM Пользователи WHERE Логин = @Логин AND Пароль = @Пароль";
                var parameters = new[]
                {
                    new NpgsqlParameter("@Логин", username),
                    new NpgsqlParameter("@Пароль", password)
                };

                DataTable result = dbHelper.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    CurrentUserRole = result.Rows[0]["Роль"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        }
    }

