using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EanrrangoS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {

        public int idSeleccionado; // variable global
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;




        public Elemento(int id , string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtID.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasena.Text = contrasena;
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }

        public IEnumerable<Estudiante>Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from Estudiante where id = ?", id);
        }

        public IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string usuario, string nombre, string contrasena, int id)
        {
            return db.Query<Estudiante>("update Estudiante set Nombre = ?, Usuario = ?, Contrasena = ? where  id = ?", nombre, usuario, contrasena, id);
        }


        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db,txtNombre.Text, txtUsuario.Text,txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());

            }
            catch (Exception ex )
            {

                DisplayAlert("ALERTA", ex.Message,"Cerrar");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());

            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }

        }
    }
}