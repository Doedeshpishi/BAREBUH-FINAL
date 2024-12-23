
namespace Разработка_программного_модуля
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождение ресурсов.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод, необходимый для поддержки конструктора.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.btnEditRequest = new System.Windows.Forms.Button();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.txtStatusSearch = new System.Windows.Forms.TextBox();
            this.btnSearchByStatus = new System.Windows.Forms.Button();
            this.btnShowAllRequests = new System.Windows.Forms.Button();
            this.btnUpdateStats = new System.Windows.Forms.Button();
            this.btnExtendDeadline = new System.Windows.Forms.Button();
            this.btnGenerateQRCode = new System.Windows.Forms.Button();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.txtQRCodeData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(11, 33);
            this.dgvRequests.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(668, 324);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRequests_CellFormatting);
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Location = new System.Drawing.Point(684, 33);
            this.btnAddRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(249, 40);
            this.btnAddRequest.TabIndex = 1;
            this.btnAddRequest.Text = "Добавить заявку";
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Location = new System.Drawing.Point(11, 396);
            this.btnEditRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(668, 33);
            this.btnEditRequest.TabIndex = 2;
            this.btnEditRequest.Text = "Редактировать заявку";
            this.btnEditRequest.UseVisualStyleBackColor = true;
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.Location = new System.Drawing.Point(684, 76);
            this.btnDeleteRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(249, 40);
            this.btnDeleteRequest.TabIndex = 3;
            this.btnDeleteRequest.Text = "Удалить заявку";
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            this.btnDeleteRequest.Click += new System.EventHandler(this.btnDeleteRequest_Click);
            // 
            // txtStatusSearch
            // 
            this.txtStatusSearch.Location = new System.Drawing.Point(11, 8);
            this.txtStatusSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatusSearch.Name = "txtStatusSearch";
            this.txtStatusSearch.Size = new System.Drawing.Size(226, 20);
            this.txtStatusSearch.TabIndex = 0;
            // 
            // btnSearchByStatus
            // 
            this.btnSearchByStatus.Location = new System.Drawing.Point(241, 8);
            this.btnSearchByStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchByStatus.Name = "btnSearchByStatus";
            this.btnSearchByStatus.Size = new System.Drawing.Size(85, 20);
            this.btnSearchByStatus.TabIndex = 1;
            this.btnSearchByStatus.Text = "Поиск";
            this.btnSearchByStatus.UseVisualStyleBackColor = true;
            this.btnSearchByStatus.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAllRequests
            // 
            this.btnShowAllRequests.Location = new System.Drawing.Point(331, 8);
            this.btnShowAllRequests.Name = "btnShowAllRequests";
            this.btnShowAllRequests.Size = new System.Drawing.Size(102, 20);
            this.btnShowAllRequests.TabIndex = 2;
            this.btnShowAllRequests.Text = "Показать все";
            this.btnShowAllRequests.UseVisualStyleBackColor = true;
            this.btnShowAllRequests.Click += new System.EventHandler(this.btnShowAllRequests_Click);
            // 
            // btnUpdateStats
            // 
            this.btnUpdateStats.Location = new System.Drawing.Point(12, 361);
            this.btnUpdateStats.Name = "btnUpdateStats";
            this.btnUpdateStats.Size = new System.Drawing.Size(667, 30);
            this.btnUpdateStats.TabIndex = 4;
            this.btnUpdateStats.Text = "Обновить статистику";
            this.btnUpdateStats.UseVisualStyleBackColor = true;
            this.btnUpdateStats.Click += new System.EventHandler(this.btnUpdateStats_Click);
            // 
            // btnExtendDeadline
            // 
            this.btnExtendDeadline.Location = new System.Drawing.Point(684, 121);
            this.btnExtendDeadline.Name = "btnExtendDeadline";
            this.btnExtendDeadline.Size = new System.Drawing.Size(249, 43);
            this.btnExtendDeadline.TabIndex = 2;
            this.btnExtendDeadline.Text = "Продлить срок выполнения";
            this.btnExtendDeadline.UseVisualStyleBackColor = true;
            this.btnExtendDeadline.Click += new System.EventHandler(this.btnExtendDeadline_Click);
            // 
            // btnGenerateQRCode
            // 
            this.btnGenerateQRCode.Location = new System.Drawing.Point(685, 170);
            this.btnGenerateQRCode.Name = "btnGenerateQRCode";
            this.btnGenerateQRCode.Size = new System.Drawing.Size(248, 37);
            this.btnGenerateQRCode.TabIndex = 0;
            this.btnGenerateQRCode.Text = "Сгенерировать QR-код для отзыва";
            this.btnGenerateQRCode.UseVisualStyleBackColor = true;
            this.btnGenerateQRCode.Click += new System.EventHandler(this.BtnGenerateQRCode_Click);
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(685, 232);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(344, 314);
            this.pictureBoxQRCode.TabIndex = 1;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // txtQRCodeData
            // 
            this.txtQRCodeData.Location = new System.Drawing.Point(685, 206);
            this.txtQRCodeData.Name = "txtQRCodeData";
            this.txtQRCodeData.Size = new System.Drawing.Size(248, 20);
            this.txtQRCodeData.TabIndex = 2;
            this.txtQRCodeData.Text = "https://docs.google.com/forms/d/e/1FAIpQLSdTHqWZYRUzxuaHxWqljrOtU08gz7TkY1kcITci-" +
    "K_AEm7Smg/viewform?usp=dialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 546);
            this.Controls.Add(this.btnDeleteRequest);
            this.Controls.Add(this.btnEditRequest);
            this.Controls.Add(this.btnAddRequest);
            this.Controls.Add(this.btnSearchByStatus);
            this.Controls.Add(this.txtStatusSearch);
            this.Controls.Add(this.btnShowAllRequests);
            this.Controls.Add(this.btnUpdateStats);
            this.Controls.Add(this.btnExtendDeadline);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.txtQRCodeData);
            this.Controls.Add(this.pictureBoxQRCode);
            this.Controls.Add(this.btnGenerateQRCode);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Учет заявок на ремонт оборудования";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.Button btnEditRequest;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.TextBox txtStatusSearch;
        private System.Windows.Forms.Button btnSearchByStatus;
        private System.Windows.Forms.Button btnShowAllRequests;
        private System.Windows.Forms.Button btnUpdateStats;
        private System.Windows.Forms.Button btnExtendDeadline;
        private System.Windows.Forms.Button btnGenerateQRCode;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.TextBox txtQRCodeData;


    }
}

