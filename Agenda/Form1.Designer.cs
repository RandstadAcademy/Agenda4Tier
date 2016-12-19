namespace Agenda
{
    partial class Form1
    {
    
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCancella = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(29, 80);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(403, 228);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 324);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Crea Nuovo Contatto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancella
            // 
            this.buttonCancella.Location = new System.Drawing.Point(244, 324);
            this.buttonCancella.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancella.Name = "buttonCancella";
            this.buttonCancella.Size = new System.Drawing.Size(99, 46);
            this.buttonCancella.TabIndex = 2;
            this.buttonCancella.Text = "Cancella Contatto";
            this.buttonCancella.UseVisualStyleBackColor = true;
            this.buttonCancella.Click += new System.EventHandler(this.buttonCancella_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(134, 324);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(104, 46);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Aggiorna Contatto";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(349, 324);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(83, 46);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "Esporta Contatto";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 388);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(403, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "Invia Messaggio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDB
            // 
            this.btnDB.Location = new System.Drawing.Point(327, 26);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(105, 23);
            this.btnDB.TabIndex = 6;
            this.btnDB.Text = "Cambia DB";
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 445);
            this.Controls.Add(this.btnDB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCancella);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Agenda Accademy Mermec v.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCancella;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDB;
    }
}

