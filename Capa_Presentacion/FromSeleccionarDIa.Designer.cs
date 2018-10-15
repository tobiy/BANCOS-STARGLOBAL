namespace Capa_Presentacion
{
    partial class FromSeleccionarDIa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromSeleccionarDIa));
            this.BtnDomingo = new System.Windows.Forms.Button();
            this.BtnSemana = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDomingo
            // 
            this.BtnDomingo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDomingo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnDomingo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDomingo.FlatAppearance.BorderSize = 0;
            this.BtnDomingo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnDomingo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDomingo.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDomingo.ForeColor = System.Drawing.Color.White;
            this.BtnDomingo.Location = new System.Drawing.Point(123, 104);
            this.BtnDomingo.Name = "BtnDomingo";
            this.BtnDomingo.Size = new System.Drawing.Size(206, 59);
            this.BtnDomingo.TabIndex = 14;
            this.BtnDomingo.Text = "Domingo";
            this.BtnDomingo.UseVisualStyleBackColor = false;
            this.BtnDomingo.Click += new System.EventHandler(this.BtnDomingo_Click);
            // 
            // BtnSemana
            // 
            this.BtnSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSemana.FlatAppearance.BorderSize = 0;
            this.BtnSemana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSemana.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSemana.ForeColor = System.Drawing.Color.White;
            this.BtnSemana.Location = new System.Drawing.Point(123, 169);
            this.BtnSemana.Name = "BtnSemana";
            this.BtnSemana.Size = new System.Drawing.Size(206, 59);
            this.BtnSemana.TabIndex = 16;
            this.BtnSemana.Text = "Semana";
            this.BtnSemana.UseVisualStyleBackColor = false;
            this.BtnSemana.Click += new System.EventHandler(this.BtnSemana_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "Elija un Dia de Proceso";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(431, 12);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(30, 30);
            this.BtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCerrar.TabIndex = 35;
            this.BtnCerrar.TabStop = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FromSeleccionarDIa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(473, 291);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSemana);
            this.Controls.Add(this.BtnDomingo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FromSeleccionarDIa";
            this.Text = "FromSeleccionarDIa";
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDomingo;
        private System.Windows.Forms.Button BtnSemana;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BtnCerrar;
    }
}