using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastronomia.core
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string EmailCliente { get; set; }
        public string ContrasenaC { get; set; }

        public Cliente() { }
        public Cliente(int idCliente, string Nombre, string Apellido, string EmailCliente, string ContrasenaC)
        {
            this.idCliente = idCliente;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.EmailCliente = EmailCliente;
            this.ContrasenaC = ContrasenaC;
        }
    }
}
