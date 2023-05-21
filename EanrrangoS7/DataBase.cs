using System;
using System.Collections.Generic;
using System.Text;
using SQLite; /// para utilizar los metodos de la bases de datos
namespace EanrrangoS7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();// Definir el metodo de la conexion

    }
}
