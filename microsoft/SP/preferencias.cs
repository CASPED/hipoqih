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
                this.btCancel.Text = "Opciones";
                this.btOk.Text = "Grabar";
                this.label15.Text = "Clave:";
                this.label14.Text = "Login:";
                this.chMapa.Text = "Abrir avisos en el mapa";
                this.chAviso.Text = "Preguntar antes de abrir";
                this.label16.Text = "Idioma:";
                //this.tabPage1.Text = "Configuración";
                this.chMapaURL.Text = "Usar mapa si no hay URL";
                //this.tabPage2.Text = "Posicion";
                this.label9.Text = "Latitud:";
                this.label10.Text = "Longitud:";
                this.cbGPS.Items.Add("Manual (de la configuración)");
                this.cbGPS.Items.Add("Fichero de texto (\\ubicate)");
                this.cbGPS.Items.Add("GPS");
                //this.cbGPS.Items.Add("Triangulación Señal Wi-fi  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Triangulación Señal GSM  (PENDIENTE) ");
                //this.cbGPS.Items.Add("IP de acceso a Internet  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Galileo  (PENDIENTE) ");
                this.label13.Text = "Sistema de localización";
                this.label1.Text = "Parado";
                this.label2.Text = "Movimiento";
                this.label4.Text = "Tiempos de latencia (seg.):";
                //this.tabPage3.Text = "Avanzado";
                this.chNavega.Text = "Navegador externo";
                //this.btExplorer.Text = "Buscar";
                //this.btSonido.Text = "Buscar";
                this.chSonido.Text = "Activar sonido";
                this.label8.Text = "Sonido del aviso";
                this.label3.Text = "Programa navegador";
                this.Text = "Configuración del plugin";
                this.menuConf1.Text = "Configuración usuario";
                this.menuConf2.Text = "Posición";
                this.menuConf3.Text = "Avanzada";
                this.menuSalir.Text = "Salir";
            }
            else
            {
                lite[0] = "The interval in movement cannot be of less than 3 seconds";
                lite[1] = "Data Verify";
                lite[2] = "The stopped interval cannot be of less than 30 seconds";
                lite[3] = "Sound files|*.wav";
                lite[4] = "Programs|*.exe";
                this.btCancel.Text = "Options";
                this.btOk.Text = "Write";
                this.label15.Text = "Password:";
                this.label14.Text = "Login:";
                this.chMapa.Text = "Open alerts in the map";
                this.chAviso.Text = "Ask before opening";
                this.label16.Text = "Language:";
                //this.tabPage1.Text = "Configuration";
                this.chMapaURL.Text = "Use map when not URL";
                //this.tabPage2.Text = "Position";
                this.label9.Text = "Latitude:";
                this.label10.Text = "Longitude:";
                this.cbGPS.Items.Add("Manual (configuration setup)");
                this.cbGPS.Items.Add("Text file (\\ubicate)");
                this.cbGPS.Items.Add("GPS");
                //this.cbGPS.Items.Add("Triangulación Señal Wi-fi  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Triangulación Señal GSM  (PENDIENTE) ");
                //this.cbGPS.Items.Add("IP de acceso a Internet  (PENDIENTE) ");
                //this.cbGPS.Items.Add("Galileo  (PENDIENTE) ");
                this.label13.Text = "Location system";
                this.label1.Text = "Stopped";
                this.label2.Text = "Movement";
                this.label4.Text = "Latency time (sec.):";
                //this.tabPage3.Text = "Advanced ";
                this.chNavega.Text = "External Navigator";
                //this.btExplorer.Text = "Search";
                //this.btSonido.Text = "Search";
                this.chSonido.Text = "Activate sound";
                this.label8.Text = "Alert sound";
                this.label3.Text = "Navigator Program";
                this.Text = "plugin Configuration";
                this.menuConf1.Text = "User Configuration";
                this.menuConf2.Text = "Position";
                this.menuConf3.Text = "Advanced";
                this.menuSalir.Text = "Quit";
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
                //btExplorer.Enabled = false;
            }
            else
            {
                chNavega.Checked = true;
                txExplorer.Text = Config.explorador;
                txExplorer.Enabled = true;
                //btExplorer.Enabled = true;
            }
            if (Config.sonido == "NONE")
            {
                chSonido.Checked = false;
                txSonido.Text = "";
                txSonido.Enabled = false;
                //btSonido.Enabled = false;
            }
            else
            {
                chSonido.Checked = true;
                txSonido.Text = Config.sonido;
                txSonido.Enabled = true;
                //btSonido.Enabled = true;
            }
            // pinta el primer panel
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
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
                //btSonido.Enabled = false;
            }
            else
            {
                txSonido.Enabled = true;
                //btSonido.Enabled = true;
            }
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
                //btExplorer.Enabled = false;
            }
            else
            {
                txExplorer.Enabled = true;
                //btExplorer.Enabled = true;
            }

        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuConf1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void menuConf2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void menuConf3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void txPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}