namespace Capa_Presentacion
{
    partial class ContenedorPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContenedorPrincipal));
            this.Barra_Titulo = new System.Windows.Forms.Panel();
            this.Btn_Restaurar = new System.Windows.Forms.PictureBox();
            this.Btn_Minimisar = new System.Windows.Forms.PictureBox();
            this.Btn_Maximizar = new System.Windows.Forms.PictureBox();
            this.Btn_Cerrar = new System.Windows.Forms.PictureBox();
            this.Menu_Vertical = new System.Windows.Forms.Panel();
            this.SubmenuBancos = new System.Windows.Forms.Panel();
            this.Btn_Domingo = new System.Windows.Forms.Button();
            this.Btn_Semana = new System.Windows.Forms.Button();
            this.Btn_Abrir_Comparacion = new System.Windows.Forms.Button();
            this.Btn_Abrir_Cobranza = new System.Windows.Forms.Button();
            this.Btn_Abrir_Bancos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel_Principal = new System.Windows.Forms.Panel();
            this.Btn_Correr = new System.Windows.Forms.PictureBox();
            this.Barra_Titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Restaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Maximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Cerrar)).BeginInit();
            this.Menu_Vertical.SuspendLayout();
            this.SubmenuBancos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Correr)).BeginInit();
            this.SuspendLayout();
            // 
            // Barra_Titulo
            // 
            this.Barra_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Barra_Titulo.Controls.Add(this.Btn_Correr);
            this.Barra_Titulo.Controls.Add(this.Btn_Restaurar);
            this.Barra_Titulo.Controls.Add(this.Btn_Minimisar);
            this.Barra_Titulo.Controls.Add(this.Btn_Maximizar);
            this.Barra_Titulo.Controls.Add(this.Btn_Cerrar);
            this.Barra_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Barra_Titulo.Location = new System.Drawing.Point(220, 0);
            this.Barra_Titulo.Name = "Barra_Titulo";
            this.Barra_Titulo.Size = new System.Drawing.Size(1080, 68);
            this.Barra_Titulo.TabIndex = 0;
            this.Barra_Titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Barra_Titulo_MouseDown);
            // 
            // Btn_Restaurar
            // 
            this.Btn_Restaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Restaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Restaurar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Restaurar.Image")));
            this.Btn_Restaurar.Location = new System.Drawing.Point(979, 12);
            this.Btn_Restaurar.Name = "Btn_Restaurar";
            this.Btn_Restaurar.Size = new System.Drawing.Size(42, 36);
            this.Btn_Restaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Restaurar.TabIndex = 2;
            this.Btn_Restaurar.TabStop = false;
            this.Btn_Restaurar.Visible = false;
            this.Btn_Restaurar.Click += new System.EventHandler(this.Btn_Restaurar_Click);
            // 
            // Btn_Minimisar
            // 
            this.Btn_Minimisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Minimisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Minimisar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Minimisar.Image")));
            this.Btn_Minimisar.Location = new System.Drawing.Point(932, 12);
            this.Btn_Minimisar.Name = "Btn_Minimisar";
            this.Btn_Minimisar.Size = new System.Drawing.Size(37, 35);
            this.Btn_Minimisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Minimisar.TabIndex = 1;
            this.Btn_Minimisar.TabStop = false;
            this.Btn_Minimisar.Click += new System.EventHandler(this.Btn_Minimisar_Click);
            // 
            // Btn_Maximizar
            // 
            this.Btn_Maximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Maximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Maximizar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Maximizar.Image")));
            this.Btn_Maximizar.Location = new System.Drawing.Point(979, 12);
            this.Btn_Maximizar.Name = "Btn_Maximizar";
            this.Btn_Maximizar.Size = new System.Drawing.Size(37, 36);
            this.Btn_Maximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Maximizar.TabIndex = 1;
            this.Btn_Maximizar.TabStop = false;
            this.Btn_Maximizar.Click += new System.EventHandler(this.Btn_Maximizar_Click);
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Cerrar.Image")));
            this.Btn_Cerrar.Location = new System.Drawing.Point(1027, 13);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(38, 35);
            this.Btn_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Cerrar.TabIndex = 0;
            this.Btn_Cerrar.TabStop = false;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // Menu_Vertical
            // 
            this.Menu_Vertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Menu_Vertical.Controls.Add(this.SubmenuBancos);
            this.Menu_Vertical.Controls.Add(this.Btn_Abrir_Comparacion);
            this.Menu_Vertical.Controls.Add(this.Btn_Abrir_Cobranza);
            this.Menu_Vertical.Controls.Add(this.Btn_Abrir_Bancos);
            this.Menu_Vertical.Controls.Add(this.pictureBox1);
            this.Menu_Vertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu_Vertical.Location = new System.Drawing.Point(0, 0);
            this.Menu_Vertical.Name = "Menu_Vertical";
            this.Menu_Vertical.Size = new System.Drawing.Size(220, 650);
            this.Menu_Vertical.TabIndex = 1;
            // 
            // SubmenuBancos
            // 
            this.SubmenuBancos.Controls.Add(this.Btn_Domingo);
            this.SubmenuBancos.Controls.Add(this.Btn_Semana);
            this.SubmenuBancos.Location = new System.Drawing.Point(43, 215);
            this.SubmenuBancos.Name = "SubmenuBancos";
            this.SubmenuBancos.Size = new System.Drawing.Size(177, 74);
            this.SubmenuBancos.TabIndex = 0;
            this.SubmenuBancos.Visible = false;
            // 
            // Btn_Domingo
            // 
            this.Btn_Domingo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Btn_Domingo.FlatAppearance.BorderSize = 0;
            this.Btn_Domingo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_Domingo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Domingo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Domingo.ForeColor = System.Drawing.Color.White;
            this.Btn_Domingo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Domingo.Location = new System.Drawing.Point(3, 3);
            this.Btn_Domingo.Name = "Btn_Domingo";
            this.Btn_Domingo.Size = new System.Drawing.Size(176, 28);
            this.Btn_Domingo.TabIndex = 17;
            this.Btn_Domingo.Text = "Domingo";
            this.Btn_Domingo.UseVisualStyleBackColor = false;
            this.Btn_Domingo.Click += new System.EventHandler(this.Btn_Domingo_Click);
            // 
            // Btn_Semana
            // 
            this.Btn_Semana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Btn_Semana.FlatAppearance.BorderSize = 0;
            this.Btn_Semana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_Semana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Semana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Semana.ForeColor = System.Drawing.Color.White;
            this.Btn_Semana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Semana.Location = new System.Drawing.Point(1, 43);
            this.Btn_Semana.Name = "Btn_Semana";
            this.Btn_Semana.Size = new System.Drawing.Size(176, 28);
            this.Btn_Semana.TabIndex = 18;
            this.Btn_Semana.Text = "Semana";
            this.Btn_Semana.UseVisualStyleBackColor = false;
            this.Btn_Semana.Click += new System.EventHandler(this.Btn_Semana_Click);
            // 
            // Btn_Abrir_Comparacion
            // 
            this.Btn_Abrir_Comparacion.FlatAppearance.BorderSize = 0;
            this.Btn_Abrir_Comparacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_Abrir_Comparacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Abrir_Comparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Abrir_Comparacion.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Abrir_Comparacion.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Abrir_Comparacion.Image")));
            this.Btn_Abrir_Comparacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Abrir_Comparacion.Location = new System.Drawing.Point(0, 139);
            this.Btn_Abrir_Comparacion.Name = "Btn_Abrir_Comparacion";
            this.Btn_Abrir_Comparacion.Size = new System.Drawing.Size(220, 32);
            this.Btn_Abrir_Comparacion.TabIndex = 2;
            this.Btn_Abrir_Comparacion.Text = "Comparacion";
            this.Btn_Abrir_Comparacion.UseVisualStyleBackColor = true;
            this.Btn_Abrir_Comparacion.Click += new System.EventHandler(this.Btn_Abrir_Comparacion_Click);
            // 
            // Btn_Abrir_Cobranza
            // 
            this.Btn_Abrir_Cobranza.FlatAppearance.BorderSize = 0;
            this.Btn_Abrir_Cobranza.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_Abrir_Cobranza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Abrir_Cobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Abrir_Cobranza.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Abrir_Cobranza.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Abrir_Cobranza.Image")));
            this.Btn_Abrir_Cobranza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Abrir_Cobranza.Location = new System.Drawing.Point(0, 101);
            this.Btn_Abrir_Cobranza.Name = "Btn_Abrir_Cobranza";
            this.Btn_Abrir_Cobranza.Size = new System.Drawing.Size(220, 32);
            this.Btn_Abrir_Cobranza.TabIndex = 1;
            this.Btn_Abrir_Cobranza.Text = "Cobranza";
            this.Btn_Abrir_Cobranza.UseVisualStyleBackColor = true;
            this.Btn_Abrir_Cobranza.Click += new System.EventHandler(this.Btn_Abrir_Cobranza_Click);
            // 
            // Btn_Abrir_Bancos
            // 
            this.Btn_Abrir_Bancos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Abrir_Bancos.FlatAppearance.BorderSize = 0;
            this.Btn_Abrir_Bancos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_Abrir_Bancos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Abrir_Bancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Abrir_Bancos.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Abrir_Bancos.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Abrir_Bancos.Image")));
            this.Btn_Abrir_Bancos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Abrir_Bancos.Location = new System.Drawing.Point(0, 177);
            this.Btn_Abrir_Bancos.Name = "Btn_Abrir_Bancos";
            this.Btn_Abrir_Bancos.Size = new System.Drawing.Size(220, 32);
            this.Btn_Abrir_Bancos.TabIndex = 0;
            this.Btn_Abrir_Bancos.Text = "Bancos";
            this.Btn_Abrir_Bancos.UseVisualStyleBackColor = false;
            this.Btn_Abrir_Bancos.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Panel_Principal
            // 
            this.Panel_Principal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.Panel_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Principal.Location = new System.Drawing.Point(220, 68);
            this.Panel_Principal.Name = "Panel_Principal";
            this.Panel_Principal.Size = new System.Drawing.Size(1080, 582);
            this.Panel_Principal.TabIndex = 2;
            // 
            // Btn_Correr
            // 
            this.Btn_Correr.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Correr.Image")));
            this.Btn_Correr.Location = new System.Drawing.Point(26, 13);
            this.Btn_Correr.Name = "Btn_Correr";
            this.Btn_Correr.Size = new System.Drawing.Size(35, 35);
            this.Btn_Correr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Correr.TabIndex = 0;
            this.Btn_Correr.TabStop = false;
            this.Btn_Correr.Click += new System.EventHandler(this.Btn_Correr_Click);
            // 
            // ContenedorPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.Panel_Principal);
            this.Controls.Add(this.Barra_Titulo);
            this.Controls.Add(this.Menu_Vertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContenedorPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Barra_Titulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Restaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Maximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Cerrar)).EndInit();
            this.Menu_Vertical.ResumeLayout(false);
            this.SubmenuBancos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Correr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Barra_Titulo;
        private System.Windows.Forms.PictureBox Btn_Cerrar;
        private System.Windows.Forms.Panel Menu_Vertical;
        private System.Windows.Forms.Panel Panel_Principal;
        private System.Windows.Forms.PictureBox Btn_Restaurar;
        private System.Windows.Forms.PictureBox Btn_Minimisar;
        private System.Windows.Forms.PictureBox Btn_Maximizar;
        private System.Windows.Forms.Button Btn_Abrir_Bancos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_Abrir_Cobranza;
        private System.Windows.Forms.Button Btn_Abrir_Comparacion;
        private System.Windows.Forms.Button Btn_Domingo;
        private System.Windows.Forms.Panel SubmenuBancos;
        private System.Windows.Forms.Button Btn_Semana;
        private System.Windows.Forms.PictureBox Btn_Correr;
    }
}

