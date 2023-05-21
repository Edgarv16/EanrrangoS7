using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite; //
using System.IO; // metodos de entrada y salida
using EanrrangoS7.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace EanrrangoS7.Droid
{
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var BaseDtaos = Path.Combine(ruta,"uisrael.db3");
            return new SQLiteAsyncConnection(BaseDtaos);
        }
    }
}