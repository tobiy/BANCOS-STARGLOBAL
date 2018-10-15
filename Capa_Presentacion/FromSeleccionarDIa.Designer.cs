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
            this.BtnDomingo = new System.Windows.Forms.Button();
            this.BtnLunes = new System.Windows.Forms.Button();
            this.BtnSemana = new System.Windows.Forms.Button();
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
            this.BtnDomingo.Location = new System.Drawing.Point(164, 63);
            this.BtnDomingo.Name = "BtnDomingo";
            this.BtnDomingo.Size = new System.Drawing.Size(206, 59);
            this.BtnDomingo.TabIndex = 14;
            this.BtnDomingo.Text = "Domingo";
            this.BtnDomingo.UseVisualStyleBackColor = false;
            this.BtnDomingo.Click += new System.EventHandler(this.BtnDomingo_Click);
            // 
            // BtnLunes
            // 
            this.BtnLunes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLunes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.BtnLunes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLunes.FlatAppearance.BorderSize = 0;
            this.BtnLunes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnLunes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLunes.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLunes.ForeColor = System.Drawing.Color.White;
            this.BtnLunes.Location = new System.Drawing.Point(164, 128);
            this.BtnLunes.Name = "BtnLunes";
            this.BtnLunes.Size = new System.Drawing.Size(206, 59);
            this.BtnLunes.TabIndex = 15;
            this.BtnLunes.Text = "Lunes";
            this.BtnLunes.UseVisualStyleBackColor = false;
            this.BtnLunes.Click += new System.EventHandler(this.BtnLunes_Click);
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
            this.BtnSemana.Location = new System.Drawing.Point(164, 193);
            this.BtnSemana.Name = "BtnSemana";
            this.BtnSemana.Size = new System.Drawing.Size(206, 59);
            this.BtnSemana.TabIndex = 16;
            this.BtnSemana.Text = "Martes - Sabado";
            this.BtnSemana.UseVisualStyleBackColor = false;
            this.BtnSemana.Click += new System.EventHandler(this.BtnSemana_Click);
            // 
            // FromSeleccionarDIa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(546, 363);
            this.Controls.Add(this.BtnSemana);
            this.Controls.Add(this.BtnLunes);
            this.Controls.Add(this.BtnDomingo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FromSeleccionarDIa";
            this.Text = "FromSeleccionarDIa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnDomingo;
        private System.Windows.Forms.Button BtnLunes;
        private System.Windows.Forms.Button BtnSemana;
    }
}