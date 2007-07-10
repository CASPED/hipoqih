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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace plugin_hipoqih
{
    public partial class preferencias : Form
    {
        // literales
        private string[] lite = new string[12];

        //el ID SEGURO
        private string idseguro = "NONE";

        //el formulario de buscar la posicion
        private busca_posi frmBuscaposi;

        public preferencias()
        {
            InitializeComponent();
        }

        private void preferencias_Load(object sender, EventArgs e)
        {
            //leer la configuracion
            Config.Leer();

            // idioma
            // pone bien los textos
            if (Config.idioma == "ES")
            {
                lite[0] = "El intérvalo en movimiento no puede ser de menos de 3 segundos";
                lite[1] = "Comprobación de Datos";
                lite[2] = "El intérvalo parado no puede ser de menos de 30 segundos";
                lite[3] = "El valor de 'ALTO' no es válido, debe estar entre 200 y 3000";
                lite[4] = "El valor de 'ANCHO' no es válido, debe estar entre 200 y 3000";
                lite[5] = "El valor de 'POSICION X' no es válido, debe estar entre 0 y 3000";
                lite[6] = "El valor de 'POSICION Y' no es válido, debe estar entre 0 y 3000";
                lite[7] = "Lo siento, como estas conectado a hipoqih no puedes usar el mapa";
                lite[8] = "Programas|*.exe";
                lite[9] = "Seleccionar un programa";
                lite[10] = "Archivos de sonido|*.wav";
                lite[11] = "Seleccionar un archivo de sonido";
                this.label6.Text = "Latitud inicial:";
                this.label7.Text = "Longitud inicial:";
                this.btCancel.Text = "Cancelar";
                this.btOk.Text = "Aceptar";
                this.label11.Text = "Velocidad:";
                this.label12.Text = "Puerto:";
                this.cbGPS.Items.AddRange(new object[] {
                    "Manual (se lee de la configuración)",
                    "Fichero de texto (c:\\ubicate)",
                    "GPS compatible NMEA ",
                    "Triangulación Señal Wi-fi  (PENDIENTE) ",
                    "Triangulación Señal GSM  (PENDIENTE) ",
                    "IP de acceso a Internet  (PENDIENTE) ",
                    "Galileo  (PENDIENTE) "});
                this.label13.Text = "Sistema de localización:";
                this.groupBox1.Text = "Ventana de avisos";
                this.label10.Text = "Posicion Y";
                this.label9.Text = "Posicion X";
                this.label5.Text = "Alto";
                this.label4.Text = "Ancho";
                this.chAviso.Text = "Preguntar antes de abrir los avisos";
                this.groupBox2.Text = "Configuración del dispositivo";
                this.label1.Text = "Tiempo de latencia cuando estas parado (seg.):";
                this.label2.Text = "Tiempo de latencia cuando estas en movimiento (seg.):";
                this.chMapa.Text = "Abrir los avisos en el mapa";
                this.btPosi.Text = "Buscar posicion";
                this.groupBox3.Text = "Posición incial";
                this.btExplorer.Text = "Buscar";
                this.label3.Text = "Programa:";
                this.groupBox4.Text = "Navegador de Internet";
                this.chNavega.Text = "Utilizar un navegador externo";
                this.tabCompor.Text = " Configuración ";
                this.chMapaURL.Text = "Usar mapa si no hay URL";
                this.btRegistro.Text = "Registrarse";
                this.label15.Text = "Clave:";
                this.label14.Text = "Login en hipoqih:";
                this.tabConfig.Text = " Avanzado ";
                this.groupBox5.Text = "Sonidos";
                this.chSonido.Text = "Activar sonido al recibir un aviso";
                this.btSonido.Text = "Buscar";
                this.label8.Text = "Sonido:";
                this.label16.Text = "Idioma:";
                this.Text = "Configuración del plugin de hipoqih para XP";
            }
            else
            {
                lite[0] = "The interval in movement cannot be of less than 3 seconds";
                lite[1] = "Data Verify";
                lite[2] = "The stopped interval cannot be of less than 30 seconds";
                lite[3] = "The value of “HEIGHT” is not valid, must be between 200 and 3000";
                lite[4] = "The value of “WIDTH” is not valid, must be between 200 and 3000";
                lite[5] = "The value of “POSITION X” is not valid, must be between 0 and 3000";
                lite[6] = "The value of “POSITION Y” is not valid, must be between 0 and 3000";
                lite[7] = "Sorry, to use the map you must be connected to hipoqih";
                lite[8] = "Programs|*.exe";
                lite[9] = "Select program";
                lite[10] = "Sound files|*.wav";
                lite[11] = "Select sound file";
                this.label6.Text = "Setup Latitude:";
                this.label7.Text = "Setup Longitude:";
                this.btCancel.Text = "Cancel";
                this.btOk.Text = "Ok";
                this.label11.Text = "Speed:";
                this.label12.Text = "Port:";
                this.cbGPS.Items.AddRange(new object[] {
                    "Manual (configuration setup)",
                    "Text file (\\ubicate)",
                    "GPS compatible NMEA "});
                this.label13.Text = "Location system:"; 
                this.groupBox1.Text = "Alert Window";
                this.label10.Text = "Position Y";
                this.label9.Text = "Position X";
                this.label5.Text = "Height";
                this.label4.Text = "Width";
                this.chAviso.Text = "Ask before opening the alerts";
                this.groupBox2.Text = "Device configuration";
                this.label1.Text = "Latency time stopped (seg.):";
                this.label2.Text = "Latency time in movement (seg.):";
                this.chMapa.Text = "Open the alerts in the map";
                this.btPosi.Text = "Search position";
                this.groupBox3.Text = "Setup Position";
                this.btExplorer.Text = "Search";
                this.label3.Text = "Program:";
                this.groupBox4.Text = "Internet Navigator";
                this.chNavega.Text = "Use external program";
                this.tabCompor.Text = " Configuration ";
                this.chMapaURL.Text = "Use map when there is no URL";
                this.btRegistro.Text = "To register";
                this.label15.Text = "Password:";
                this.label14.Text = "hipoqih Login:";
                this.tabConfig.Text = " Advanced ";
                this.groupBox5.Text = "Sounds";
                this.chSonido.Text = "Activate sound when receiving alert";
                this.btSonido.Text = "Search";
                this.label8.Text = "Sound:";
                this.label16.Text = "Language:";
                this.Text = "hipoqih plugin for XP Configuration";
            }

            // combo de comms
            short i;
            cbPort.Items.Add("NONE");
            for (i = 1; i <= 16; i++)
            {
                cbPort.Items.Add("COM" + i);
            }
            cbPort.SelectedIndex = 0;

            // combo de baudios
            cbBaudRate.Items.Add("NONE");
            cbBaudRate.Items.Add("4800");
            cbBaudRate.Items.Add("9600");
            cbBaudRate.Items.Add("19200");
            cbBaudRate.Items.Add("14400");
            cbBaudRate.Items.Add("38400");
            cbBaudRate.Items.Add("57600");
            cbBaudRate.SelectedIndex = 0;

            //pintar la configuracion
            txAlto.Text = Config.avisoheight.ToString();
            txAncho.Text = Config.avisowidth.ToString();
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            txLat.Text = Config.latitud.ToString("####.###########", nfi);
            txLon.Text = Config.longitud.ToString("####.###########", nfi);
            txLogin.Text = Config.usuario;
            txPass.Text = Config.clave;
            txTac.Text = Config.minutos.ToString();
            txTic.Text = Config.segundos.ToString();
            txX.Text = Config.avisoleft.ToString();
            txY.Text = Config.avisotop.ToString();
            cbBaudRate.Text = Config.speed;
            switch (Config.gps)
            {
                case "NONE": // no hay GPS, se manda LON y LAT
                    cbPort.Enabled = false;
                    cbBaudRate.Enabled = false;
                    cbGPS.Text = cbGPS.Items[0].ToString();
                    break;
                case "FILE": // no hay GPS, Hay que leer de un fichero
                    cbPort.Enabled = false;
                    cbBaudRate.Enabled = false;
                    cbGPS.Text = cbGPS.Items[1].ToString();
                    break;
                case "GPS":  // GPS "en general" (pendiente)
                    cbGPS.Text = cbGPS.Items[2].ToString();
                    cbPort.Enabled = true;
                    cbBaudRate.Enabled = true;
                    break;
            }
            switch (Config.idioma)
            {
                case "ES":
                    cbIdioma.Text = "Castellano";
                    break;
                case "EN":
                    cbIdioma.Text = "English";
                    break;
            }
            cbPort.Text = Config.port;
            if (Config.avisoauto) chAviso.Checked = false; else chAviso.Checked = true;
            if (Config.avisomapa) chMapa.Checked = true; else chMapa.Checked = false;
            if (Config.avisomapaurl) chMapaURL.Checked = true; else chMapaURL.Checked = false;
            if (Config.explorador == "hipoqih")
            {
                chNavega.Checked = false;
                txExplorer.Text = "";
                txExplorer.Enabled = false;
                btExplorer.Enabled = false;
            }
            else
            {
                chNavega.Checked = true;
                txExplorer.Text = Config.explorador;
                txExplorer.Enabled = true;
                btExplorer.Enabled = true;
            }

            if (Config.sonido == "NONE")
            {
                chSonido.Checked = false;
                txSonido.Text = "";
                txSonido.Enabled = false;
                btSonido.Enabled = false;
            }
            else
            {
                chSonido.Checked = true;
                txSonido.Text = Config.sonido;
                txSonido.Enabled = true;
                btSonido.Enabled = true;
            }
        }

        private void preferencias_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //vuelve a activar el timer ...
            plugin_hipoqih.Program.frmMain.timer.Start();
            this.Dispose();
        }

        private bool VerificaDatos()
        { 
            int segundos = 0;
            int minutos = 0;
            int avisoheight = 0;
            int avisowidth = 0;
            int avisoleft = 0;
            int avisotop = 0;
            try
            {
                segundos = int.Parse(txTic.Text);
                minutos = int.Parse(txTac.Text);
                avisoheight = int.Parse(txAlto.Text);
                avisowidth = int.Parse(txAncho.Text);
                avisoleft = int.Parse(txX.Text);
                avisotop = int.Parse(txY.Text);
            }
            catch
            {
            }
            if (segundos < 3)
            {
                MessageBox.Show(lite[0], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (minutos < 30)
            {
                MessageBox.Show(lite[2], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (avisoheight < 200 | avisoheight > 3000)
            {
                MessageBox.Show(lite[3], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (avisowidth < 200 | avisowidth > 3000)
            {
                MessageBox.Show(lite[4], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (avisoleft < 0 | avisoleft > 3000)
            {
                MessageBox.Show(lite[5], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (avisotop < 0 | avisotop > 3000)
            {
                MessageBox.Show(lite[0], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void bOk_Click(object sender, EventArgs e)
        {
            if (VerificaDatos())
            {
                // grabar configuracion
                Config.avisoheight = 0;
                try
                {
                    Config.avisoheight = int.Parse(txAlto.Text);
                }
                catch{}

                Config.avisowidth = 0;
                try
                {
                    Config.avisowidth = int.Parse(txAncho.Text);
                }
                catch { }

                System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                Config.latitud = 0;
                try
                {
                    Config.latitud = double.Parse(txLat.Text, nfi);
                }
                catch { }

                Config.usuario = txLogin.Text;

                Config.longitud = 0;
                try
                {
                    Config.longitud = double.Parse(txLon.Text, nfi);
                }
                catch { }

                Config.clave = txPass.Text;
                Config.sonido = txSonido.Text;
                Config.minutos = 0;
                try
                {
                    Config.minutos = int.Parse(txTac.Text);
                }
                catch { }
                Config.segundos = 0;
                try
                {
                    Config.segundos = int.Parse(txTic.Text);
                }
                catch { }
                Config.avisoleft = 0;
                try
                {
                    Config.avisoleft = int.Parse(txX.Text);
                }
                catch { }
                Config.avisotop = 0;
                try
                {
                    Config.avisotop = int.Parse(txY.Text);
                }
                catch { }
                
                if (chAviso.Checked)
                {
                    Config.avisoauto = false;
                }
                else
                {
                    Config.avisoauto = true;
                }
                if (chMapa.Checked)
                {
                    Config.avisomapa = true;
                }
                else
                {
                    Config.avisomapa = false;
                }
                if (chMapaURL.Checked)
                {
                    Config.avisomapaurl = true;
                }
                else
                {
                    Config.avisomapaurl = false;
                }
                if (!chNavega.Checked)
                {
                    Config.explorador = "hipoqih";
                }
                else
                {
                    Config.explorador = txExplorer.Text;
                }
                if (!chSonido.Checked)
                {
                    Config.sonido = "NONE";
                }
                else
                {
                    Config.sonido = txSonido.Text;
                }
                Config.port = cbPort.Text;
                Config.speed = cbBaudRate.Text;

                switch (cbGPS.SelectedIndex)
                {
                    case 0:
                        Config.gps = "NONE"; // no hay GPS, se manda LON y LAT
                        break;
                    case 1:
                        Config.gps = "FILE"; // no hay GPS, Hay que leer de un fichero
                        break;
                    case 2:
                        Config.gps = "GPS";  // GPS "en general" (pendiente)
                        break;
                }
                switch (cbIdioma.Text)
                {
                    case "Castellano":
                        Config.idioma = "ES";
                        break;
                    case "English":
                        Config.idioma = "EN";
                        break;
                }
                Config.Grabar();
                plugin_hipoqih.Program.frmMain.carga_parametros();
                this.Close();
            }
        }

        private void btPosi_Click(object sender, EventArgs e)
        {
            if (idseguro == "NONE")
            {
                MessageBox.Show(lite[7], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (frmBuscaposi == null || frmBuscaposi.IsDisposed)
                {
                    frmBuscaposi = new busca_posi();
                    frmBuscaposi.CogerID(idseguro);
                    frmBuscaposi.latitud = txLat.Text;
                    frmBuscaposi.longitud = txLon.Text;
                    frmBuscaposi.Show(this);
                }
                else
                {
                    frmBuscaposi.BringToFront();
                }
            }
        }

        private void btRegistro_Click(object sender, EventArgs e)
        {
            if (Config.idioma == "ES")
            {
                Abrir_URL("http://hipoqih.com/registro_pc_es.htm", "Registro en hipoqih");
            }
            else
            {
                Abrir_URL("http://hipoqih.com/registro_pc_en.htm", "hipoqih Register");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CogerID(string id) 
        {
            idseguro = id;
        }

        private void chSonido_CheckedChanged(object sender, EventArgs e)
        {
            if (!chSonido.Checked)
            {
                Config.sonido = "NONE";
                txSonido.Text = "";
                txSonido.Enabled = false;
                btSonido.Enabled = false;
            }
            else
            {
                txSonido.Enabled = true;
                btSonido.Enabled = true;
            }
        }

        private void chNavega_CheckedChanged(object sender, EventArgs e)
        {
            if (!chNavega.Checked)
            {
                txExplorer.Text = "";
                txExplorer.Enabled = false;
                btExplorer.Enabled = false;
            }
            else
            {
                txExplorer.Enabled = true;
                btExplorer.Enabled = true;
            }
        }

        private void btExplorer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lite[8];
            openFileDialog1.Title = lite[9];

            // Mostrar el cuadro de diálogo.
            // Si el usuario hace clic en Aceptar del cuadro de diálogo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    txExplorer.Text = openFileDialog1.FileName;
                }
            }
        }

        private void btSonido_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lite[10];
            openFileDialog1.Title = lite[11];

            // Mostrar el cuadro de diálogo.
            // Si el usuario hace clic en Aceptar del cuadro de diálogo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    txSonido.Text = openFileDialog1.FileName;
                }
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

        private void cbGPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGPS.SelectedIndex == 2)
            {
                cbPort.Enabled = true;
                cbBaudRate.Enabled = true;
            }
            else
            {
                cbPort.Enabled = false;
                cbBaudRate.Enabled = false;
            }
        }
    }
}