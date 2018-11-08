namespace Capa_Presentacion
{
    partial class FormCobranza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCobranza));
            this.BtnDesconectadosAqp = new System.Windows.Forms.Button();
            this.BtnCargarAqpTacna = new System.Windows.Forms.Button();
            this.dataGridCargarBancos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargarBancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDesconectadosAqp
            // 
            this.BtnDesconectadosAqp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDesconectadosAqp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnDesconectadosAqp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDesconectadosAqp.FlatAppearance.BorderSize = 0;
            this.BtnDesconectadosAqp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnDesconectadosAqp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDesconectadosAqp.Font = new System.Drawing.Font("Impact", 20.25F);
            this.BtnDesconectadosAqp.ForeColor = System.Drawing.Color.White;
            this.BtnDesconectadosAqp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDesconectadosAqp.Location = new System.Drawing.Point(825, 222);
            this.BtnDesconectadosAqp.Name = "BtnDesconectadosAqp";
            this.BtnDesconectadosAqp.Size = new System.Drawing.Size(177, 56);
            this.BtnDesconectadosAqp.TabIndex = 8;
            this.BtnDesconectadosAqp.Text = "Cobranza AQP";
            this.BtnDesconectadosAqp.UseVisualStyleBackColor = false;
            this.BtnDesconectadosAqp.Click += new System.EventHandler(this.BtnDesconectadosAqp_Click);
            // 
            // BtnCargarAqpTacna
            // 
            this.BtnCargarAqpTacna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCargarAqpTacna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnCargarAqpTacna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarAqpTacna.FlatAppearance.BorderSize = 0;
            this.BtnCargarAqpTacna.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnCargarAqpTacna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarAqpTacna.Font = new System.Drawing.Font("Impact", 20.25F);
            this.BtnCargarAqpTacna.ForeColor = System.Drawing.Color.White;
            this.BtnCargarAqpTacna.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCargarAqpTacna.Location = new System.Drawing.Point(825, 306);
            this.BtnCargarAqpTacna.Name = "BtnCargarAqpTacna";
            this.BtnCargarAqpTacna.Size = new System.Drawing.Size(177, 56);
            this.BtnCargarAqpTacna.TabIndex = 24;
            this.BtnCargarAqpTacna.Text = "Cobranza Tacna";
            this.BtnCargarAqpTacna.UseVisualStyleBackColor = false;
            this.BtnCargarAqpTacna.Click += new System.EventHandler(this.BtnCargarAqpTacna_Click);
            // 
            // dataGridCargarBancos
            // 
            this.dataGridCargarBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCargarBancos.Location = new System.Drawing.Point(570, 27);
            this.dataGridCargarBancos.Name = "dataGridCargarBancos";
            this.dataGridCargarBancos.Size = new System.Drawing.Size(29, 25);
            this.dataGridCargarBancos.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(401, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "Proceso de Cobranza";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(143, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(486, 414);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // FormCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1080, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridCargarBancos);
            this.Controls.Add(this.BtnCargarAqpTacna);
            this.Controls.Add(this.BtnDesconectadosAqp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCobranza";
            this.Text = "Desconectados";
            this.Load += new System.EventHandler(this.Desconectados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargarBancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnDesconectadosAqp;
        private System.Windows.Forms.Button BtnCargarAqpTacna;
        private System.Windows.Forms.DataGridView dataGridCargarBancos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}