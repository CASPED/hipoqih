using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace plugin_hipoqih
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
            try
            {
                webBrowser.Navigate(st_url);
            }
            catch { }
        }

    }
}