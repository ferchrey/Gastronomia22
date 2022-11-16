using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastronomia.core
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        Cliente? ObtenerClientePorId(int id);

        void altaRestaurant(Restaurant restaurant);
        public List<Restaurant> ObtenerRestaurant();
        Restaurant? ObtenerRestaurantPorId(int id);

        void altaPedido(Pedido pedido);
        List<Pedido> ObtenerPedidos();
        Pedido? ObtenerPedidoPorId(byte id);

        public void altaPlato(Plato plato);
        public List<Plato> ObtenerPlatos();
        Plato? ObtenerPlatoPorId(int id);

        public void altaMenuplato(Menuplato menuplato);
        public List<Menuplato> ObtenerMenuplato();
        Menuplato? ObtenerMenuplatoPorId(int id);

        public void altaVentaResto(VentaResto ventaResto);
        public List<VentaResto> ObtenerVentaResto();

    }
}