namespace Разработка_программного_модуля
{
    partial class ExtendDeadlineForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNewDeadline;
        private System.Windows.Forms.DateTimePicker dtpNewDeadline;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNewDeadline = new System.Windows.Forms.Label();
            this.dtpNewDeadline = new System.Windows.Forms.DateTimePicker();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblNewDeadline
            this.lblNewDeadline.AutoSize = true;
            this.lblNewDeadline.Location = new System.Drawing.Point(12, 9);
            this.lblNewDeadline.Name = "lblNewDeadline";
            this.lblNewDeadline.Size = new System.Drawing.Size(211, 13);
            this.lblNewDeadline.TabIndex = 0;
            this.lblNewDeadline.Text = "Выберите новый срок выполнения заявки:";

            // dtpNewDeadline
            this.dtpNewDeadline.Location = new System.Drawing.Point(12, 25);
            this.dtpNewDeadline.Name = "dtpNewDeadline";
            this.dtpNewDeadline.Size = new System.Drawing.Size(260, 20);
            this.dtpNewDeadline.TabIndex = 1;

            // btnExtend
            this.btnExtend.Location = new System.Drawing.Point(12, 60);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(75, 23);
            this.btnExtend.TabIndex = 2;
            this.btnExtend.Text = "Продлить";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(197, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ExtendDeadlineForm
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.dtpNewDeadline);
            this.Controls.Add(this.lblNewDeadline);
            this.Name = "ExtendDeadlineForm";
            this.Text = "Продление срока";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}