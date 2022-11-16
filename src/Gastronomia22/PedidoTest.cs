using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;
namespace Gastronomia22.AdoMySQLTest;

public class PedidoTest
{
    public AdoGastronomia Ado { get; set; }
    public PedidoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoGastronomia(adoAGBD);
    }

    [Fact]
    public void altaPedido()
    {
        DateTime ahora = new DateTime(2004, 12, 12);
        var pedido = new Pedido(3, ahora, Ado.ObtenerRestaurantPorId(1)!, Ado.ObtenerClientePorId(2)!, 2, 1, "mal oplato2");
        Ado.altaPedido(pedido);
        Assert.Equal(3, pedido.idPedido);
    }
    [Theory]
    [InlineData(1)]
    public void TraerPedido(int id)
    {
        var pedido = Ado.ObtenerPedidos();
        Assert.Contains(pedido, x => x.idPedido == id);
    }
}