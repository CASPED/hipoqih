namespace plugin
{
    partial class preferencias
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btCancel = new System.Windows.Forms.MenuItem();
            this.menuConf1 = new System.Windows.Forms.MenuItem();
            this.menuConf2 = new System.Windows.Forms.MenuItem();
            this.menuConf3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuSalir = new System.Windows.Forms.MenuItem();
            this.btOk = new System.Windows.Forms.MenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txPass = new System.Windows.Forms.TextBox();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.chMapa = new System.Windows.Forms.CheckBox();
            this.chAviso = new System.Windows.Forms.CheckBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chMapaURL = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txLat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txLon = new System.Windows.Forms.TextBox();
            this.cbGPS = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txTac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txTic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chNavega = new System.Windows.Forms.CheckBox();
            this.chSonido = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txExplorer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txSonido = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btCancel);
            this.mainMenu1.MenuItems.Add(this.btOk);
            // 
            // btCancel
            // 
            this.btCancel.MenuItems.Add(this.menuConf1);
            this.btCancel.MenuItems.Add(this.menuConf2);
            this.btCancel.MenuItems.Add(this.menuConf3);
            this.btCancel.MenuItems.Add(this.menuItem4);
            this.btCancel.MenuItems.Add(this.menuSalir);
            this.btCancel.Text = "Opciones";
            // 
            // menuConf1
            // 
            this.menuConf1.Text = "Configuración usuario";
            this.menuConf1.Click += new System.EventHandler(this.menuConf1_Click);
            // 
            // menuConf2
            // 
            this.menuConf2.Text = "Posición";
            this.menuConf2.Click += new System.EventHandler(this.menuConf2_Click);
            // 
            // menuConf3
            // 
            this.menuConf3.Text = "Avanzada";
            this.menuConf3.Click += new System.EventHandler(this.menuConf3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "-";
            // 
            // menuSalir
            // 
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // btOk
            // 
            this.btOk.Text = "Grabar";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label15.Location = new System.Drawing.Point(12, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.Text = "Clave:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label14.Location = new System.Drawing.Point(12, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 18);
            this.label14.Text = "Login:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txPass
            // 
            this.txPass.BackColor = System.Drawing.SystemColors.Info;
            this.txPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txPass.Location = new System.Drawing.Point(75, 37);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(78, 21);
            this.txPass.TabIndex = 1;
            this.txPass.TextChanged += new System.EventHandler(this.txPass_TextChanged);
            // 
            // txLogin
            // 
            this.txLogin.BackColor = System.Drawing.SystemColors.Info;
            this.txLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLogin.Location = new System.Drawing.Point(75, 8);
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(78, 21);
            this.txLogin.TabIndex = 0;
            // 
            // chMapa
            // 
            this.chMapa.Location = new System.Drawing.Point(10, 92);
            this.chMapa.Name = "chMapa";
            this.chMapa.Size = new System.Drawing.Size(152, 17);
            this.chMapa.TabIndex = 3;
            this.chMapa.Text = "Abrir los avisos en el mapa";
            // 
            // chAviso
            // 
            this.chAviso.Location = new System.Drawing.Point(10, 67);
            this.chAviso.Name = "chAviso";
            this.chAviso.Size = new System.Drawing.Size(155, 21);
            this.chAviso.TabIndex = 2;
            this.chAviso.Text = "Preguntar antes de abrir";
            // 
            // cbIdioma
            // 
            this.cbIdioma.BackColor = System.Drawing.SystemColors.Info;
            this.cbIdioma.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cbIdioma.Items.Add("Castellano");
            this.cbIdioma.Items.Add("English");
            this.cbIdioma.Location = new System.Drawing.Point(65, 139);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(107, 22);
            this.cbIdioma.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(-1, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.Text = "Idioma:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chMapaURL
            // 
            this.chMapaURL.Location = new System.Drawing.Point(10, 116);
            this.chMapaURL.Name = "chMapaURL";
            this.chMapaURL.Size = new System.Drawing.Size(152, 17);
            this.chMapaURL.TabIndex = 4;
            this.chMapaURL.Text = "Usar mapa si no hay URL";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(11, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.Text = "Latitud:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txLat
            // 
            this.txLat.BackColor = System.Drawing.SystemColors.Info;
            this.txLat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLat.Location = new System.Drawing.Point(67, 120);
            this.txLat.Name = "txLat";
            this.txLat.Size = new System.Drawing.Size(97, 21);
            this.txLat.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(1, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.Text = "Longitud:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txLon
            // 
            this.txLon.BackColor = System.Drawing.SystemColors.Info;
            this.txLon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLon.Location = new System.Drawing.Point(67, 150);
            this.txLon.Name = "txLon";
            this.txLon.Size = new System.Drawing.Size(97, 21);
            this.txLon.TabIndex = 14;
            // 
            // cbGPS
            // 
            this.cbGPS.BackColor = System.Drawing.SystemColors.Info;
            this.cbGPS.Location = new System.Drawing.Point(10, 17);
            this.cbGPS.Name = "cbGPS";
            this.cbGPS.Size = new System.Drawing.Size(159, 22);
            this.cbGPS.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 17);
            this.label13.Text = "Sistema de localización";
            // 
            // txTac
            // 
            this.txTac.BackColor = System.Drawing.SystemColors.Info;
            this.txTac.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txTac.Location = new System.Drawing.Point(24, 86);
            this.txTac.Name = "txTac";
            this.txTac.Size = new System.Drawing.Size(41, 21);
            this.txTac.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(18, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.Text = "Parado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txTic
            // 
            this.txTic.BackColor = System.Drawing.SystemColors.Info;
            this.txTic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txTic.Location = new System.Drawing.Point(107, 86);
            this.txTic.Name = "txTic";
            this.txTic.Size = new System.Drawing.Size(41, 21);
            this.txTic.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(95, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.Text = "Movimiento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chNavega
            // 
            this.chNavega.Location = new System.Drawing.Point(7, 17);
            this.chNavega.Name = "chNavega";
            this.chNavega.Size = new System.Drawing.Size(138, 17);
            this.chNavega.TabIndex = 20;
            this.chNavega.Text = "Navegador externo";
            this.chNavega.CheckStateChanged += new System.EventHandler(this.chNavega_CheckStateChanged);
            // 
            // chSonido
            // 
            this.chSonido.Location = new System.Drawing.Point(7, 100);
            this.chSonido.Name = "chSonido";
            this.chSonido.Size = new System.Drawing.Size(141, 17);
            this.chSonido.TabIndex = 22;
            this.chSonido.Text = "Activar sonido";
            this.chSonido.CheckStateChanged += new System.EventHandler(this.chSonido_CheckStateChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(12, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.Text = "Sonido del aviso";
            // 
            // txExplorer
            // 
            this.txExplorer.BackColor = System.Drawing.SystemColors.Info;
            this.txExplorer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txExplorer.Location = new System.Drawing.Point(7, 62);
            this.txExplorer.Name = "txExplorer";
            this.txExplorer.Size = new System.Drawing.Size(151, 21);
            this.txExplorer.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.Text = "Programa navegador";
            // 
            // txSonido
            // 
            this.txSonido.BackColor = System.Drawing.SystemColors.Info;
            this.txSonido.Location = new System.Drawing.Point(7, 139);
            this.txSonido.Name = "txSonido";
            this.txSonido.Size = new System.Drawing.Size(151, 22);
            this.txSonido.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txSonido);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.chNavega);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txExplorer);
            this.panel3.Controls.Add(this.chSonido);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 177);
            this.panel3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txLat);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txLon);
            this.panel2.Controls.Add(this.cbGPS);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txTac);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txTic);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 177);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 18);
            this.label4.Text = "Tiempos de latencia (seg.):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txPass);
            this.panel1.Controls.Add(this.txLogin);
            this.panel1.Controls.Add(this.chMapa);
            this.panel1.Controls.Add(this.chAviso);
            this.panel1.Controls.Add(this.cbIdioma);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.chMapaURL);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 177);
            // 
            // preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Menu = this.mainMenu1;
            this.Name = "preferencias";
            this.Text = "Configuración del plugin";
            this.Load += new System.EventHandler(this.preferencias_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.TextBox txLogin;
        private System.Windows.Forms.CheckBox chMapa;
        private System.Windows.Forms.CheckBox chAviso;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MenuItem btCancel;
        private System.Windows.Forms.MenuItem btOk;
        //private System.Windows.Forms.TabControl tabControl1;
        //private System.Windows.Forms.TabPage tabPage1;
        //private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txTac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txTic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGPS;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txLat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txLon;
        //private System.Windows.Forms.TabPage tabPage3;
        //private System.Windows.Forms.Button btExplorer;
        //private System.Windows.Forms.Button btSonido;
        private System.Windows.Forms.CheckBox chSonido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txExplorer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txSonido;
        private System.Windows.Forms.CheckBox chMapaURL;
        private System.Windows.Forms.CheckBox chNavega;
        private System.Windows.Forms.MenuItem menuConf1;
        private System.Windows.Forms.MenuItem menuConf2;
        private System.Windows.Forms.MenuItem menuConf3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuSalir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}