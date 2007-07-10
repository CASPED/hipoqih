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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace plugin_hipoqih
{
    partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            Config.Leer();
            if (Config.idioma == "ES")
            {
                this.label2.Text = "espera un momento por favor ...";
                this.label1.Text = "Estoy cargando los componentes";
                this.label3.Text = "necesarios para iniciar el plugin,";
                this.Text = "plugin de hipoqih para Windows XP";
            }
            else
            {
                this.label2.Text = "wait a moment please ...";
                this.label1.Text = "Loading components required";
                this.label3.Text = "for init the hipoqih plugin,";
                this.Text = "hipoqih plugin for Windows XP";
            }
            this.Refresh();
        }
    }
}
