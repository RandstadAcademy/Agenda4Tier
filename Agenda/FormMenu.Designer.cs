namespace Agenda
{
    partial class FormMenu
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
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnRegistrazione = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgenda
            // 
            this.btnAgenda.Location = new System.Drawing.Point(74, 84);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(173, 44);
            this.btnAgenda.TabIndex = 0;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // btnRegistrazione
            // 
            this.btnRegistrazione.Location = new System.Drawing.Point(74, 134);
            this.btnRegistrazione.Name = "btnRegistrazione";
            this.btnRegistrazione.Size = new System.Drawing.Size(173, 44);
            this.btnRegistrazione.TabIndex = 1;
            this.btnRegistrazione.Text = "Registra utente";
            this.btnRegistrazione.UseVisualStyleBackColor = true;
            this.btnRegistrazione.Click += new System.EventHandler(this.btnRegistrazione_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 272);
            this.Controls.Add(this.btnRegistrazione);
            this.Controls.Add(this.btnAgenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnRegistrazione;
    }
}