namespace plugin_hipoqih
{
    partial class preferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(preferencias));
            this.txLat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txLon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbGPS = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txAlto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txAncho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chAviso = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txTac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txTic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chMapa = new System.Windows.Forms.CheckBox();
            this.btPosi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btExplorer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txExplorer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chNavega = new System.Windows.Forms.CheckBox();
            this.tabPreferencias = new System.Windows.Forms.TabControl();
            this.tabCompor = new System.Windows.Forms.TabPage();
            this.chMapaURL = new System.Windows.Forms.CheckBox();
            this.btRegistro = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txPass = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chSonido = new System.Windows.Forms.CheckBox();
            this.btSonido = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txSonido = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPreferencias.SuspendLayout();
            this.tabCompor.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txLat
            // 
            this.txLat.Location = new System.Drawing.Point(112, 20);
            this.txLat.Name = "txLat";
            this.txLat.Size = new System.Drawing.Size(90, 20);
            this.txLat.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Latitud inicial:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txLon
            // 
            this.txLon.Location = new System.Drawing.Point(112, 46);
            this.txLon.Name = "txLon";
            this.txLon.Size = new System.Drawing.Size(90, 20);
            this.txLon.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Longitud inicial:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(240, 390);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(61, 23);
            this.btCancel.TabIndex = 23;
            this.btCancel.Text = "Cancelar";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(318, 390);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(61, 23);
            this.btOk.TabIndex = 24;
            this.btOk.Text = "Aceptar";
            this.btOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.Location = new System.Drawing.Point(253, 53);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(83, 21);
            this.cbBaudRate.TabIndex = 15;
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.Location = new System.Drawing.Point(116, 54);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(69, 21);
            this.cbPort.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(148, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 22);
            this.label11.TabIndex = 25;
            this.label11.Text = "Velocidad:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(63, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Puerto:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGPS
            // 
            this.cbGPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGPS.Location = new System.Drawing.Point(141, 23);
            this.cbGPS.Name = "cbGPS";
            this.cbGPS.Size = new System.Drawing.Size(196, 21);
            this.cbGPS.TabIndex = 13;
            this.cbGPS.SelectedIndexChanged += new System.EventHandler(this.cbGPS_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 24);
            this.label13.TabIndex = 28;
            this.label13.Text = "Sistema de localización:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txY);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txX);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txAlto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txAncho);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(18, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 120);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventana de avisos";
            // 
            // txY
            // 
            this.txY.Location = new System.Drawing.Point(75, 86);
            this.txY.Name = "txY";
            this.txY.Size = new System.Drawing.Size(44, 20);
            this.txY.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Posicion Y";
            // 
            // txX
            // 
            this.txX.Location = new System.Drawing.Point(13, 86);
            this.txX.Name = "txX";
            this.txX.Size = new System.Drawing.Size(44, 20);
            this.txX.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Posicion X";
            // 
            // txAlto
            // 
            this.txAlto.Location = new System.Drawing.Point(75, 41);
            this.txAlto.Name = "txAlto";
            this.txAlto.Size = new System.Drawing.Size(44, 20);
            this.txAlto.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Alto";
            // 
            // txAncho
            // 
            this.txAncho.Location = new System.Drawing.Point(13, 41);
            this.txAncho.Name = "txAncho";
            this.txAncho.Size = new System.Drawing.Size(44, 20);
            this.txAncho.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ancho";
            // 
            // chAviso
            // 
            this.chAviso.Location = new System.Drawing.Point(188, 189);
            this.chAviso.Name = "chAviso";
            this.chAviso.Size = new System.Drawing.Size(188, 17);
            this.chAviso.TabIndex = 8;
            this.chAviso.Text = "Preguntar antes de abrir los avisos";
            this.chAviso.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbGPS);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbBaudRate);
            this.groupBox2.Controls.Add(this.cbPort);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(19, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 87);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración del dispositivo";
            // 
            // txTac
            // 
            this.txTac.Location = new System.Drawing.Point(293, 321);
            this.txTac.Name = "txTac";
            this.txTac.Size = new System.Drawing.Size(41, 20);
            this.txTac.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tiempo de latencia cuando estas parado (seg.):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txTic
            // 
            this.txTic.Location = new System.Drawing.Point(293, 295);
            this.txTic.Name = "txTic";
            this.txTic.Size = new System.Drawing.Size(41, 20);
            this.txTic.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tiempo de latencia cuando estas en movimiento (seg.):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chMapa
            // 
            this.chMapa.Location = new System.Drawing.Point(188, 213);
            this.chMapa.Name = "chMapa";
            this.chMapa.Size = new System.Drawing.Size(188, 17);
            this.chMapa.TabIndex = 9;
            this.chMapa.Text = "Abrir los avisos en el mapa";
            this.chMapa.UseVisualStyleBackColor = true;
            // 
            // btPosi
            // 
            this.btPosi.Location = new System.Drawing.Point(231, 28);
            this.btPosi.Name = "btPosi";
            this.btPosi.Size = new System.Drawing.Size(98, 26);
            this.btPosi.TabIndex = 22;
            this.btPosi.Text = "Buscar posicion";
            this.btPosi.Click += new System.EventHandler(this.btPosi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btPosi);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txLat);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txLon);
            this.groupBox3.Location = new System.Drawing.Point(18, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 78);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Posición incial";
            // 
            // btExplorer
            // 
            this.btExplorer.Location = new System.Drawing.Point(283, 46);
            this.btExplorer.Name = "btExplorer";
            this.btExplorer.Size = new System.Drawing.Size(55, 26);
            this.btExplorer.TabIndex = 19;
            this.btExplorer.Text = "Buscar";
            this.btExplorer.Click += new System.EventHandler(this.btExplorer_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Programa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txExplorer
            // 
            this.txExplorer.Location = new System.Drawing.Point(64, 50);
            this.txExplorer.Name = "txExplorer";
            this.txExplorer.Size = new System.Drawing.Size(213, 20);
            this.txExplorer.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chNavega);
            this.groupBox4.Controls.Add(this.btExplorer);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txExplorer);
            this.groupBox4.Location = new System.Drawing.Point(19, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 81);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Navegador de Internet";
            // 
            // chNavega
            // 
            this.chNavega.Location = new System.Drawing.Point(22, 19);
            this.chNavega.Name = "chNavega";
            this.chNavega.Size = new System.Drawing.Size(268, 17);
            this.chNavega.TabIndex = 17;
            this.chNavega.Text = "Utilizar un navegador externo";
            this.chNavega.UseVisualStyleBackColor = true;
            this.chNavega.CheckedChanged += new System.EventHandler(this.chNavega_CheckedChanged);
            // 
            // tabPreferencias
            // 
            this.tabPreferencias.Controls.Add(this.tabCompor);
            this.tabPreferencias.Controls.Add(this.tabConfig);
            this.tabPreferencias.Location = new System.Drawing.Point(4, 7);
            this.tabPreferencias.Name = "tabPreferencias";
            this.tabPreferencias.SelectedIndex = 0;
            this.tabPreferencias.Size = new System.Drawing.Size(391, 380);
            this.tabPreferencias.TabIndex = 45;
            // 
            // tabCompor
            // 
            this.tabCompor.Controls.Add(this.chMapaURL);
            this.tabCompor.Controls.Add(this.btRegistro);
            this.tabCompor.Controls.Add(this.label15);
            this.tabCompor.Controls.Add(this.txPass);
            this.tabCompor.Controls.Add(this.label14);
            this.tabCompor.Controls.Add(this.txLogin);
            this.tabCompor.Controls.Add(this.groupBox3);
            this.tabCompor.Controls.Add(this.txTac);
            this.tabCompor.Controls.Add(this.chMapa);
            this.tabCompor.Controls.Add(this.label1);
            this.tabCompor.Controls.Add(this.txTic);
            this.tabCompor.Controls.Add(this.groupBox1);
            this.tabCompor.Controls.Add(this.label2);
            this.tabCompor.Controls.Add(this.chAviso);
            this.tabCompor.Location = new System.Drawing.Point(4, 22);
            this.tabCompor.Name = "tabCompor";
            this.tabCompor.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompor.Size = new System.Drawing.Size(383, 354);
            this.tabCompor.TabIndex = 0;
            this.tabCompor.Text = " Comportamiento ";
            this.tabCompor.UseVisualStyleBackColor = true;
            // 
            // chMapaURL
            // 
            this.chMapaURL.Location = new System.Drawing.Point(188, 236);
            this.chMapaURL.Name = "chMapaURL";
            this.chMapaURL.Size = new System.Drawing.Size(183, 19);
            this.chMapaURL.TabIndex = 10;
            this.chMapaURL.Text = "Usar mapa si no hay URL";
            // 
            // btRegistro
            // 
            this.btRegistro.Location = new System.Drawing.Point(244, 22);
            this.btRegistro.Name = "btRegistro";
            this.btRegistro.Size = new System.Drawing.Size(76, 26);
            this.btRegistro.TabIndex = 21;
            this.btRegistro.Text = "Registrarse";
            this.btRegistro.Click += new System.EventHandler(this.btRegistro_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(15, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Clave:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(128, 45);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(97, 20);
            this.txPass.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(15, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 43;
            this.label14.Text = "Login en hipoqih:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txLogin
            // 
            this.txLogin.Location = new System.Drawing.Point(128, 19);
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(97, 20);
            this.txLogin.TabIndex = 0;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.cbIdioma);
            this.tabConfig.Controls.Add(this.groupBox5);
            this.tabConfig.Controls.Add(this.groupBox2);
            this.tabConfig.Controls.Add(this.label16);
            this.tabConfig.Controls.Add(this.groupBox4);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(383, 354);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = " Configuración ";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // cbIdioma
            // 
            this.cbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdioma.Items.AddRange(new object[] {
            "Castellano",
            "English"});
            this.cbIdioma.Location = new System.Drawing.Point(260, 122);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(95, 21);
            this.cbIdioma.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chSonido);
            this.groupBox5.Controls.Add(this.btSonido);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txSonido);
            this.groupBox5.Location = new System.Drawing.Point(19, 241);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 82);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sonidos";
            // 
            // chSonido
            // 
            this.chSonido.Location = new System.Drawing.Point(22, 19);
            this.chSonido.Name = "chSonido";
            this.chSonido.Size = new System.Drawing.Size(255, 17);
            this.chSonido.TabIndex = 20;
            this.chSonido.Text = "Activar sonido al recibir un aviso";
            this.chSonido.UseVisualStyleBackColor = true;
            this.chSonido.CheckedChanged += new System.EventHandler(this.chSonido_CheckedChanged);
            // 
            // btSonido
            // 
            this.btSonido.Location = new System.Drawing.Point(283, 46);
            this.btSonido.Name = "btSonido";
            this.btSonido.Size = new System.Drawing.Size(55, 26);
            this.btSonido.TabIndex = 22;
            this.btSonido.Text = "Buscar";
            this.btSonido.Click += new System.EventHandler(this.btSonido_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Sonido:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSonido
            // 
            this.txSonido.Location = new System.Drawing.Point(64, 50);
            this.txSonido.Name = "txSonido";
            this.txSonido.Size = new System.Drawing.Size(213, 20);
            this.txSonido.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(167, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 24);
            this.label16.TabIndex = 47;
            this.label16.Text = "Idioma:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 419);
            this.Controls.Add(this.tabPreferencias);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "preferencias";
            this.ShowInTaskbar = false;
            this.Text = "Configuración del plugin de hipoqih para XP";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.preferencias_Close);
            this.Load += new System.EventHandler(this.preferencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPreferencias.ResumeLayout(false);
            this.tabCompor.ResumeLayout(false);
            this.tabCompor.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txLat;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txLon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbGPS;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txAlto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txAncho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chAviso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txTac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txTic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chMapa;
        private System.Windows.Forms.Button btPosi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btExplorer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txExplorer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabPreferencias;
        private System.Windows.Forms.TabPage tabCompor;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btSonido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txSonido;
        private System.Windows.Forms.Button btRegistro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txLogin;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chSonido;
        private System.Windows.Forms.CheckBox chMapaURL;
        private System.Windows.Forms.CheckBox chNavega;
    }
}