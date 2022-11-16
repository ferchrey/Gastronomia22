using et12.edu.ar.AGBD.Ado;
using Gastronomia.core;

namespace Gastronomia.AdoMySQL;

public class AdoGastronomia : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapRestaurant MapRestaurant { get; set; }
    public MapPedido MapPedido { get; set; }
    public MapPlato MapPlato { get; set; }
    public MapMenuplato MapMenuplato { get; set; }
    public AdoGastronomia(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
        MapRestaurant = new MapRestaurant(Ado);
        MapPedido = new MapPedido(MapRestaurant, MapCliente);
        MapPlato = new MapPlato(MapRestaurant);
        MapMenuplato = new MapMenuplato(MapPedido, MapPlato);
    }
    public void AltaCliente(Cliente cliente) => MapCliente.registrarCliente(cliente);

    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();

    public Cliente? ObtenerClientePorId(int id)
        => MapCliente.FiltrarPorPK("idCliente", id);

    public void altaRestaurant(Restaurant restaurant) => MapRestaurant.altaRestaurant(restaurant);

    public List<Restaurant> ObtenerRestaurant() => MapRestaurant.ColeccionDesdeTabla();
    public Restaurant? ObtenerRestaurantPorId(int id)
        => MapRestaurant.FiltrarPorPK("idRestaurant", id);

    public void altaPedido(Pedido pedido) => MapPedido.altaPedido(pedido);
    public List<Pedido> ObtenerPedidos() => MapPedido.ColeccionDesdeTabla();
    public Pedido? ObtenerPedidoPorId(byte id)
        => MapPedido.FiltrarPorPK("idPedido", id);

    public void altaPlato(Plato plato) => MapPlato.altaPlato(plato);
    public List<Plato> ObtenerPlatos() => MapPlato.ColeccionDesdeTabla();
    public Plato? ObtenerPlatoPorId(int id)
        => MapPlato.FiltrarPorPK("idPlato", id);

    public void altaMenuplato(Menuplato menuplato) => MapMenuplato.altaMenuplato(menuplato);
    public List<Menuplato> ObtenerMenuplato() => MapMenuplato.ColeccionDesdeTabla();
    public Menuplato? ObtenerMenuplatoPorId(byte id)
        => MapMenuplato.FiltrarPorPK("idPedido", id);
}
