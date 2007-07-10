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
using System.IO;
using System.Net;

namespace plugin
{
    public partial class amigos : Form
    {
        // el id seguri
        public string idseguro;
        private string[] amigo = new string[50];
        private string[] lat = new string[50];
        private string[] lon = new string[50];
        private string[] id = new string[50];
        private int cuantos = 0;

        public amigos()
        {
            InitializeComponent();
        }

        public void comunica()
        {
            //el texto de la web
            string txUrl = "http://www.hipoqih.com/leeramigos.php?clave=" + idseguro;
            string Texto_Web = "";
            WebRequest req = null;
            WebResponse resul = null;

            try
            {
                req = WebRequest.Create(txUrl);
                resul = req.GetResponse();
                System.IO.Stream recibir = resul.GetResponseStream();
                Encoding encode = Encoding.GetEncoding("utf-8");
                System.IO.StreamReader sr = new System.IO.StreamReader(recibir, encode);
                // la web funciona
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
            }
            catch (Exception e)
            {
            }

            //ahora interpreta la cadena
            // que viene asi:
            // echo'$$$0$$$' si no hay nadie
            // echo '$$$'.$login.'$$$'.$lat.'$$$'.$lon
            string st_Texto = "";
            int i_a;
            int i_b;
            int i_c;
            int i_d;

            //coge el contenido devuelto por hipoqih y lo parsea
            if (Texto_Web != null)
            {
                st_Texto = Texto_Web;
                i_a = st_Texto.IndexOf("$$$");
                if (i_a == 0)
                {
                    if (st_Texto.Substring(0, 7) == "$$$0$$$")
                    {
                        // no hay nadie
                    }
                    else
                    {
                        try
                        {
                            string st_w;
                            int ind = 0;
                            st_w = st_Texto;
                            while (st_w.Length>3) 
                            {
                                i_a = st_w.IndexOf("$$$", 3);
                                amigo[ind] = st_w.Substring(3, i_a - 3);
                                i_b = st_w.IndexOf("$$$", i_a + 3);
                                lat[ind] = st_w.Substring(i_a + 3, i_b - i_a - 3);
                                i_c = st_w.IndexOf("$$$", i_b + 3);
                                lon[ind] = st_w.Substring(i_b + 3, i_c - i_b - 3);
                                i_d = st_w.IndexOf("$$$", i_c + 3);
                                id[ind] = st_w.Substring(i_c + 3, i_d - i_c - 3);
                                st_w = st_w.Substring(i_d, st_w.Length - i_d);
                                ind++;
                                cuantos = ind;
                            }
                        }
                        catch
                        { }
                    }
                }
                // pinta la lista
                string lista;
                for (int n = 0; n < cuantos; n++ )
                {
                    if (lat[n] == "0.0" & lon[n] == "0.0")
                    {
                        if (Config.idioma == "ES")
                            lista = amigo[n] + "   (sin posición)";
                        else
                            lista = amigo[n] + "   (no position)";
                    }
                    else
                    {
                        lista = amigo[n];
                    }
                    listBox1.Items.Add(lista);
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comunica();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre;
            int ind;
            if (listBox1.SelectedIndex == -1)
            {
                if (Config.idioma == "ES")
                    MessageBox.Show("No tienes a ningún amigo seleccionado.", "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("You can selected friend for show map.", "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                ind = listBox1.SelectedIndex;
                if (lat[ind] == "0.0" & lon[ind] == "0.0")
                {
                    if (Config.idioma == "ES")
                        MessageBox.Show("Este amigo no tiene posición ahora mismo.", "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("This friend has not position now.", "hipoqih plugin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    nombre = listBox1.SelectedItem.ToString();
                    if (Config.idioma == "ES")
                        Abrir_Mapa(lat[ind],lon[ind], "Donde está " + nombre);
                    else
                        Abrir_Mapa(lat[ind],lon[ind], "Where is " + nombre);
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

        private void amigos_Load(object sender, EventArgs e)
        {
            if (Config.idioma == "ES")
            {
                this.Text="¿Donde están mis amigos?";
                label1.Text = "Esta es la lista de todos los usuarios de hipoqih con los que compartes avisos posicionales.";
                btRefresh.Text="Refrescar";
                button1.Text="Ver mapa";
                menuItem1.Text = "Salir";
            }
            else
            {
                this.Text="Where are my friends?";
                label1.Text="This is the list of all the users of hipoqih with whom you share positional alerts.";
                btRefresh.Text="Refresh";
                button1.Text="Show map";
                menuItem1.Text = "Quit";
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}