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
    public partial class Mapas : Form
    {
        public string st_lat;
        public string st_lon;
        public string st_text;
        private int zoom = 2000;
        private double lat;
        private double lon;

        public Mapas()
        {
            InitializeComponent();
        }

        private void Mapas_Load(object sender, EventArgs e)
        {
            // idioma
            if (Config.idioma == "ES")
            {
                this.menuSalir.Text = "Salir";
                this.menuZoom.Text = "Zoom";
                this.menuAlejar.Text = "Alejar";
                this.menuAcercar.Text = "Acercar";
                this.Name = "Mapas";
            }
            else
            {
                this.menuSalir.Text = "Quit";
                this.menuZoom.Text = "Zoom";
                this.menuAlejar.Text = "Far";
                this.menuAcercar.Text = "Approach";
                this.Name = "Mapas";
            }
            zoom = 2000;
            label1.Text = st_text;
        }

        public void cargaURL()
        {
            string url="http://maps.google.com/mapdata?Point=b&Point.latitude_e6=";
            string tm_lat;
            string tm_lon; 
            string tm_zoom; 
            string tm_w; 
            string tm_h;
            double xxLat;
            double xxLon;

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            lon = double.Parse(st_lon, nfi);
            lat = double.Parse(st_lat, nfi);

            xxLat = lat * 1e6;
            if (xxLat < 0)
            {
                xxLat = xxLat + (2 ^ 32);
            }
            xxLat = Math.Floor(xxLat);

            xxLon = lon * 1e6;
            if (xxLon < 0)
            {
                xxLon = xxLon + (2 ^ 32);
            }
            xxLon = Math.Floor(xxLon);

            //System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            tm_lat = xxLat.ToString(nfi);
            tm_lon = xxLon.ToString(nfi);

            tm_zoom = zoom.ToString();
            tm_w = webBrowser1.Width.ToString();
            tm_h = webBrowser1.Height.ToString();

            url=url+tm_lat+"&Point.longitude_e6="+tm_lon+"&Point.iconid=15&Point=e&latitude_e6=";
            url=url+tm_lat+"&longitude_e6="+tm_lon+"&zm="+tm_zoom;
            url = url + "&w=" + tm_w + "&h=" + tm_h + "&cc=ES&min_priority=2";
            try
            {
                System.Uri tmp = new System.Uri(url);
                webBrowser1.Navigate(tmp);
            }
            catch { }
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuAlejar_Click(object sender, EventArgs e)
        {
            switch (zoom)
            {
                case 1000:
                    zoom = 2000;
                    menuAlejar.Enabled = true;
                    menuAcercar.Enabled = true;
                    break;
                case 2000:
                    zoom = 3000;
                    menuAlejar.Enabled = true;
                    menuAcercar.Enabled = true;
                    break;
                case 3000:
                    zoom = 10000;
                    menuAlejar.Enabled = true;
                    menuAcercar.Enabled = true;
                    break;
                case 10000:
                    zoom = 30000;
                    menuAlejar.Enabled = true;
                    menuAcercar.Enabled = true;
                    break;
                case 30000:
                    zoom = 100000;
                    menuAlejar.Enabled = false;
                    menuAcercar.Enabled = true;
                    break;
            }
            cargaURL();
        }

        private void menuAcercar_Click(object sender, EventArgs e)
        {
            switch (zoom)
            {
                case 2000:
                    zoom = 1000;
                    menuAcercar.Enabled = false;
                    menuAlejar.Enabled = true;
                    break;
                case 3000:
                    zoom = 2000;
                    menuAcercar.Enabled = true;
                    menuAlejar.Enabled = true;
                    break;
                case 10000:
                    zoom = 3000;
                    menuAcercar.Enabled = true;
                    menuAlejar.Enabled = true;
                    break;
                case 30000:
                    zoom = 10000;
                    menuAcercar.Enabled = true;
                    menuAlejar.Enabled = true;
                    break;
                case 100000:
                    zoom = 30000;
                    menuAcercar.Enabled = true;
                    menuAlejar.Enabled = true;
                    break;
            }
            cargaURL();
        }

    }
}