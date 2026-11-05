using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CrudEmpleados.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Puesto { get; set; } = string.Empty;

        public decimal Salario { get; set; } = 0;

        public string Correo { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [Ignore]
        public string NombreCompleto
        {
            get
            {
                return $"{Nombres} {Apellidos}";
            }
        }

    }

}