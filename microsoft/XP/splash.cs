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
