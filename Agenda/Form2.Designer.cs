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
            this.label4 = new System.Windows.Forms.Label();
            this.messageTypes = new System.Windows.Forms.CheckedListBox();
            this.btnVisualizzaMessaggi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefono";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(143, 30);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(209, 22);
            this.txtNome.TabIndex = 3;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(143, 66);
            this.txtMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(209, 22);
            this.txtMail.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(143, 101);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(209, 22);
            this.txtTelefono.TabIndex = 5;
            // 
            // Salva
            // 
            this.Salva.Location = new System.Drawing.Point(40, 384);
            this.Salva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(312, 44);
            this.Salva.TabIndex = 6;
            this.Salva.Text = "Salva";
            this.Salva.UseVisualStyleBackColor = true;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Modalità d\'invio";
            // 
            // messageTypes
            // 
            this.messageTypes.FormattingEnabled = true;
            this.messageTypes.Location = new System.Drawing.Point(143, 149);
            this.messageTypes.Name = "messageTypes";
            this.messageTypes.Size = new System.Drawing.Size(209, 89);
            this.messageTypes.TabIndex = 10;
            // 
            // btnVisualizzaMessaggi
            // 
            this.btnVisualizzaMessaggi.Location = new System.Drawing.Point(40, 320);
            this.btnVisualizzaMessaggi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVisualizzaMessaggi.Name = "btnVisualizzaMessaggi";
            this.btnVisualizzaMessaggi.Size = new System.Drawing.Size(312, 44);
            this.btnVisualizzaMessaggi.TabIndex = 11;
            this.btnVisualizzaMessaggi.Text = "Visualizza messaggi";
            this.btnVisualizzaMessaggi.UseVisualStyleBackColor = true;
            this.btnVisualizzaMessaggi.Click += new System.EventHandler(this.btnVisualizzaMessaggi_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 481);
            this.Controls.Add(this.btnVisualizzaMessaggi);
            this.Controls.Add(this.messageTypes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Salva);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox messageTypes;
        private System.Windows.Forms.Button btnVisualizzaMessaggi;
    }
}