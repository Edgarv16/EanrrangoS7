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
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();

        }public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Select * from Estudiante Where usuario =?", usuario, contrasena);
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);
            
                if (resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    DisplayAlert("ALERTA", "usuario/Contrasena Incorecto", "cerrar");
                }
            
            
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }

        /*private void btnInicio_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(ruta);
            }
            catch (Exception e)
            {

                
            }
        
        }*/

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}