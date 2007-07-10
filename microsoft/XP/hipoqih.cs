/*
 * Created by Andrés Ribera
 * Copyright (C) 2007 hipoqih.com, All Rights Reserved.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using GPSUtilities;

namespace plugin_hipoqih
{
    
    public class hipoqih : Form
    {
        // literales
        private string[] lite = new string[20];

        //el ID SEGURO
        private string idseguro = "NONE";

        //el contador de errores web
        private int weberrorcount = 0;

        //el contador de tiempo
        private int tiempo = 0;

        // posiciones
        private double lat;
        private double lon;

        // ultima posicion
        private double lastlat;
        private double lastlon;

        //indicadores de estado
        private bool sw_start = false;
        private bool sw_conect = false;

        // los formularios
        private Acercade frmAcercade = null;
        private amigos frmAmigos = null;
        public static preferencias frmPreferencias = null;

        //componentes
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        public Timer timer;
        private IContainer components;
        private GroupBox gTextoAviso;
        private TextBox txAviso;
        private TextBox txFecha;
        private Button bMapa;
        private PictureBox imgOn;
        private PictureBox imgOff;
        private Label lComStatus;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem actualizarToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem configurarToolStripMenuItem;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private System.IO.Ports.SerialPort serialPort1;
        private TextBox txLogin;
        private Label label4;
        private TextBox txRadio;
        private Label label7;
        private Label label5;
        private Button btLimpia;
        private Timer timerGPS;
        private Label label6;
        private ToolStripMenuItem dondeEToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;

        public hipoqih()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hipoqih));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.bMapa = new System.Windows.Forms.Button();
            this.gTextoAviso = new System.Windows.Forms.GroupBox();
            this.txFecha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btLimpia = new System.Windows.Forms.Button();
            this.txRadio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txAviso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.imgOff = new System.Windows.Forms.PictureBox();
            this.imgOn = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lComStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dondeEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerGPS = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gTextoAviso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 39);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(156, 47);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(61, 23);
            this.bStop.TabIndex = 6;
            this.bStop.Text = "Para";
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(156, 16);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(61, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Conecta";
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLongitude);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLatitude);
            this.groupBox1.Controls.Add(this.bStop);
            this.groupBox1.Controls.Add(this.bStart);
            this.groupBox1.Location = new System.Drawing.Point(6, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posición";
            // 
            // txtLongitude
            // 
            this.txtLongitude.BackColor = System.Drawing.SystemColors.Info;
            this.txtLongitude.Location = new System.Drawing.Point(69, 49);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.ReadOnly = true;
            this.txtLongitude.Size = new System.Drawing.Size(71, 20);
            this.txtLongitude.TabIndex = 2;
            this.txtLongitude.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Longitud:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitud:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLatitude
            // 
            this.txtLatitude.BackColor = System.Drawing.SystemColors.Info;
            this.txtLatitude.Location = new System.Drawing.Point(69, 18);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.ReadOnly = true;
            this.txtLatitude.Size = new System.Drawing.Size(71, 20);
            this.txtLatitude.TabIndex = 1;
            this.txtLatitude.TabStop = false;
            // 
            // bMapa
            // 
            this.bMapa.Location = new System.Drawing.Point(165, 38);
            this.bMapa.Name = "bMapa";
            this.bMapa.Size = new System.Drawing.Size(58, 22);
            this.bMapa.TabIndex = 11;
            this.bMapa.Text = "mapa";
            this.bMapa.Click += new System.EventHandler(this.bMapa_Click);
            // 
            // gTextoAviso
            // 
            this.gTextoAviso.Controls.Add(this.txFecha);
            this.gTextoAviso.Controls.Add(this.label6);
            this.gTextoAviso.Controls.Add(this.btLimpia);
            this.gTextoAviso.Controls.Add(this.txRadio);
            this.gTextoAviso.Controls.Add(this.label7);
            this.gTextoAviso.Controls.Add(this.txLogin);
            this.gTextoAviso.Controls.Add(this.label4);
            this.gTextoAviso.Controls.Add(this.txAviso);
            this.gTextoAviso.Controls.Add(this.label5);
            this.gTextoAviso.Location = new System.Drawing.Point(6, 149);
            this.gTextoAviso.Name = "gTextoAviso";
            this.gTextoAviso.Size = new System.Drawing.Size(234, 136);
            this.gTextoAviso.TabIndex = 10;
            this.gTextoAviso.TabStop = false;
            this.gTextoAviso.Text = "Ultimo aviso recibido";
            // 
            // txFecha
            // 
            this.txFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFecha.Location = new System.Drawing.Point(37, 107);
            this.txFecha.Name = "txFecha";
            this.txFecha.ReadOnly = true;
            this.txFecha.Size = new System.Drawing.Size(108, 20);
            this.txFecha.TabIndex = 1;
            this.txFecha.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Hora:";
            // 
            // btLimpia
            // 
            this.btLimpia.Location = new System.Drawing.Point(160, 105);
            this.btLimpia.Name = "btLimpia";
            this.btLimpia.Size = new System.Drawing.Size(55, 23);
            this.btLimpia.TabIndex = 18;
            this.btLimpia.Text = "Limpiar";
            this.btLimpia.Click += new System.EventHandler(this.btLimpia_Click);
            // 
            // txRadio
            // 
            this.txRadio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txRadio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txRadio.Location = new System.Drawing.Point(149, 23);
            this.txRadio.Name = "txRadio";
            this.txRadio.ReadOnly = true;
            this.txRadio.Size = new System.Drawing.Size(35, 20);
            this.txRadio.TabIndex = 17;
            this.txRadio.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(188, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "metros:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txLogin
            // 
            this.txLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLogin.Location = new System.Drawing.Point(37, 23);
            this.txLogin.Name = "txLogin";
            this.txLogin.ReadOnly = true;
            this.txLogin.Size = new System.Drawing.Size(92, 20);
            this.txLogin.TabIndex = 13;
            this.txLogin.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "From";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txAviso
            // 
            this.txAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txAviso.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAviso.Location = new System.Drawing.Point(5, 48);
            this.txAviso.Multiline = true;
            this.txAviso.Name = "txAviso";
            this.txAviso.ReadOnly = true;
            this.txAviso.Size = new System.Drawing.Size(223, 54);
            this.txAviso.TabIndex = 0;
            this.txAviso.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(128, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "at";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgOff
            // 
            this.imgOff.Image = ((System.Drawing.Image)(resources.GetObject("imgOff.Image")));
            this.imgOff.Location = new System.Drawing.Point(21, 292);
            this.imgOff.Name = "imgOff";
            this.imgOff.Size = new System.Drawing.Size(16, 19);
            this.imgOff.TabIndex = 9;
            this.imgOff.TabStop = false;
            // 
            // imgOn
            // 
            this.imgOn.BackColor = System.Drawing.Color.White;
            this.imgOn.Image = ((System.Drawing.Image)(resources.GetObject("imgOn.Image")));
            this.imgOn.Location = new System.Drawing.Point(21, 292);
            this.imgOn.Name = "imgOn";
            this.imgOn.Size = new System.Drawing.Size(16, 19);
            this.imgOn.TabIndex = 8;
            this.imgOn.TabStop = false;
            this.imgOn.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lComStatus
            // 
            this.lComStatus.Location = new System.Drawing.Point(101, 295);
            this.lComStatus.Name = "lComStatus";
            this.lComStatus.Size = new System.Drawing.Size(119, 18);
            this.lComStatus.TabIndex = 0;
            this.lComStatus.Text = "Parado";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Estado:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(243, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarToolStripMenuItem,
            this.dondeEToolStripMenuItem,
            this.toolStripMenuItem3,
            this.configurarToolStripMenuItem,
            this.aToolStripMenuItem,
            this.toolStripMenuItem5,
            this.salirToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Opciones";
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.actualizarToolStripMenuItem.Text = "Refrescar Posición";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // dondeEToolStripMenuItem
            // 
            this.dondeEToolStripMenuItem.Name = "dondeEToolStripMenuItem";
            this.dondeEToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.dondeEToolStripMenuItem.Text = "¿Donde están mis amigos?";
            this.dondeEToolStripMenuItem.Click += new System.EventHandler(this.dondeEToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.configurarToolStripMenuItem.Text = "Configurar";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.aToolStripMenuItem.Text = "Acerca de hipoqih";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(207, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // timerGPS
            // 
            this.timerGPS.Interval = 1000;
            this.timerGPS.Tick += new System.EventHandler(this.timerGPS_Tick);
            // 
            // hipoqih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 314);
            this.Controls.Add(this.lComStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bMapa);
            this.Controls.Add(this.gTextoAviso);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imgOn);
            this.Controls.Add(this.imgOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "hipoqih";
            this.Text = "hipoqih plugin";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.hipoqih_Closing);
            this.Load += new System.EventHandler(this.hipoqih_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gTextoAviso.ResumeLayout(false);
            this.gTextoAviso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        WebRequest req = null;
        WebResponse resul = null;

        //notifyicon
        //el icono minimizado y los eventos del menu del icono minimizado
        NotifyIcon NotifyIcon1 = new NotifyIcon();
        ContextMenu ContextMenu1 = new ContextMenu();
        int formTop = 0;
        int formLeft = 0;
        int formHeight = 0;
        int formWidth = 0;
        private void Salir_Click(object sender, System.EventArgs e)
        {
            Acabar();
        }
        private void Restaurar_Click(object sender, System.EventArgs e)
        {
            //' Este evento maneja tanto los menús Restaurar como el NotifyIcon.DoubleClick
            this.Visible = true;
            this.Top = formTop;
            this.Left = formLeft;
            this.Height = formHeight;
            this.Width = formWidth;
            this.WindowState = FormWindowState.Normal;
        }
        private void Conectar_Click(object sender, System.EventArgs e)
        {
            bStart_Click(bStart, null);
        }
        private void Desconectar_Click(object sender, System.EventArgs e)
        {
            bStop_Click(bStop, null);
        }
        private void Refrescar_Click(object sender, System.EventArgs e)
        {
            actualizarToolStripMenuItem_Click(actualizarToolStripMenuItem, null);
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            //' Cuando se minimice se quedará disponible en la barra de tareas
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }
        private void Form1_Move(object sender, System.EventArgs e)
        {
            if (this.Top > 0)
            {
                formTop = this.Top;
                formLeft = this.Left;
                formHeight = this.Height;
                formWidth = this.Width;
            }
        }
        // ---> fin de rutinas de notifyicon

        public void carga_parametros()
        {
            //leer la configuracion
            Config.Leer();

            // idioma
            // pone bien los textos
            if (Config.idioma == "ES")
            {
                lite[0] = "Conectando ...";
                lite[1] = "Parado";
                lite[2] = "El usuario y la password de CONFIG.XML no están bien, revisa la configuración.";
                lite[3] = "Conectado";
                lite[4] = " esta a ";
                lite[5] = " metros.";
                lite[6] = " metros, ¿quieres verlo en el mapa?";
                lite[7] = "Aviso de hipoqih";
                lite[8] = "Ha llegado un aviso de ";
                lite[9] = ", ¿quieres verlo?";
                lite[10] = "¿ Donde estoy ?";
                lite[11] = "No estás conectado, no se va a enviar nada.";
                lite[12] = "Error al conectar el GPS. Comprueba el puerto ó activa el bluetooth.";
                lite[13] = "No hay posición, no se puede enviar.";
                lite[14] = "&Mostrar";
                lite[15] = "&Conectar";
                lite[16] = "&Desconectar";
                lite[17] = "&Refrescar";
                lite[18] = "&Salir";
                lite[19] = "Estas conectado. ¿Quieres mantener la posicion en hipoqih al salir?";
                this.bStop.Text = "Para";
                this.bStart.Text = "Conecta";
                this.groupBox1.Text = "Posición";
                this.label2.Text = "Longitud:";
                this.label1.Text = "Latitud:";
                this.bMapa.Text = "Mapa";
                this.gTextoAviso.Text = "Ultimo aviso recibido";
                this.label6.Text = "Hora:";
                this.btLimpia.Text = "Limpiar";
                this.label7.Text = "metros:";
                this.label5.Text = "a";
                this.label4.Text = "De";
                this.lComStatus.Text = "Parado";
                this.label3.Text = "Estado:";
                this.toolStripMenuItem1.Text = "Opciones";
                this.actualizarToolStripMenuItem.Text = "Refrescar Posición";
                this.configurarToolStripMenuItem.Text = "Configurar";
                this.aToolStripMenuItem.Text = "Acerca de hipoqih";
                this.salirToolStripMenuItem.Text = "Salir";
                this.dondeEToolStripMenuItem.Text = "¿Donde están mis amigos?";
            }
            else
            {
                lite[0] = "Connecting ...";
                lite[1] = "Stopped";
                lite[2] = "The user and password of CONFIG.XML is not ok, modify the configuration.";
                lite[3] = "Connected";
                lite[4] = " is at ";
                lite[5] = " meters.";
                lite[6] = " meters, do you want to see it in the map?";
                lite[7] = "Alert of hipoqih";
                lite[8] = "Has arrived an alert from ";
                lite[9] = ", do you want to see it?";
                lite[10] = "Where am I?";
                lite[11] = "You are not connected, nothing will be sent.";
                lite[12] = "Error connecting GPS. Verify the port or the bluetooth.";
                lite[13] = "No have position for sent.";
                lite[14] = "&Show";
                lite[15] = "&Conect";
                lite[16] = "&Disconnect";
                lite[17] = "&Refresh";
                lite[18] = "&Quit";
                lite[19] = "You are connected. Do you want to keep the position in hipoqih after exit?";
                this.bStop.Text = "Stop";
                this.bStart.Text = "Conect";
                this.groupBox1.Text = "Position";
                this.label2.Text = "Longitude:";
                this.label1.Text = "Latitude:";
                this.bMapa.Text = "Map";
                this.gTextoAviso.Text = "Last alert received";
                this.label6.Text = "Time:";
                this.btLimpia.Text = "Clean";
                this.label7.Text = "meters:";
                this.label5.Text = "at";
                this.label4.Text = "From";
                this.lComStatus.Text = "Stopped";
                this.label3.Text = "Status:";
                this.toolStripMenuItem1.Text = "Options";
                this.actualizarToolStripMenuItem.Text = "Refresh Position";
                this.configurarToolStripMenuItem.Text = "Configure";
                this.aToolStripMenuItem.Text = "About of hipoqih";
                this.salirToolStripMenuItem.Text = "Quit";
                this.dondeEToolStripMenuItem.Text = "Where are my friends?";
            }

            //notifyicon
            //el menu contextual minimizado
            ContextMenu1.MenuItems[0].Text = lite[14];
            ContextMenu1.MenuItems[2].Text = lite[15];
            ContextMenu1.MenuItems[3].Text = lite[16];
            ContextMenu1.MenuItems[4].Text = lite[17];
            ContextMenu1.MenuItems[6].Text = lite[18];
            //fin notifyicon

            if (sw_conect == true)
            {
                lComStatus.Text = lite[3];
                NotifyIcon1.Text = "hipoqih plugin: " + lite[3];
            }
            else
            {
                lComStatus.Text = lite[1];
                NotifyIcon1.Text = "hipoqih plugin: " + lite[1];
            }
            // si la configuracion que tengamos es GPS se abre
            if (Config.gps == "GPS")
            {
                if (serialPort1.IsOpen == false)
                {
                    //hacer la conexion con el GPS
                    AbrirGPS();
                    timerGPS.Start();
                }
            }
            else
            {
                if (serialPort1.IsOpen == true)
                {
                    CerrarGPS();
                    timerGPS.Stop();
                }
            }
            //pinta la posicion inicial
            PintaPosicion();
        }

        private void hipoqih_Load(object sender, System.EventArgs e)
        {
            Program.frmSplash.Refresh();
     
            // mira si ya esta ejecutandose
            if (PrevInstance())
            {
                Application.Exit();
                this.Dispose();
                return;
            }

            //notifyicon
            //el menu contextual minimizado
            ContextMenu1.MenuItems.Add(lite[14], new EventHandler(this.Restaurar_Click));
            ContextMenu1.MenuItems[0].DefaultItem = true;
            ContextMenu1.MenuItems.Add("-");
            ContextMenu1.MenuItems.Add(lite[15], new EventHandler(this.Conectar_Click));
            ContextMenu1.MenuItems.Add(lite[16], new EventHandler(this.Desconectar_Click));
            ContextMenu1.MenuItems[3].Enabled = false;
            ContextMenu1.MenuItems.Add(lite[17], new EventHandler(this.Refrescar_Click));
            ContextMenu1.MenuItems.Add("-");
            ContextMenu1.MenuItems.Add(lite[18], new EventHandler(this.Salir_Click));
            //' Asignar los valores para el NotifyIcon
            NotifyIcon1.Icon = this.Icon;
            NotifyIcon1.ContextMenu = this.ContextMenu1;
            NotifyIcon1.Text = "hipoqih plugin";
            NotifyIcon1.Visible = true;
            // Asignamos los otros eventos al formulario
            this.Resize += new EventHandler(this.Form1_Resize);
            this.Move += new EventHandler(this.Form1_Move);
            // Asignamos el evento DoubleClick del NotifyIcon
            this.NotifyIcon1.DoubleClick += new EventHandler(this.Restaurar_Click);
            formTop = this.Top;
            formLeft = this.Left;
            formHeight = this.Height;
            formWidth = this.Width;
            //fin notifyicon

            //pone bien los controles
            timer.Interval = Config.segundos * 1000;
            timer.Enabled = false;
            bStop.Enabled = false;
            bStart.Enabled = true;
            bMapa.Enabled = false;
            dondeEToolStripMenuItem.Enabled = false;
            actualizarToolStripMenuItem.Enabled = false;

            //carga la configuracion incial
            carga_parametros();
            
            //inicia el web request
            req = WebRequest.Create("http://hipoqih.com");
            req.Timeout = 10000;
            try
            {
                resul = req.GetResponse();
            }
            catch { }
            
            // ya esta iniciado
            Program.frmSplash.Close();
        }

        private void hipoqih_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //cierra el plugin
            Acabar();
        }

        protected override void Dispose(bool disposing)
        {
            //Dispose de todo??
        }

        private void Acabar()
        {
            //cierra el plugin
            DialogResult dlg_c = DialogResult.No;
            //cerrar la comunicacion con el GPS si hace falta
            if (serialPort1.IsOpen)
            {
                CerrarGPS();
            }
            //si esta conectado manda la baja
            if (sw_conect)
            {
                dlg_c = MessageBox.Show(lite[19], lite[7], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dlg_c == DialogResult.No)
                {
                    manda_baja();
                }
            }
            // menu contextual
            this.NotifyIcon1.Visible = false;
            this.NotifyIcon1 = null;
            this.ContextMenu1 = null; 

            Application.Exit();
            this.Dispose();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            lComStatus.Text = lite[0];
            bStart.Enabled = false;
            bStop.Enabled = true;
            this.Refresh();
            manda_alta();
            if (serialPort1.IsOpen)
            {
                CerrarGPS();
                timerGPS.Stop();
            }
            if (Config.gps == "GPS")
            {
                //hacer la conexion con el GPS
                AbrirGPS();
                timerGPS.Start();
            }
            timer.Enabled = true;
            sw_start = true;
            EnviaPosicion();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            bStart.Enabled = true;
            bStop.Enabled = false;
            bMapa.Enabled = false;
            dondeEToolStripMenuItem.Enabled = false;
            actualizarToolStripMenuItem.Enabled = false;

            lComStatus.Text = lite[1];
            NotifyIcon1.Text = "hipoqih plugin: " + lite[1];
            ContextMenu1.MenuItems[3].Enabled = false;
            ContextMenu1.MenuItems[2].Enabled = true;
            this.Refresh();
            if (sw_conect)
            {
                manda_baja();
            }
            timer.Enabled = false;
            sw_start = false;
            sw_conect = false;
            imgOn.Visible = false;
            idseguro = "NONE";
            lastlat = 0;
            lastlon = 0;
            tiempo = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EnviaPosicion();
        }

        private void timerGPS_Tick(object sender, EventArgs e)
        {
            LeerGPS();
        }

        private void EnviaPosicion()
        {
            if (!sw_conect)
            {
                manda_alta();
            }
            PintaPosicion();
            if (sw_start)
            {
                double tmpa;
                double tmpb;
                try
                {
                    // coge la posicion actual
                    System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                    lon = double.Parse(txtLongitude.Text,nfi);
                    lat = double.Parse(txtLatitude.Text,nfi);
                }
                catch
                {
                    lon = 0;
                    lat = 0;
                }

                //si hay posicion se comunica
                if (lat + lon != 0)
                {
                    // controlar si no han cambiado las posiciones
                    // si es casi la misma esperar a minutos para mandar cosas  
                    tmpa = Math.Abs(lon - lastlon);
                    tmpb = Math.Abs(lat - lastlat);
                    tiempo = tiempo + Config.segundos;
                    if ((tmpa > 0.00001) | (tmpb > 0.00001) | (tiempo > Config.minutos))
                    {
                        tiempo = 0;
                        imgOff.Visible = false;
                        imgOn.Visible = true;
                        this.Refresh();
                        comunica("http://www.hipoqih.com/oreja.php?iduser=" + idseguro + "&lat=" + txtLatitude.Text + "&lon=" + txtLongitude.Text);
                        imgOff.Visible = true;
                        imgOn.Visible = false;
                    }
                }
                lastlat = lat;
                lastlon = lon;
                if (timer.Interval != Config.segundos * 1000)
                {
                    timer.Interval = Config.segundos * 1000;
                }
            }
        }
        private void PintaPosicion()
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            if (Config.gps == "GPS")
            {
                //hay que interrogar al GPS y pintar las posiciones
                //LeerGPS();
                // pone los numeros en yanqui
                txtLatitude.Text = GPSlatitud.ToString("####.###########", nfi);
                txtLongitude.Text = GPSlongitud.ToString("####.###########", nfi);
            }
            if (Config.gps == "NONE")
            {
                // pone los numeros en yanqui
                txtLatitude.Text = Config.latitud.ToString("####.###########", nfi);
                txtLongitude.Text = Config.longitud.ToString("####.###########", nfi);
            }

            if (Config.gps == "FILE")
            {
                // lee de un archivo
                StreamReader objReader = new StreamReader("c:\\ubicate");
                string sLine = "";
                ArrayList arrText = new ArrayList();
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();
                txtLatitude.Text = arrText[0].ToString();
                txtLongitude.Text = arrText[1].ToString();
            }
        }

        private void manda_alta()
        {
            // manda la comunicacion del alta
            comunica("http://www.hipoqih.com/alta.php?user=" + Config.usuario + "&pass=" + Config.clave);
        }

        private void manda_baja()
        {
            // manda la comunicacion de la baja
            comunica("http://www.hipoqih.com/baja.php?iduser=" + idseguro);
        }

        private void comunica(string txUrl)
        {
            //el texto de la web
            string Texto_Web = "";

            try
            {
                req = WebRequest.Create(txUrl);
                resul = req.GetResponse();
                System.IO.Stream recibir = resul.GetResponseStream();
                Encoding encode = Encoding.GetEncoding("utf-8");
                System.IO.StreamReader sr = new System.IO.StreamReader(recibir, encode);
                // la web funciona
                weberrorcount = 0;
                // leer el estreamer
                while (sr.Peek() >= 0)
                {
                    Texto_Web += sr.ReadLine();
                }
                recibir.Close();
                resul.Close();
            }
            catch (WebException e)
            {
                // casca la web ...
                // se retrasa el tiempo ....
                weberrorcount = weberrorcount + 1;
                timer.Interval = (weberrorcount * 60000);
            }
            catch (Exception e)
            {
            }

            //ahora interpreta la cadena
            // que viene asi:
            // echo'AVISO$$$'texto.'$$$'.$urlav.'$$$'.$lat.'$$$'.$lon.'$$$'.$radio.'$$$'.$login.'$$$'.'N';
            string st_Texto = "";
            string st_URL = "";
            string st_TX = "";
            string st_lat = "";
            string st_lon = "";
            string st_login = "";
            string st_radio = "";
            string st_pos = "";
            int i_a;
            int i_b;
            int i_c;
            int i_d;
            int i_e;
            int i_f;
            int i_g;
            int i_h;
            DialogResult dlg_c = DialogResult.No;
            //coge el contenido devuelto por hipoqih y lo parsea
            if (Texto_Web != null)
            {
                st_Texto = Texto_Web;
                i_a = st_Texto.IndexOf("$$$");
                if (i_a > 0)
                {
                    if (st_Texto.Substring(0, 6) == "CODIGO")
                    {
                        //es la respuesta del alta, viene el id seguro
                        i_b = st_Texto.IndexOf("$$$", i_a + 3);
                        idseguro = st_Texto.Substring(i_a + 3, i_b - i_a - 3);
                        if (idseguro == "ERROR")
                        {
                            timer.Stop();
                            dlg_c = MessageBox.Show(lite[2], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            bStop_Click(bStop, null);
                            return;
                        }
                        else
                        {
                            lComStatus.Text = lite[3];
                            NotifyIcon1.Text = "hipoqih plugin: " + lite[3];
                            ContextMenu1.MenuItems[3].Enabled = true;
                            ContextMenu1.MenuItems[2].Enabled = false;
                            sw_conect = true;
                            bMapa.Enabled = true;
                            dondeEToolStripMenuItem.Enabled = true;
                            actualizarToolStripMenuItem.Enabled = true;
                        }
                    }
                    if (st_Texto.Substring(0, 5) == "AVISO")
                    {
                        // hay un aviso pendiente
                        try
                        {
                            i_b = st_Texto.IndexOf("$$$", i_a + 3);
                            st_TX = st_Texto.Substring(i_a + 3, i_b - i_a - 3);
                            i_c = st_Texto.IndexOf("$$$", i_b + 3);
                            st_URL = st_Texto.Substring(i_b + 3, i_c - i_b - 3);
                            i_d = st_Texto.IndexOf("$$$", i_c + 3);
                            st_lat = st_Texto.Substring(i_c + 3, i_d - i_c - 3);
                            i_e = st_Texto.IndexOf("$$$", i_d + 3);
                            st_lon = st_Texto.Substring(i_d + 3, i_e - i_d - 3);
                            i_f = st_Texto.IndexOf("$$$", i_e + 3);
                            st_radio = st_Texto.Substring(i_e + 3, i_f - i_e - 3);
                            i_g = st_Texto.IndexOf("$$$", i_f + 3);
                            st_login = st_Texto.Substring(i_f + 3, i_g - i_f - 3);
                            i_h = st_Texto.IndexOf("$$$", i_g + 3);
                            st_pos = st_Texto.Substring(i_g + 3, i_h - i_g - 3);
                        }
                        catch
                        { }
                        // mostrar el texto
                        if (st_Texto != "")
                        {
                            if (st_pos == "S")
                            {
                                // muestra el texto del aviso en el form
                                txAviso.Text = st_login + lite[4] + st_radio + lite[5];
                                txFecha.Text = System.DateTime.Now.ToString();
                                txLogin.Text = "hipoqih";
                                txRadio.Text = "";
                            }
                            else
                            {
                                // muestra el texto del aviso en el form
                                txAviso.Text = st_TX;
                                txFecha.Text = System.DateTime.Now.ToString();
                                txLogin.Text = st_login;
                                txRadio.Text = st_radio;
                            }
                            //lanzar un sonido
                            if (Config.sonido != "NONE")
                            {
                                Sonar(Config.sonido);
                            }
                            this.Visible = true;
                            this.Top = formTop;
                            this.Left = formLeft;
                            this.Height = formHeight;
                            this.Width = formWidth;
                            this.WindowState = FormWindowState.Normal;
                            this.Show();
                        }
                        // se va a mostrar.
                        //parche por si acaso
                        if (st_URL.ToUpper() == "HTTP://") st_URL = "";
                        if (st_pos=="S")
                        {
                            timer.Enabled = false;
                            dlg_c = MessageBox.Show(st_login + lite[4] + st_radio + lite[6], lite[7], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            timer.Enabled = true;
                        }
                        else
                        {
                            if (st_URL == "" & !Config.avisomapaurl)
                            {
                                // no se saca mensaje si no hay URL y no esta marcado el flag de mapa
                            }
                            else
                            {
                                if (!Config.avisoauto)
                                {
                                    timer.Enabled = false;
                                    dlg_c = MessageBox.Show(lite[8] + st_login + lite[9], lite[7], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                    timer.Enabled = true;
                                }
                            }
                        }
                        if ((Config.avisoauto & st_pos=="N") | dlg_c == DialogResult.Yes)
                        {
                            //al mostrar el aviso se sube el timer a un minuto a huevo
                            timer.Interval = 120000;
                            // mostrar la URL en el mapa si esta configurado para que se muestran en mapa, 
                            // si no tiene URL y esta configurado para mapa o si el aviso es posicional
                            if ((Config.avisomapa) | (Config.avisomapaurl & st_URL == "") | (st_pos == "S"))
                            {
                                Abrir_URL("http://www.hipoqih.com/mapa_aviso.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), lite[7]);
                            }
                            else 
                            {
                                if (st_URL != "") Abrir_URL(st_URL, lite[7]);
                            }
                        }
                    }
                }
            }
        }

        private void bMapa_Click(object sender, EventArgs e)
        {
            // si no hay posicion
            if (txtLatitude.Text == "" & txtLongitude.Text == "")
            {
                MessageBox.Show(lite[13], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (Config.idioma == "ES") 
                    Abrir_URL("http://www.hipoqih.com/mapa_mio_es.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), lite[10]);
                else
                    Abrir_URL("http://www.hipoqih.com/mapa_mio_en.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), lite[10]);
            }
        }

        private void Abrir_URL(string url, string titulo)
        {
            if (Config.explorador == "hipoqih")
            {
                aviso ff = new aviso();
                ff.Width = Config.avisowidth;
                ff.Height = Config.avisoheight;
                ff.Top = Config.avisotop;
                ff.Left = Config.avisoleft;
                ff.Text = titulo;
                ff.st_url = url;
                ff.Show();
            }
            else
            {
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.Arguments = url;
                    proc.StartInfo.FileName = @Config.explorador;
                    proc.Start();
                }
                catch
                { 
                }
            }
        }
        
        private void btLimpia_Click(object sender, EventArgs e)
        {
            txAviso.Text = "";
            txFecha.Text = "";
            txLogin.Text = "";
            txRadio.Text = "";
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (frmPreferencias == null || frmPreferencias.IsDisposed)
            {
                frmPreferencias = new preferencias();
                frmPreferencias.CogerID(idseguro);
                frmPreferencias.Show(this);
            }
            else
            {
                frmPreferencias.BringToFront();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acabar();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAcercade == null || frmAcercade.IsDisposed)
            {
                frmAcercade = new Acercade();
                frmAcercade.Show(this);
            }
            else
            {
                frmAcercade.BringToFront();
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se borran para forzar el envio de las nuevas
            lastlon = 0;
            lastlat = 0;
            // abre y cierra el GPS ..
            if (Config.gps == "GPS")
            {
                timerGPS.Stop();
                CerrarGPS();
                AbrirGPS();
                timerGPS.Start();
            }
            // si no hay posicion
            if (txtLatitude.Text == "" & txtLongitude.Text == "")
            {
                MessageBox.Show(lite[13], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (sw_start)
                {
                    EnviaPosicion();
                }
                else
                {
                    // si no esta conectado
                    MessageBox.Show(lite[11], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private bool PrevInstance()
        {
            //mira si ya se esta ejecutando el programa
            System.Diagnostics.Process[] procesos = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (procesos.Length > 1)
                return true;
            else
                return false;
        }

        // para saber la ruta actual (no se necesita ...)
        //private static string RutaActual()
        //{
        //     string arch = Process.GetCurrentProcess().MainModule.FileName;
        //     return arch.Substring(0, arch.LastIndexOf("\\"));
        //}

        // para el sonido
        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags]
        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        private void Sonar(string file)
        {
            PlaySound(file, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
        }
        
        //GPS---------->

        // posiciones del GPS
        private double GPSlatitud;
        private double GPSlongitud;

        private void AbrirGPS()
        {
            try
            {
                serialPort1.PortName = Config.port;
                serialPort1.BaudRate = int.Parse(Config.speed);
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(lite[12], "hipoqih plugin", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                System.Console.Write(ex.Message);
            }            
        }
        private void CerrarGPS()
        {
            serialPort1.Close();
        }
        private void LeerGPS()
        {
            if (serialPort1.IsOpen)
            {
                //se hacen "n" intentos de leer una posicion válida
                for (int i = 1; i < 2; i++)
                {
                    string buffer = string.Empty;
                    System.Diagnostics.Debug.Assert(serialPort1 != null);
                    buffer = serialPort1.ReadExisting();
                    //Get the latest last line
                    int endindex = -1;
                    int startindex = buffer.IndexOf("$GPGGA", 0);
                    if (startindex >= 0)
                    {
                        endindex = buffer.IndexOf("$", startindex + 1);
                        if (endindex > 0)
                        {
                            string ggabuffer = buffer.Substring(startindex, endindex - startindex);
                            AnalyzeGPSStream(ggabuffer);
                        }
                    }
                    startindex = -1;
                    endindex = -1;

                    startindex = buffer.IndexOf("$GPGSA", 0);
                    if (startindex >= 0)
                    {
                        endindex = buffer.IndexOf("$", startindex + 1);
                        if (endindex > 0)
                        {
                            string gpgbuffer = buffer.Substring(startindex, endindex - startindex);
                            AnalyzeGPSStream(gpgbuffer);
                        }

                    }
                    startindex = -1;
                    endindex = -1;
                    startindex = buffer.IndexOf("$GPRMC", 0);
                    if (startindex >= 0)
                    {
                        endindex = buffer.IndexOf("$", startindex + 1);
                        if (endindex > 0)
                        {
                            string gprbuffer = buffer.Substring(startindex, endindex - startindex);
                            AnalyzeGPSStream(gprbuffer);
                        }
                    }
                }
            }
        }

        private void AnalyzeGPSStream(string buffer)
        {
            GPSSentence sentense = new GPSSentence(buffer);
            //if (sentense.Type == GPSSentenceType.ActiveSatellites)
            //{
            //    //Satellite info 
            //    SatelliteInformation sinfo =
            //        new SatelliteInformation(sentense.NumberOfSatellites,
            //        sentense.PositionDilusionPrecision,
            //        sentense.HorizontalDilusionPrecision,
            //        sentense.VerticalDilsutionPrecsion);
            //}
            //else if (sentense.Type == GPSSentenceType.PositionAndTime)
            //{
            //    //Speed Information
            //    GroundSpeedInformation speedinfo = new GroundSpeedInformation(sentense.LatLong,
            //        sentense.Direction, sentense.Time, sentense.Speed);
            //} else 
            if (sentense.Type == GPSSentenceType.FixedData)
            {
                //Location info 
                LocationInformation linfo = new LocationInformation(sentense.LatLong,
                        sentense.Altitude, sentense.Direction, sentense.Time);
                //guardar los valores
                GPSlatitud = sentense.LatLong.Latitude;
                GPSlongitud = sentense.LatLong.Longitude;
                // pone los numeros en yanqui
                System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                txtLatitude.Text = GPSlatitud.ToString("####.###########", nfi);
                txtLongitude.Text = GPSlongitud.ToString("####.###########", nfi);
            }
        }
        // ---------------------  FIN de GPS -----------------


        private void dondeEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAmigos == null)
            {
                frmAmigos = new amigos();
                frmAmigos.idseguro = idseguro;
                frmAmigos.comunica();
                frmAmigos.Show();
            }
            else
            {
                try
                {
                    frmAmigos.WindowState = FormWindowState.Normal;
                    frmAmigos.idseguro = idseguro;
                    frmAmigos.comunica();
                    frmAmigos.Show();
                }
                catch
                {
                    frmAmigos = new amigos();
                    frmAmigos.idseguro = idseguro;
                    frmAmigos.comunica();
                    frmAmigos.Show();
                }
            }
        }
    }
}