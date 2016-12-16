namespace Agenda
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.Salva = new System.Windows.Forms.Button();
            this.checkMail = new System.Windows.Forms.CheckBox();
            this.checkSms = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefono";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(107, 24);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(158, 20);
            this.txtNome.TabIndex = 3;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(107, 54);
            this.txtMail.Margin = new System.Windows.Forms.Padding(2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(158, 20);
            this.txtMail.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(107, 82);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(158, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // Salva
            // 
            this.Salva.Location = new System.Drawing.Point(31, 170);
            this.Salva.Margin = new System.Windows.Forms.Padding(2);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(234, 36);
            this.Salva.TabIndex = 6;
            this.Salva.Text = "Salva";
            this.Salva.UseVisualStyleBackColor = true;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
            // 
            // checkMail
            // 
            this.checkMail.AutoSize = true;
            this.checkMail.Location = new System.Drawing.Point(123, 120);
            this.checkMail.Name = "checkMail";
            this.checkMail.Size = new System.Drawing.Size(45, 17);
            this.checkMail.TabIndex = 7;
            this.checkMail.Text = "Mail";
            this.checkMail.UseVisualStyleBackColor = true;
            // 
            // checkSms
            // 
            this.checkSms.AutoSize = true;
            this.checkSms.Location = new System.Drawing.Point(202, 120);
            this.checkSms.Name = "checkSms";
            this.checkSms.Size = new System.Drawing.Size(46, 17);
            this.checkSms.TabIndex = 8;
            this.checkSms.Text = "Sms";
            this.checkSms.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Modalità d\'invio";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 255);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkSms);
            this.Controls.Add(this.checkMail);
            this.Controls.Add(this.Salva);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Contatto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button Salva;
        private System.Windows.Forms.CheckBox checkMail;
        private System.Windows.Forms.CheckBox checkSms;
        private System.Windows.Forms.Label label4;
    }
}