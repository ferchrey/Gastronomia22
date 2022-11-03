using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;

namespace Gastronomia22.AdoMySQLTest;

public class ClienteTest
{
    public AdoCliente Ado { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoCliente(adoAGBD);
    }
    
    [Fact]
    public void registrarCliente()
    {
        var cliente = new Cliente(2, "jose", "guerrero", "weon@gmail.com", "nose");
        Ado.AltaCliente(cliente);
        Assert.Equal(2, cliente.idCliente);
    }

    [Theory]
    [InlineData(1, "alberto")]
    public void TraerCliente(int id, string nombre)
    {
        var cliente = Ado.ObtenerCliente();
        Assert.Contains(cliente, h => h.idCliente == id && h.Nombre == nombre);
    }
}