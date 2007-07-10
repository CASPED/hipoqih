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
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace plugin_hipoqih
{
    public static class Config
    {
        // configuracion del sistema
        public static double latitud;
        public static double longitud;
        public static int segundos;
        public static int minutos;
        public static string gps;
        public static bool avisoauto;
        public static bool avisomapa;
        public static bool avisomapaurl;
        public static string port;
        public static string speed;
        public static int avisowidth;
        public static int avisoheight;
        public static int avisotop;
        public static int avisoleft;
        public static string usuario;
        public static string clave;
        public static string idioma;
        public static string sonido;
        public static string explorador;

        public static int Grabar()
        {
            // grabar configuracion
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(Application.StartupPath + "\\config.xml", settings))
            {
                // Write XML data.
                writer.WriteStartElement("config");
                System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                if (latitud == 0)
                {
                    writer.WriteElementString("lat", "0");
                }
                else
                {
                    writer.WriteElementString("lat", latitud.ToString("###.###########", nfi));
                }
                if (longitud == 0)
                {
                    writer.WriteElementString("lon", "0");
                }
                else
                {
                    writer.WriteElementString("lon", longitud.ToString("###.###########", nfi));
                }
                writer.WriteElementString("tick", segundos.ToString());
                writer.WriteElementString("tack", minutos.ToString());
                writer.WriteElementString("gps", gps);
                writer.WriteElementString("auto", avisoauto.ToString());
                writer.WriteElementString("map", avisomapa.ToString());
                writer.WriteElementString("mapurl", avisomapaurl.ToString());
                writer.WriteElementString("width", avisowidth.ToString());
                writer.WriteElementString("height", avisoheight.ToString());
                writer.WriteElementString("top", avisotop.ToString());
                writer.WriteElementString("left", avisoleft.ToString());
                writer.WriteElementString("port", port);
                writer.WriteElementString("speed", speed);
                writer.WriteElementString("user", usuario.ToString());
                writer.WriteElementString("pass", clave.ToString());
                writer.WriteElementString("lang", idioma.ToString());
                writer.WriteElementString("song", sonido.ToString());
                writer.WriteElementString("explorer", explorador.ToString());
                writer.Flush();
            }
            return 0;
        }
        public static int Leer()
        {
            //pone los valores por defecto a las variables
            latitud = 0;
            longitud = 0;
            segundos = 5;
            minutos = 50;
            gps = "NONE";
            avisoauto = false;
            avisomapa = false;
            avisomapaurl = true;
            avisoheight = 475;
            avisowidth = 450;
            avisotop = 0;
            avisoleft = 0;
            port = "NONE";
            speed = "NONE";
            usuario = "nombre_usuario";
            clave = "*";
            //averigua el idioma del usuario
            System.Threading.Thread tt = System.Threading.Thread.CurrentThread;
            System.Globalization.CultureInfo actual = tt.CurrentCulture;
            if (actual.Name.Substring(0, 2) == "es")
            {
                idioma = "ES";
            }
            else
            {
                idioma = "EN";
            }
            sonido = "saliente.wav";
            explorador = "hipoqih";
            //primero hay que leer configuracion del XML
             System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            try
            {
                using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(Application.StartupPath + "\\config.xml", settings))
                {
                    // Read XML data.
                    reader.ReadStartElement("config");
                    System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
                    latitud = double.Parse(reader.ReadElementString("lat"), nfi);
                    longitud = double.Parse(reader.ReadElementString("lon"), nfi);
                    segundos = int.Parse(reader.ReadElementString("tick"));
                    minutos = int.Parse(reader.ReadElementString("tack"));
                    gps = reader.ReadElementString("gps");
                    avisoauto = bool.Parse(reader.ReadElementString("auto"));
                    avisomapa = bool.Parse(reader.ReadElementString("map"));
                    avisomapaurl = bool.Parse(reader.ReadElementString("mapurl"));
                    avisowidth = int.Parse(reader.ReadElementString("width"));
                    avisoheight = int.Parse(reader.ReadElementString("height"));
                    avisotop = int.Parse(reader.ReadElementString("top"));
                    avisoleft = int.Parse(reader.ReadElementString("left"));
                    port = reader.ReadElementString("port");
                    speed = reader.ReadElementString("speed");
                    usuario = reader.ReadElementString("user");
                    clave = reader.ReadElementString("pass");
                    idioma = reader.ReadElementString("lang");
                    sonido = reader.ReadElementString("song");
                    explorador = reader.ReadElementString("explorer");
                }
                //ok
                return 0;
            }
            catch
            { 
                //si da algun error intenta crear los datos que faltan
                Grabar();
                //se creo de nuevo...
                return 1;
            }
        }
    }
}
