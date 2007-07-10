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
using System.Net;
using System.IO;
using System.Collections;

namespace plugin
{
    public partial class main : Form
    {
        // literales
        private string[] lite = new string[17];
        
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
        private bool sw_pause = false;

        // los formularios
        private Acercade frmAcercade = null;
        private amigos frmAmigos = null;
        private preferencias frmPreferencias = null;

        //para el GPS
        private EventHandler updateDataHandler;
        GpsDeviceState device = null;
        GpsPosition position = null;
        Gps gps = new Gps();

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, System.EventArgs e)
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
                lite[12] = "No hay posición, no se puede enviar.";
                lite[13] = "Pausado";
                lite[14] = "Pausa";
                lite[15] = "Continua";
                lite[16] = "Estas conectado. ¿Quieres mantener la posicion en hipoqih al salir?";
                this.menuItem2.Text = "Refrescar Posicion";
                this.menuItem4.Text = "Configurar";
                this.menuItem6.Text = "Acerca de hipoqih";
                this.menuItem8.Text = "Salir";
                this.menuItem1.Text = "¿Donde están mis amigos?";
                this.bMapa.Text = "Mapa";
                this.label1.Text = "Latitud";
                this.label2.Text = "Longitud";
                this.bStart.Text = "Conecta";
                this.bStop.Text = "Para";
                this.lComStatus.Text = "Parado";
                this.label3.Text = "Ultimo aviso recibido:";
                this.label7.Text = "metros:";
                this.label5.Text = "a";
                this.label4.Text = "de ";
                this.btLimpia.Text = "Limpiar";
                this.bPause.Text = "Pausa";
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
                lite[12] = "No have position for sent.";
                lite[13] = "Paused";
                lite[14] = "Pause";
                lite[15] = "Continue";
                lite[16] = "You are connected. Do you want to keep the position in hipoqih after exit?";
                this.menuItem2.Text = "Refresh Position";
                this.menuItem4.Text = "Configure";
                this.menuItem6.Text = "About of hipoqih";
                this.menuItem8.Text = "Quit";
                this.menuItem1.Text = "Where are my friends?";
                this.bMapa.Text = "Map";
                this.label1.Text = "Latitude";
                this.label2.Text = "Longitude";
                this.bStart.Text = "Connect";
                this.bStop.Text = "Stop";
                this.lComStatus.Text = "Stopped";
                this.label3.Text = "Last alert received:";
                this.label7.Text = "meters:";
                this.label5.Text = "at";
                this.label4.Text = "from ";
                this.btLimpia.Text = "Clean";
                this.bPause.Text = "Pause";
            }

            /// para saber el tamaño de la pantalla
            int ancho = Screen.PrimaryScreen.WorkingArea.Width;
            int alto = Screen.PrimaryScreen.WorkingArea.Height;
            if (alto > 450 | ancho > 450)
            {
                imgOff.Width = 32;
                imgOff.Height = 38;
                imgOn.Width = 32;
                imgOn.Height = 38;
//                txFecha.Visible = true;
//                btLimpia.Visible = true;
            }
            else
            {
                imgOff.Width = 16;
                imgOff.Height = 19;
                imgOn.Width = 16;
                imgOn.Height = 19;
//                txFecha.Visible = false;
//                btLimpia.Visible = false;
            }

            // inicializa el GPS siempre!!!
            updateDataHandler = new EventHandler(UpdateData);
            gps.DeviceStateChanged += new DeviceStateChangedEventHandler(gps_DeviceStateChanged);
            gps.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);

            //pone bien los controles
            timer.Interval = Config.segundos * 1000;
            timer.Enabled = false;
            bStop.Enabled = false;
            bStart.Enabled = true;
            bPause.Enabled = false;
            bMapa.Enabled = false;
            menuItem1.Enabled = false;
            menuItem2.Enabled = false;

            //// se arranca el GPS
            if (Config.gps == "GPS")
            {
                //hacer la conexion con el GPS
                if (!gps.Opened)
                {
                    gps.Open();
                }
            }
        }
        
        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Acabar();
        }

        private void Acabar()
        {
            //cierra el plugin
            DialogResult dlg_c = DialogResult.No;
            //cerrar la comunicacion con el GPS si hace falta
            if (gps.Opened)
            {
                gps.Close();
            }
            //manda la baja al servidor
            if (sw_conect)
            {
                dlg_c = MessageBox.Show(lite[16], lite[7], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dlg_c == DialogResult.No)
                {
                    manda_baja();
                }
            }
            Close();
            Application.Exit();
            this.Dispose();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            lComStatus.Text = lite[0];
            bStart.Enabled = false;
            bStop.Enabled = true;
            bPause.Enabled = true;
            menuItem1.Enabled = true;
            menuItem2.Enabled = true;
            this.Refresh();
            manda_alta();
            timer.Enabled = true;
            sw_start = true;
            EnviaPosicion();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            bStart.Enabled = true;
            bStop.Enabled = false;
            bPause.Enabled = false;
            bMapa.Enabled = false;
            lComStatus.Text = lite[1];
            menuItem1.Enabled = false;
            menuItem2.Enabled = false;
            this.Refresh();

//            if (Config.gps == "GPS")
//            {
//                //cerrar la comunicacion con el GPS si fuese necesario
//                if (gps.Opened)
//                {
//                    gps.Close();
//                }
//            }

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
            if (Config.gps == "GPS")
            {
                //hay que interrogar al GPS y pintar las posiciones
            }
            if (Config.gps == "NONE")
            {
                // pone los numeros en yanqui
                System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                txtLatitude.Text = Config.latitud.ToString("####.###########", nfi);
                txtLongitude.Text = Config.longitud.ToString("####.###########", nfi);
            }

            if (Config.gps == "FILE")
            {
                // lee de un archivo
                StreamReader objReader = new StreamReader("\\ubicate");
                string sLine = "";
                ArrayList arrText = new ArrayList();
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();

                // pone los numeros en yanqui
                System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
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
                WebRequest req = WebRequest.Create(txUrl);
                WebResponse resul = req.GetResponse();
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
                            timer.Enabled = false; //PDA
                            dlg_c = MessageBox.Show(lite[2], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            bStop_Click(bStop, null);
                            return;
                        }
                        else
                        {
                            lComStatus.Text = lite[3];
                            sw_conect = true;
                            bMapa.Enabled = true;
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
                                // muestra el texto del aviso POSICIONAL en el form
                                txAviso.Text = st_login + lite[4] + st_radio + lite[5];
                                txFecha.Text = System.DateTime.Now.ToString();
                                txLogin.Text = "hipoqih";
                                txRadio.Text = "";
                            }
                            else
                            {
                                // muestra el texto del aviso NO POSICIONAL en el form
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
                            this.WindowState = FormWindowState.Normal;
                        }
                        // se va a mostrar.
                        //parche por si acaso
                        if (st_URL.ToUpper() == "HTTP://") st_URL = "";
                        if (st_pos == "S")
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
                        if ((Config.avisoauto & st_pos == "N") | dlg_c == DialogResult.Yes)
                        {
                            //al mostrar el aviso se sube el timer a dos minutos a huevo
                            timer.Interval = 120000;
                            // mostrar la URL en el mapa si esta configurado para que se muestran en mapa, 
                            // si no tiene URL y esta configurado para mapa o si el aviso es posicional
                            if ((Config.avisomapa) | (Config.avisomapaurl & st_URL == "") | (st_pos == "S"))
                            {
                                if (Config.explorador == "hipoqih")
                                {
                                    Abrir_Mapa(st_lat, st_lon, st_TX);
                                }
                                else
                                {
                                    Abrir_URL("http://www.hipoqih.com/mapa_aviso.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), st_TX);
                                }
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
                 MessageBox.Show(lite[12], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
             }
             else
             {
                 if (Config.explorador == "hipoqih")
                 {
                     Abrir_Mapa(txtLatitude.Text, txtLongitude.Text, lite[10]);
                 }
                 else
                 {
                     if (Config.idioma == "ES")
                         Abrir_URL("http://www.hipoqih.com/mapa_mio_es.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), lite[10]);
                     else
                         Abrir_URL("http://www.hipoqih.com/mapa_mio_en.php?iduser=" + idseguro + "&ancho=" + Config.avisowidth.ToString() + "&alto=" + Config.avisoheight.ToString(), lite[10]);
                 }
             }
         }
        
         private void Abrir_URL(string url, string titulo)
         {
             if (Config.explorador == "hipoqih")
             {
                 // el formularo de los avisos
                 // OJO--> siempre es nuevo
                 aviso ffAviso = new aviso();
                 ffAviso.Width = Config.avisowidth;
                 ffAviso.Height = Config.avisoheight;
                 ffAviso.Top = Config.avisotop;
                 ffAviso.Left = Config.avisoleft;
                 ffAviso.Text = titulo;
                 ffAviso.st_url = url;
                 ffAviso.cargaURL();
                 ffAviso.Show();
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

        private void Abrir_Mapa(string lat, string lon, string titulo)
         {
             // el formularo del los mapas
             // OJO--> siempre es nuevo
             Mapas ffMap = new Mapas();
             ffMap.Width = Config.avisowidth;
             ffMap.Height = Config.avisoheight;
             ffMap.Top = Config.avisotop;
             ffMap.Left = Config.avisoleft;
             ffMap.st_text = titulo;
             ffMap.st_lat = lat;
             ffMap.st_lon = lon;
             ffMap.cargaURL();
             ffMap.Show();
         }

        // menu
        private void menuItem8_Click(object sender, EventArgs e)
        {
            Acabar();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            if (frmAcercade == null)
            {
                frmAcercade = new Acercade();
                frmAcercade.Show();
            }
            else
            {
                try
                {
                    frmAcercade.BringToFront();
                }
                catch
                {
                    frmAcercade = new Acercade();
                    frmAcercade.Show();
                }
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            if (frmPreferencias == null)
            {
                frmPreferencias = new preferencias();
                frmPreferencias.CogerID(idseguro);
                frmPreferencias.Show();
            }
            else
            {
                try
                {
                    frmPreferencias.BringToFront();
                }
                catch
                {
                    frmPreferencias = new preferencias();
                    frmPreferencias.CogerID(idseguro);
                    frmPreferencias.Show();
                }
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            // se borran para forzar el envio de las nuevas
            lastlon = 0;
            lastlat = 0;
            //// se arranca el GPS
            if (Config.gps == "GPS")
            {
                if (gps.Opened)
                {
                    gps.Close();
                }
                //hacer la conexion con el GPS
                if (!gps.Opened)
                {
                    gps.Open();
                }
            }
            // si no hay posicion
            if (txtLatitude.Text == "" & txtLongitude.Text == "")
            {
                MessageBox.Show(lite[12], "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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

        private void btLimpia_Click(object sender, EventArgs e)
        {
            txAviso.Text = "";
            txFecha.Text = "";
            txLogin.Text = "";
            txRadio.Text = "";
        }

        // para el sonido
        private enum PlaySoundFlags
        {
            SND_SYNC = 0x0000,  /* play synchronously (default) */
            SND_ASYNC = 0x0001,  /* play asynchronously */
            SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
            SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000, /* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        }
        [System.Runtime.InteropServices.DllImport("CoreDll.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private extern static int WCE_PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

        /// <summary>
        /// Construct the Sound object to play sound data from the specified file.
        /// </summary>
        public void Sonar(string fileName)
        {
            WCE_PlaySound(fileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
        }

        //private void Sonar(string file)
        //{
        //    PlaySound(file, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
        //}

        //
        // RUTINAS DE GPS //
        //
        protected void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            position = args.Position;

            // call the UpdateData method via the updateDataHandler so that we
            // update the UI on the UI thread
            Invoke(updateDataHandler);
        }

        void gps_DeviceStateChanged(object sender, DeviceStateChangedEventArgs args)
        {
            device = args.DeviceState;
            // call the UpdateData method via the updateDataHandler so that we
            // update the UI on the UI thread
            Invoke(updateDataHandler);
        }

        void UpdateData(object sender, System.EventArgs args)
        {
            if (Config.gps == "GPS")
            {
                if (gps.Opened)
                {
                    //string str = "";
                    //if (device != null)
                    //{
                    //    str = device.FriendlyName + " " + device.ServiceState + ", " + device.DeviceState + "\n";
                    //}
                    if (position != null)
                    {
                        System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                        if (position.LatitudeValid)
                        {
                            txtLatitude.Text = position.Latitude.ToString("####.###########", nfi);
                        }
                        //    str += "Latitude (DD):\n   " + position.Latitude + "\n";
                        //    str += "Latitude (D,M,S):\n   " + position.LatitudeInDegreesMinutesSeconds + "\n";
                        if (position.LongitudeValid)
                        {
                            txtLongitude.Text = position.Longitude.ToString("####.###########", nfi);
                        }
                        //    str += "Longitude (DD):\n   " + position.Longitude + "\n";
                        //    str += "Longitude (D,M,S):\n   " + position.LongitudeInDegreesMinutesSeconds + "\n";
                        //if (position.SatellitesInSolutionValid &&
                        //    position.SatellitesInViewValid &&
                        //    position.SatelliteCountValid)
                        //{
                        //    str += "Satellite Count:\n   " + position.GetSatellitesInSolution().Length + "/" +
                        //        position.GetSatellitesInView().Length + " (" +
                        //        position.SatelliteCount + ")\n";
                        //}
                        //if (position.TimeValid)
                        //{
                        //    str += "Time:\n   " + position.Time.ToString() + "\n";
                        //}
                    }
                    //lComStatus.Text = str;
                }
            }
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            if (sw_pause)
            {
                bPause.Text = lite[14];
                lComStatus.Text = lite[3];
                this.Refresh();
                timer.Enabled = true;
                sw_pause = false;
                menuItem2_Click(menuItem2, null);
            }
            else
            {
                bPause.Text = lite[15];
                lComStatus.Text = lite[13];
                this.Refresh();
                timer.Enabled = false;
                sw_pause = true;
                imgOn.Visible = false;
                lastlat = 0;
                lastlon = 0;
                tiempo = 0;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
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
                    frmAmigos.idseguro = idseguro;
                    frmAmigos.comunica();
                    frmAmigos.BringToFront();
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