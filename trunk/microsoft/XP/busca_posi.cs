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
    public partial class busca_posi : Form
    {

        //el ID SEGURO
        private string idseguro = "NONE";
        public string latitud;
        public string longitud;

        public busca_posi()
        {
            InitializeComponent();
        }

        public void CogerID(string id)
        {
            idseguro = id;
        }

        private void busca_posi_Load(object sender, EventArgs e)
        {
            string st_url;
            string st_par;
            if (latitud == "") latitud = "0";
            if (longitud== "") longitud = "0";
            st_par = "?tique=" + idseguro + "&lat=" + latitud + "&lon=" + longitud;
            if (Config.idioma == "ES")
            {
                this.btCancel.Text = "Cancelar";
                this.btOk.Text = "Aceptar";
                this.label2.Text = "Para coger las coordenadas pincha en el mapa y pulsa Aceptar para coger ese punto como tu posición.";
                this.Text = "Buscar tu posicion con los mapas de hipoqih";
                st_url = "http://hipoqih.com/mapaposi_es.htm" + st_par;
            }
            else
            {
                this.btCancel.Text = "Cancel";
                this.btOk.Text = "Ok";
                this.label2.Text = "For get the coordinates of your position click in the map. Press 'Ok' for accept this coordinates";
                this.Text = "Search your position with hipoqih maps";
                st_url = "http://hipoqih.com/mapaposi_en.htm" + st_par;
            }
            webBrowser.Navigate(st_url);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {

            webBrowser.Navigate("http://hipoqih.com");
            this.Refresh();

            string st_Texto = null;
        
            string st_url = "http://hipoqih.com/leerposicion.php?iduser=" + idseguro;
            //guardar los resultado
            System.Net.WebRequest req = System.Net.WebRequest.Create(st_url);
            req.Timeout = 10000;
            System.Net.WebResponse resul = req.GetResponse();
            System.IO.Stream recibir = resul.GetResponseStream();
            Encoding encode = Encoding.GetEncoding("utf-8");
            System.IO.StreamReader sr = new System.IO.StreamReader(recibir, encode);
            // leer el estreamer
            while (sr.Peek() >= 0)
            {
                st_Texto += sr.ReadLine();
            }
            resul.Close();
            //ahora interpreta la cadena
            // que viene asi:
            // echo'latitud','longitud'
            string st_lat = "";
            string st_lon = "";
            int i_a;
            //coge el contenido devuelto por hipoqih y lo parsea
            if (st_Texto != null)
            {
                i_a = st_Texto.IndexOf(",");
                if (i_a > 0)
                {
                    st_lat = st_Texto.Substring(0, i_a);
                    st_lon = st_Texto.Substring(i_a + 1, st_Texto.Length - i_a - 1);
                }
            }
            // lo pinto en referencias
            plugin_hipoqih.hipoqih.frmPreferencias.txLat.Text = st_lat;
            plugin_hipoqih.hipoqih.frmPreferencias.txLon.Text = st_lon;
            this.Close();
        }
    }
}