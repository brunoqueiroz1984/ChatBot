namespace bot
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pTexto = new System.Windows.Forms.Panel();
            this.gbText = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.gbText.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 242);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(572, 84);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // pTexto
            // 
            this.pTexto.AutoScroll = true;
            this.pTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTexto.Location = new System.Drawing.Point(3, 16);
            this.pTexto.Name = "pTexto";
            this.pTexto.Size = new System.Drawing.Size(441, 216);
            this.pTexto.TabIndex = 0;
            // 
            // gbText
            // 
            this.gbText.Controls.Add(this.pTexto);
            this.gbText.Location = new System.Drawing.Point(12, 1);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(447, 235);
            this.gbText.TabIndex = 4;
            this.gbText.TabStop = false;
            this.gbText.Text = "Chat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Voz: ligado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbText);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "ChatterBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pTexto;
        private System.Windows.Forms.GroupBox gbText;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button1;
    }
}

