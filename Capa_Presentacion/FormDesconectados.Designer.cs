namespace Capa_Presentacion
{
    partial class Lbl_Monto_Consolidado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lbl_Monto_Consolidado));
            this.dataGridDesconectadosAqp = new System.Windows.Forms.DataGridView();
            this.BtnDesconectadosTacna = new System.Windows.Forms.Button();
            this.BtnDesconectadosAqp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            this.dataGridDesconectadosTacna = new System.Windows.Forms.DataGridView();
            this.BtnCargarAqpTacna = new System.Windows.Forms.Button();
            this.dataGridCargarBancos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDesconectadosAqp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDesconectadosTacna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargarBancos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDesconectadosAqp
            // 
            this.dataGridDesconectadosAqp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDesconectadosAqp.Location = new System.Drawing.Point(22, 23);
            this.dataGridDesconectadosAqp.Name = "dataGridDesconectadosAqp";
            this.dataGridDesconectadosAqp.Size = new System.Drawing.Size(254, 175);
            this.dataGridDesconectadosAqp.TabIndex = 0;
            // 
            // BtnDesconectadosTacna
            // 
            this.BtnDesconectadosTacna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDesconectadosTacna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnDesconectadosTacna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDesconectadosTacna.FlatAppearance.BorderSize = 0;
            this.BtnDesconectadosTacna.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnDesconectadosTacna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDesconectadosTacna.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDesconectadosTacna.ForeColor = System.Drawing.Color.White;
            this.BtnDesconectadosTacna.Location = new System.Drawing.Point(370, 204);
            this.BtnDesconectadosTacna.Name = "BtnDesconectadosTacna";
            this.BtnDesconectadosTacna.Size = new System.Drawing.Size(177, 26);
            this.BtnDesconectadosTacna.TabIndex = 7;
            this.BtnDesconectadosTacna.Text = "Desconectados Tacna";
            this.BtnDesconectadosTacna.UseVisualStyleBackColor = false;
            this.BtnDesconectadosTacna.Click += new System.EventHandler(this.BtnBbva_Click);
            // 
            // BtnDesconectadosAqp
            // 
            this.BtnDesconectadosAqp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDesconectadosAqp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnDesconectadosAqp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDesconectadosAqp.FlatAppearance.BorderSize = 0;
            this.BtnDesconectadosAqp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnDesconectadosAqp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDesconectadosAqp.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDesconectadosAqp.ForeColor = System.Drawing.Color.White;
            this.BtnDesconectadosAqp.Location = new System.Drawing.Point(53, 204);
            this.BtnDesconectadosAqp.Name = "BtnDesconectadosAqp";
            this.BtnDesconectadosAqp.Size = new System.Drawing.Size(177, 26);
            this.BtnDesconectadosAqp.TabIndex = 8;
            this.BtnDesconectadosAqp.Text = "Desconectados AQP";
            this.BtnDesconectadosAqp.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(622, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Salir";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(625, 12);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(30, 30);
            this.BtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCerrar.TabIndex = 21;
            this.BtnCerrar.TabStop = false;
            // 
            // dataGridDesconectadosTacna
            // 
            this.dataGridDesconectadosTacna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDesconectadosTacna.Location = new System.Drawing.Point(329, 23);
            this.dataGridDesconectadosTacna.Name = "dataGridDesconectadosTacna";
            this.dataGridDesconectadosTacna.Size = new System.Drawing.Size(254, 175);
            this.dataGridDesconectadosTacna.TabIndex = 23;
            // 
            // BtnCargarAqpTacna
            // 
            this.BtnCargarAqpTacna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCargarAqpTacna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnCargarAqpTacna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarAqpTacna.FlatAppearance.BorderSize = 0;
            this.BtnCargarAqpTacna.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnCargarAqpTacna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarAqpTacna.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarAqpTacna.ForeColor = System.Drawing.Color.White;
            this.BtnCargarAqpTacna.Location = new System.Drawing.Point(240, 295);
            this.BtnCargarAqpTacna.Name = "BtnCargarAqpTacna";
            this.BtnCargarAqpTacna.Size = new System.Drawing.Size(177, 26);
            this.BtnCargarAqpTacna.TabIndex = 24;
            this.BtnCargarAqpTacna.Text = "Cargar Arequipa-Tacna";
            this.BtnCargarAqpTacna.UseVisualStyleBackColor = false;
            this.BtnCargarAqpTacna.Click += new System.EventHandler(this.BtnCargarAqpTacna_Click);
            // 
            // dataGridCargarBancos
            // 
            this.dataGridCargarBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCargarBancos.Location = new System.Drawing.Point(22, 257);
            this.dataGridCargarBancos.Name = "dataGridCargarBancos";
            this.dataGridCargarBancos.Size = new System.Drawing.Size(208, 103);
            this.dataGridCargarBancos.TabIndex = 25;
            // 
            // Lbl_Monto_Consolidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(667, 386);
            this.Controls.Add(this.dataGridCargarBancos);
            this.Controls.Add(this.BtnCargarAqpTacna);
            this.Controls.Add(this.dataGridDesconectadosTacna);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnDesconectadosAqp);
            this.Controls.Add(this.BtnDesconectadosTacna);
            this.Controls.Add(this.dataGridDesconectadosAqp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lbl_Monto_Consolidado";
            this.Text = "Desconectados";
            this.Load += new System.EventHandler(this.Desconectados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDesconectadosAqp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDesconectadosTacna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargarBancos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDesconectadosAqp;
        private System.Windows.Forms.Button BtnDesconectadosTacna;
        private System.Windows.Forms.Button BtnDesconectadosAqp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BtnCerrar;
        private System.Windows.Forms.DataGridView dataGridDesconectadosTacna;
        private System.Windows.Forms.Button BtnCargarAqpTacna;
        private System.Windows.Forms.DataGridView dataGridCargarBancos;
    }
}