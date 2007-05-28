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