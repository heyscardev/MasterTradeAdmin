using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MasterTrade.Vista.Herramientas
{
    public class Imagenes
    {
        public string pathAbsolute { get; private set; }
        public BitmapImage imagenBitmap { get; private set; }
        public bool openDialog()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files|*.jpg;*.jpeg;*.png;";
            file.Title = "Seleccion de Imagen";

            if (file.ShowDialog() == true)
            {
                this.imagenBitmap = new BitmapImage(new Uri(file.FileName, UriKind.Absolute));
                this.pathAbsolute = file.FileName;
                return true;
            }
            return false;
        }
        public bool setImagePath(string path)
        {
            if (path == null || !File.Exists(path)) return false;
            this.imagenBitmap = new BitmapImage(new Uri(path, UriKind.Absolute));
            this.pathAbsolute = path;
            return true;
        }
    }

}
