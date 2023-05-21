using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EanrrangoS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]

        public string Nombre { get; set; }

        [MaxLength(50)]

        public string Usuario { get; set; }

        [MaxLength(50)]

        public string Contrasena { get; set; }

    }
}
