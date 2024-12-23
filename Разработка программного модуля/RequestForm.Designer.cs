namespace Разработка_программного_модуля
{
    partial class RequestForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождение всех используемых ресурсов.
        /// </summary>
        /// <param name="disposing">true, если управляемые ресурсы должны быть освобождены; иначе false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором формы

        private void InitializeComponent()
        {
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.cmbFaultType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveRequest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.lblFaultType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(150, 30);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(200, 20);
            this.txtEquipment.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 1;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(150, 170);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(200, 20);
            this.txtClient.TabIndex = 2;
            // 
            // cmbFaultType
            // 
            this.cmbFaultType.FormattingEnabled = true;
            this.cmbFaultType.Items.AddRange(new object[] {
            "Механическая неисправность",
            "Электрическая неисправность",
            "Программная неисправность"});
            this.cmbFaultType.Location = new System.Drawing.Point(150, 210);
            this.cmbFaultType.Name = "cmbFaultType";
            this.cmbFaultType.Size = new System.Drawing.Size(200, 21);
            this.cmbFaultType.TabIndex = 3;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "В работе",
            "Выполнено"});
            this.cmbStatus.Location = new System.Drawing.Point(150, 250);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.Location = new System.Drawing.Point(150, 380);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRequestDate.TabIndex = 5;
            // 
            // btnSaveRequest
            // 
            this.btnSaveRequest.Location = new System.Drawing.Point(150, 406);
            this.btnSaveRequest.Name = "btnSaveRequest";
            this.btnSaveRequest.Size = new System.Drawing.Size(100, 30);
            this.btnSaveRequest.TabIndex = 6;
            this.btnSaveRequest.Text = "Сохранить";
            this.btnSaveRequest.UseVisualStyleBackColor = true;
            this.btnSaveRequest.Click += new System.EventHandler(this.btnSaveRequest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(40, 30);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(80, 13);
            this.lblEquipment.TabIndex = 8;
            this.lblEquipment.Text = "Оборудование";
            // 
            // lblFaultType
            // 
            this.lblFaultType.AutoSize = true;
            this.lblFaultType.Location = new System.Drawing.Point(40, 210);
            this.lblFaultType.Name = "lblFaultType";
            this.lblFaultType.Size = new System.Drawing.Size(106, 13);
            this.lblFaultType.TabIndex = 9;
            this.lblFaultType.Text = "Тип неисправности";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(32, 112);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(112, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Описание проблемы";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(40, 170);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(43, 13);
            this.lblClient.TabIndex = 11;
            this.lblClient.Text = "Клиент";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(40, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Статус";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(40, 380);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(96, 13);
            this.lblRequestDate.TabIndex = 13;
            this.lblRequestDate.Text = "Дата добавления";
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(40, 295);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(89, 13);
            this.lblResponsible.TabIndex = 8;
            this.lblResponsible.Text = "Ответственный:";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(150, 288);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(200, 20);
            this.txtResponsible.TabIndex = 9;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(40, 339);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(80, 13);
            this.lblComments.TabIndex = 10;
            this.lblComments.Text = "Комментарии:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(150, 314);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(200, 60);
            this.txtComments.TabIndex = 11;
            // 
            // RequestForm
            // 
            this.ClientSize = new System.Drawing.Size(624, 550);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFaultType);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveRequest);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbFaultType);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtEquipment);
            this.Controls.Add(this.lblResponsible);
            this.Controls.Add(this.txtResponsible);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.txtComments);
            this.Name = "RequestForm";
            this.Text = "Добавление заявки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEquipment;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.ComboBox cmbFaultType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Button btnSaveRequest;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.Label lblFaultType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.TextBox txtComments;
    }
}