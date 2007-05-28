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
            this.btOk = new System.Windows.Forms.MenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txPass = new System.Windows.Forms.TextBox();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.chMapa = new System.Windows.Forms.CheckBox();
            this.chAviso = new System.Windows.Forms.CheckBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chMapaURL = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chNavega = new System.Windows.Forms.CheckBox();
            this.btExplorer = new System.Windows.Forms.Button();
            this.btSonido = new System.Windows.Forms.Button();
            this.chSonido = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txExplorer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txSonido = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btCancel);
            this.mainMenu1.MenuItems.Add(this.btOk);
            // 
            // btCancel
            // 
            this.btCancel.Text = "Cancelar";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Text = "Grabar";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.Text = "Clave:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(13, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 17);
            this.label14.Text = "Login en hipoqih:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txPass
            // 
            this.txPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txPass.Location = new System.Drawing.Point(121, 38);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(97, 21);
            this.txPass.TabIndex = 5;
            // 
            // txLogin
            // 
            this.txLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLogin.Location = new System.Drawing.Point(121, 8);
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(97, 21);
            this.txLogin.TabIndex = 4;
            // 
            // chMapa
            // 
            this.chMapa.Location = new System.Drawing.Point(9, 94);
            this.chMapa.Name = "chMapa";
            this.chMapa.Size = new System.Drawing.Size(223, 17);
            this.chMapa.TabIndex = 7;
            this.chMapa.Text = "Abrir los avisos en el mapa";
            // 
            // chAviso
            // 
            this.chAviso.Location = new System.Drawing.Point(9, 72);
            this.chAviso.Name = "chAviso";
            this.chAviso.Size = new System.Drawing.Size(223, 17);
            this.chAviso.TabIndex = 6;
            this.chAviso.Text = "Preguntar antes de abrir los avisos";
            // 
            // cbIdioma
            // 
            this.cbIdioma.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cbIdioma.Items.Add("Castellano");
            this.cbIdioma.Items.Add("English");
            this.cbIdioma.Location = new System.Drawing.Point(119, 146);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(95, 22);
            this.cbIdioma.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(18, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 21);
            this.label16.Text = "Idioma:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chMapaURL);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.chMapa);
            this.tabPage1.Controls.Add(this.cbIdioma);
            this.tabPage1.Controls.Add(this.chAviso);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txPass);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txLogin);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 245);
            this.tabPage1.Text = "Configuración";
            // 
            // chMapaURL
            // 
            this.chMapaURL.Location = new System.Drawing.Point(9, 116);
            this.chMapaURL.Name = "chMapaURL";
            this.chMapaURL.Size = new System.Drawing.Size(223, 17);
            this.chMapaURL.TabIndex = 28;
            this.chMapaURL.Text = "Usar mapa si no hay URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txLat);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txLon);
            this.tabPage2.Controls.Add(this.cbGPS);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txTac);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txTic);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 245);
            this.tabPage2.Text = "Posicion";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.Text = "Latitud inicial:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txLat
            // 
            this.txLat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLat.Location = new System.Drawing.Point(122, 99);
            this.txLat.Name = "txLat";
            this.txLat.Size = new System.Drawing.Size(97, 21);
            this.txLat.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.Text = "Longitud inicial:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txLon
            // 
            this.txLon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txLon.Location = new System.Drawing.Point(122, 125);
            this.txLon.Name = "txLon";
            this.txLon.Size = new System.Drawing.Size(97, 21);
            this.txLon.TabIndex = 56;
            // 
            // cbGPS
            // 
            this.cbGPS.Location = new System.Drawing.Point(9, 20);
            this.cbGPS.Name = "cbGPS";
            this.cbGPS.Size = new System.Drawing.Size(210, 22);
            this.cbGPS.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 24);
            this.label13.Text = "Sistema de localización";
            // 
            // txTac
            // 
            this.txTac.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txTac.Location = new System.Drawing.Point(178, 73);
            this.txTac.Name = "txTac";
            this.txTac.Size = new System.Drawing.Size(41, 21);
            this.txTac.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 19);
            this.label1.Text = "Latencia parado (seg.)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txTic
            // 
            this.txTic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txTic.Location = new System.Drawing.Point(178, 47);
            this.txTic.Name = "txTic";
            this.txTic.Size = new System.Drawing.Size(41, 21);
            this.txTic.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 18);
            this.label2.Text = "Latencia movimiento (seg.)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chNavega);
            this.tabPage3.Controls.Add(this.btExplorer);
            this.tabPage3.Controls.Add(this.btSonido);
            this.tabPage3.Controls.Add(this.chSonido);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txExplorer);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txSonido);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(240, 245);
            this.tabPage3.Text = "Avanzado";
            // 
            // chNavega
            // 
            this.chNavega.Location = new System.Drawing.Point(9, 7);
            this.chNavega.Name = "chNavega";
            this.chNavega.Size = new System.Drawing.Size(224, 17);
            this.chNavega.TabIndex = 53;
            this.chNavega.Text = "Navegador de internet externo";
            this.chNavega.CheckStateChanged += new System.EventHandler(this.chNavega_CheckStateChanged);
            // 
            // btExplorer
            // 
            this.btExplorer.Location = new System.Drawing.Point(178, 44);
            this.btExplorer.Name = "btExplorer";
            this.btExplorer.Size = new System.Drawing.Size(55, 26);
            this.btExplorer.TabIndex = 50;
            this.btExplorer.Text = "Buscar";
            this.btExplorer.Click += new System.EventHandler(this.btExplorer_Click_1);
            // 
            // btSonido
            // 
            this.btSonido.Location = new System.Drawing.Point(178, 117);
            this.btSonido.Name = "btSonido";
            this.btSonido.Size = new System.Drawing.Size(55, 26);
            this.btSonido.TabIndex = 49;
            this.btSonido.Text = "Buscar";
            this.btSonido.Click += new System.EventHandler(this.btSonido_Click_1);
            // 
            // chSonido
            // 
            this.chSonido.Location = new System.Drawing.Point(9, 81);
            this.chSonido.Name = "chSonido";
            this.chSonido.Size = new System.Drawing.Size(225, 17);
            this.chSonido.TabIndex = 46;
            this.chSonido.Text = "Activar sonido al recibir un aviso";
            this.chSonido.CheckStateChanged += new System.EventHandler(this.chSonido_CheckStateChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 16);
            this.label8.Text = "Sonido del aviso";
            // 
            // txExplorer
            // 
            this.txExplorer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txExplorer.Location = new System.Drawing.Point(7, 47);
            this.txExplorer.Name = "txExplorer";
            this.txExplorer.Size = new System.Drawing.Size(164, 21);
            this.txExplorer.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 21);
            this.label3.Text = "Programa navegador";
            // 
            // txSonido
            // 
            this.txSonido.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txSonido.Location = new System.Drawing.Point(7, 121);
            this.txSonido.Name = "txSonido";
            this.txSonido.Size = new System.Drawing.Size(164, 21);
            this.txSonido.TabIndex = 48;
            // 
            // preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "preferencias";
            this.Text = "Configuración del plugin";
            this.Load += new System.EventHandler(this.preferencias_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btExplorer;
        private System.Windows.Forms.Button btSonido;
        private System.Windows.Forms.CheckBox chSonido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txExplorer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txSonido;
        private System.Windows.Forms.CheckBox chMapaURL;
        private System.Windows.Forms.CheckBox chNavega;
    }
}