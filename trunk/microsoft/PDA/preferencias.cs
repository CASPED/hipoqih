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

namespace plugin
{
    public partial class preferencias : Form
    {
        // literales
        private string[] lite = new string[5];

        //el ID SEGURO
        private string idseguro = "NONE";

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
                lite[3] = "Archivos de sonido|*.wav";
                lite[4] = "Programas|*.exe";
                this.btCancel.Text = "Cancelar";
                this.btOk.Text = "Grabar";
                this.label15.Text = "Clave:";
                this.label14.Text = "Login en hipoqih:";
                this.chMapa.Text = "Abrir los avisos en el mapa";
                this.chAviso.Text = "Preguntar antes de abrir los avisos";
                this.label16.Text = "Idioma:";
                this.tabPage1.Text = "Configuración";
                this.chMapaURL.Text = "Usar mapa si no hay URL";
                this.tabPage2.Text = "Posicion";
                this.label9.Text = "Latitud inicial:";
                this.label10.Text = "Longitud inicial:";
                this.cbGPS.Items.Add("Manual (se lee de la configuración)");
                this.cbGPS.Items.Add("Fichero de texto (\\ubicate)");
                this.cbGPS.Items.Add("GPS");
                this.cbGPS.Items.Add("Triangulación Señal Wi-fi  (PENDIENTE) ");
                this.cbGPS.Items.Add("Triangulación Señal GSM  (PENDIENTE) ");
                this.cbGPS.Items.Add("IP de acceso a Internet  (PENDIENTE) ");
                this.cbGPS.Items.Add("Galileo  (PENDIENTE) ");
                this.label13.Text = "Sistema de localización";
                this.label1.Text = "Latencia parado (seg.)";
                this.label2.Text = "Latencia movimiento (seg.)";
                this.tabPage3.Text = "Avanzado";
                this.chNavega.Text = "Navegador de internet externo";
                this.btExplorer.Text = "Buscar";
                this.btSonido.Text = "Buscar";
                this.chSonido.Text = "Activar sonido al recibir un aviso";
                this.label8.Text = "Sonido del aviso";
                this.label3.Text = "Programa navegador";
                this.Text = "Configuración del plugin";
            }
            else
            {
                lite[0] = "The interval in movement cannot be of less than 3 seconds";
                lite[1] = "Data Verify";
                lite[2] = "The stopped interval cannot be of less than 30 seconds";
                lite[3] = "Sound files|*.wav";
                lite[4] = "Programs|*.exe";
                this.btCancel.Text = "Cancel";
                this.btOk.Text = "Write";
                this.label15.Text = "Password:";
                this.label14.Text = "hipoqih Login:";
                this.chMapa.Text = "Open the alerts in the map";
                this.chAviso.Text = "Ask before opening the alerts";
                this.label16.Text = "Language:";
                this.tabPage1.Text = "Configuration";
                this.chMapaURL.Text = "Use map when there is no URL";
                this.tabPage2.Text = "Position";
                this.label9.Text = "Setup Latitude:";
                this.label10.Text = "Setup Longitude:";
                this.cbGPS.Items.Add("Manual (configuration setup)");
                this.cbGPS.Items.Add("Text file (\\ubicate)");
                this.cbGPS.Items.Add("GPS");
                //this.cbGPS.Items.Add("Triangulación Señal Wi-fi  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Triangulación Señal GSM  (PENDIENTE) ");
                //this.cbGPS.Items.Add("IP de acceso a Internet  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Galileo  (PENDIENTE) ");
                this.label13.Text = "Location system";
                this.label1.Text = "Stopped latency (sec.)";
                this.label2.Text = "Movement latency (sec.)";
                this.tabPage3.Text = "Advanced ";
                this.chNavega.Text = "External Internet Navigator";
                this.btExplorer.Text = "Search";
                this.btSonido.Text = "Search";
                this.chSonido.Text = "Activate sound when receiving alert";
                this.label8.Text = "Alert sound";
                this.label3.Text = "Navigator Program";
                this.Text = "plugin Configuration";
            }

            //pintar la configuracion
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            txLat.Text = Config.latitud.ToString("####.###########", nfi);
            txLon.Text = Config.longitud.ToString("####.###########", nfi);
            txLogin.Text = Config.usuario;
            txPass.Text = Config.clave;
            txSonido.Text = Config.sonido;
            txTac.Text = Config.minutos.ToString();
            txTic.Text = Config.segundos.ToString();
            switch (Config.gps)
            {
                case "NONE": // no hay GPS, se manda LON y LAT
                    cbGPS.Text = cbGPS.Items[0].ToString();
                    break;
                case "FILE": // no hay GPS, Hay que leer de un fichero
                    cbGPS.Text = cbGPS.Items[1].ToString();
                    break;
                case "GPS":  // GPS "en general" (pendiente)
                    cbGPS.Text = cbGPS.Items[2].ToString();
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

        public void CogerID(string id)
        {
            idseguro = id;
        }

        private void chSonido_CheckStateChanged(object sender, EventArgs e)
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

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool VerificaDatos()
        {
            int segundos = 0;
            int minutos = 0;
            bool sw = true;
            try
            {
                minutos = int.Parse(txTac.Text);
                segundos = int.Parse(txTic.Text);
            }
            catch
            {
            }
            if (segundos < 3)
            {
                MessageBox.Show(lite[0], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                sw = false;
            }
            if (minutos < 30)
            {
                MessageBox.Show(lite[2], lite[1], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                sw = false;
            }
            return sw;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (VerificaDatos())
            {
                // grabar configuracion
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
                this.Close();
            }
        }
        private void btSonido_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lite[3];
            //openFileDialog1.Title = "Seleccionar un archivo de sonido";

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

        private void btExplorer_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lite[4];
            // openFileDialog1.Title = "Seleccionar un programa"; --> PDA

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

        private void chNavega_CheckStateChanged(object sender, EventArgs e)
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
    }
}