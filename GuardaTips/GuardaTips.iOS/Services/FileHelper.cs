using Foundation;
using GuardaTips.iOS.Services;
using GuardaTips.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace GuardaTips.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            //obtenemos la ruta del directorio personal del dispositivo
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //obtenemos la ruta donde se aloja la base de datos
            string libFolder = Path.Combine(docFolder, "..", "Databases");

            //si la ruta no existe, la creamos
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}