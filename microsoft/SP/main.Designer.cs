namespace plugin
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txAviso = new System.Windows.Forms.TextBox();
            this.lComStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer();
            this.imgOn = new System.Windows.Forms.PictureBox();
            this.imgOff = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txRadio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txFecha = new System.Windows.Forms.TextBox();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem9);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem11);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.MenuItems.Add(this.menuItem10);
            this.menuItem1.MenuItems.Add(this.menuItem12);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.menuItem6);
            this.menuItem1.MenuItems.Add(this.menuItem7);
            this.menuItem1.MenuItems.Add(this.menuItem8);
            this.menuItem1.Text = "Menu";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Refrescar Posicion";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "Mapa";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Text = "Pausar";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Configurar";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "Acerca de hipoqih";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "Salir";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Text = "Conectar";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // txtLongitude
            // 
            this.txtLongitude.BackColor = System.Drawing.SystemColors.Info;
            this.txtLongitude.Location = new System.Drawing.Point(104, 45);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.ReadOnly = true;
            this.txtLongitude.Size = new System.Drawing.Size(60, 22);
            this.txtLongitude.TabIndex = 18;
            this.txtLongitude.TabStop = false;
            // 
            // txtLatitude
            // 
            this.txtLatitude.BackColor = System.Drawing.SystemColors.Info;
            this.txtLatitude.Location = new System.Drawing.Point(104, 20);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.ReadOnly = true;
            this.txtLatitude.Size = new System.Drawing.Size(60, 22);
            this.txtLatitude.TabIndex = 17;
            this.txtLatitude.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.Text = "Latitud";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(38, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.Text = "Longitud";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txAviso
            // 
            this.txAviso.BackColor = System.Drawing.SystemColors.Info;
            this.txAviso.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txAviso.Location = new System.Drawing.Point(0, 115);
            this.txAviso.Multiline = true;
            this.txAviso.Name = "txAviso";
            this.txAviso.ReadOnly = true;
            this.txAviso.Size = new System.Drawing.Size(173, 62);
            this.txAviso.TabIndex = 28;
            this.txAviso.TabStop = false;
            // 
            // lComStatus
            // 
            this.lComStatus.Location = new System.Drawing.Point(3, 0);
            this.lComStatus.Name = "lComStatus";
            this.lComStatus.Size = new System.Drawing.Size(97, 16);
            this.lComStatus.Text = "Parado";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // imgOn
            // 
            this.imgOn.Image = ((System.Drawing.Image)(resources.GetObject("imgOn.Image")));
            this.imgOn.Location = new System.Drawing.Point(15, 19);
            this.imgOn.Name = "imgOn";
            this.imgOn.Size = new System.Drawing.Size(16, 19);
            this.imgOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOn.Visible = false;
            // 
            // imgOff
            // 
            this.imgOff.Image = ((System.Drawing.Image)(resources.GetObject("imgOff.Image")));
            this.imgOff.Location = new System.Drawing.Point(15, 19);
            this.imgOff.Name = "imgOff";
            this.imgOff.Size = new System.Drawing.Size(16, 19);
            this.imgOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(1, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 41);
            this.label3.Text = "Ultimo aviso recibido:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txRadio
            // 
            this.txRadio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txRadio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txRadio.Location = new System.Drawing.Point(81, 93);
            this.txRadio.Name = "txRadio";
            this.txRadio.ReadOnly = true;
            this.txRadio.Size = new System.Drawing.Size(35, 19);
            this.txRadio.TabIndex = 39;
            this.txRadio.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(121, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 19);
            this.label7.Text = "metros:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(60, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 19);
            this.label5.Text = "at";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txLogin
            // 
            this.txLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txLogin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txLogin.Location = new System.Drawing.Point(81, 71);
            this.txLogin.Name = "txLogin";
            this.txLogin.ReadOnly = true;
            this.txLogin.Size = new System.Drawing.Size(92, 19);
            this.txLogin.TabIndex = 38;
            this.txLogin.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(49, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 19);
            this.label4.Text = "from";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txFecha
            // 
            this.txFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txFecha.Location = new System.Drawing.Point(1, 116);
            this.txFecha.Name = "txFecha";
            this.txFecha.ReadOnly = true;
            this.txFecha.Size = new System.Drawing.Size(154, 19);
            this.txFecha.TabIndex = 43;
            this.txFecha.TabStop = false;
            this.txFecha.Visible = false;
            // 
            // menuItem12
            // 
            this.menuItem12.Text = "¿Donde están mis amigos?";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.txRadio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imgOff);
            this.Controls.Add(this.imgOn);
            this.Controls.Add(this.txAviso);
            this.Controls.Add(this.lComStatus);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "main";
            this.Text = "plugin hipoqih.com";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txAviso;
        private System.Windows.Forms.Label lComStatus;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox imgOn;
        private System.Windows.Forms.PictureBox imgOff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.TextBox txRadio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txFecha;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
    }
}

