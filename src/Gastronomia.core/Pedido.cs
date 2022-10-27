using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Gastronomia.core
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime FechayHora { get; set; }
        public short idRestaurant { get; set; }
        public int idCliente { get; set; }
        public decimal PrecioUnitario { get; set; }
        public byte Valoracion { get; set; }
        public string Descripcion { get; set; }

        public Pedido() { }
        public Pedido(int idPedido, DateTime FechayHora, short idRestaurant, int idCliente, decimal PrecioUnitario, byte Valoracion, string Descripcion)
        {
            this.idPedido = idPedido;
            this.FechayHora = FechayHora;
            this.idRestaurant = idRestaurant;
            this.idCliente = idCliente;
            this.PrecioUnitario = PrecioUnitario;
            this.Valoracion = Valoracion;
            this.Descripcion = Descripcion;
        }
    }
}

