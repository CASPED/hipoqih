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
    public partial class aviso : Form
    {
        public string st_url;
 
        public aviso()
        {
            InitializeComponent();
        }

        private void aviso_Load(object sender, EventArgs e)
        {
            // idioma
            if (Config.idioma == "ES")
            {
                this.menuSalir.Text = "Salir";
                this.menuRecarga.Text = "Recargar";
                this.Name = "aviso";
            }
            else
            {
                this.menuSalir.Text = "Quit";
                this.menuRecarga.Text = "Reload";
                this.Name = "alert";
            }
        }

        public void cargaURL()
        {
            try
            {
                System.Uri tmp = new System.Uri(st_url);
                webBrowser1.Navigate(tmp);
            }
            catch { }
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuRecarga_Click(object sender, EventArgs e)
        {
            cargaURL();
        }
    }
}