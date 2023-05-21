using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EanrrangoS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistros : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiantes;

        public ConsultaRegistros()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            ObtenerEstudiantes();
        }

        public async void ObtenerEstudiantes(){
            var ResulEstudiabntes = await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiantes = new ObservableCollection<Estudiante>(ResulEstudiabntes);
            ListaEstudiantes.ItemsSource = tablaEstudiantes;

        }


        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;

            var ItemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId); // ID
            string nombre = objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string contrasena = objetoEstudiante.Contrasena.ToString();

            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasena));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());

        }
    }
}