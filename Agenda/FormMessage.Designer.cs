namespace Agenda
{
    partial class FormMessage
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
            this.txtboxMsg = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtboxObjectMsg = new System.Windows.Forms.TextBox();
            this.lblNameContactSummary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.typeMsgSummary = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTypeMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oggetto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Messaggio:";
            // 
            // txtboxMsg
            // 
            this.txtboxMsg.Location = new System.Drawing.Point(121, 140);
            this.txtboxMsg.Name = "txtboxMsg";
            this.txtboxMsg.Size = new System.Drawing.Size(301, 202);
            this.txtboxMsg.TabIndex = 3;
            this.txtboxMsg.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome contatto:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtboxObjectMsg
            // 
            this.txtboxObjectMsg.Location = new System.Drawing.Point(121, 104);
            this.txtboxObjectMsg.Name = "txtboxObjectMsg";
            this.txtboxObjectMsg.Size = new System.Drawing.Size(301, 22);
            this.txtboxObjectMsg.TabIndex = 1;
            // 
            // lblNameContactSummary
            // 
            this.lblNameContactSummary.AutoSize = true;
            this.lblNameContactSummary.Location = new System.Drawing.Point(150, 37);
            this.lblNameContactSummary.Name = "lblNameContactSummary";
            this.lblNameContactSummary.Size = new System.Drawing.Size(0, 17);
            this.lblNameContactSummary.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tipo messaggio:";
            // 
            // typeMsgSummary
            // 
            this.typeMsgSummary.AutoSize = true;
            this.typeMsgSummary.Location = new System.Drawing.Point(150, 70);
            this.typeMsgSummary.Name = "typeMsgSummary";
            this.typeMsgSummary.Size = new System.Drawing.Size(0, 17);
            this.typeMsgSummary.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(388, 54);
            this.button1.TabIndex = 8;
            this.button1.Text = "Invia messaggio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTypeMsg
            // 
            this.lblTypeMsg.AutoSize = true;
            this.lblTypeMsg.Location = new System.Drawing.Point(149, 70);
            this.lblTypeMsg.Name = "lblTypeMsg";
            this.lblTypeMsg.Size = new System.Drawing.Size(36, 17);
            this.lblTypeMsg.TabIndex = 9;
            this.lblTypeMsg.Text = "Tipo";
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 456);
            this.Controls.Add(this.lblTypeMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typeMsgSummary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNameContactSummary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtboxMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxObjectMsg);
            this.Controls.Add(this.label1);
            this.Name = "FormMessage";
            this.Text = "Invia Messaggio";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtboxMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtboxObjectMsg;
        private System.Windows.Forms.Label lblNameContactSummary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label typeMsgSummary;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTypeMsg;
    }
}