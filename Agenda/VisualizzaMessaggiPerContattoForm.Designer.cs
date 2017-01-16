namespace Agenda
{
    partial class VisualizzaMessaggiPerContattoForm
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
            this.messagesListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // messagesListbox
            // 
            this.messagesListbox.FormattingEnabled = true;
            this.messagesListbox.ItemHeight = 16;
            this.messagesListbox.Location = new System.Drawing.Point(41, 89);
            this.messagesListbox.Name = "messagesListbox";
            this.messagesListbox.Size = new System.Drawing.Size(390, 404);
            this.messagesListbox.TabIndex = 0;
            // 
            // VisualizzaMessaggiPerContattoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 606);
            this.Controls.Add(this.messagesListbox);
            this.Name = "VisualizzaMessaggiPerContattoForm";
            this.Text = "VisualizzaMessaggiPerContattoForm";
            this.Load += new System.EventHandler(this.VisualizzaMessaggiPerContattoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox messagesListbox;
    }
}