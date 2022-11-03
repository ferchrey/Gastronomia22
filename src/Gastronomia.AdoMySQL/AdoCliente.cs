using et12.edu.ar.AGBD.Ado;
using Gastronomia.core;

namespace Gastronomia.AdoMySQL;

public class AdoCliente
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public AdoCliente(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
    }
    public void AltaCliente(Cliente cliente) => MapCliente.registrarCliente(cliente);

    public List<Cliente> ObtenerCliente() => MapCliente.ColeccionDesdeTabla();
}
