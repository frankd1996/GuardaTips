using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GuardaTips.Droid.Services;
using GuardaTips.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace GuardaTips.Droid.Services
{
    public class FileHelper:IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            //Obtenemos la ruta a la carpeta especial del sistema en el dispositivo
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}