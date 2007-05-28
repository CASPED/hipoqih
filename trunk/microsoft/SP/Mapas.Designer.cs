namespace plugin
{
    partial class Mapas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuSalir = new System.Windows.Forms.MenuItem();
            this.menuZoom = new System.Windows.Forms.MenuItem();
            this.menuAcercar = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuAlejar = new System.Windows.Forms.MenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuSalir);
            this.mainMenu1.MenuItems.Add(this.menuZoom);
            // 
            // menuSalir
            // 
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // menuZoom
            // 
            this.menuZoom.MenuItems.Add(this.menuAcercar);
            this.menuZoom.MenuItems.Add(this.menuItem2);
            this.menuZoom.MenuItems.Add(this.menuAlejar);
            this.menuZoom.Text = "Zoom";
            // 
            // menuAcercar
            // 
            this.menuAcercar.Text = "Acercar";
            this.menuAcercar.Click += new System.EventHandler(this.menuAcercar_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // menuAlejar
            // 
            this.menuAlejar.Text = "Alejar";
            this.menuAlejar.Click += new System.EventHandler(this.menuAlejar_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 29);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(176, 151);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 26);
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Mapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Menu = this.mainMenu1;
            this.Name = "Mapas";
            this.Text = "hipoqih";
            this.Load += new System.EventHandler(this.Mapas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuItem menuSalir;
        private System.Windows.Forms.MenuItem menuZoom;
        private System.Windows.Forms.MenuItem menuAcercar;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuAlejar;
        private System.Windows.Forms.Label label1;

    }
}