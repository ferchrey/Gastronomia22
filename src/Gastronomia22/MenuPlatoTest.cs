using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;
namespace Gastronomia22.AdoMySQLTest;

public class MenuPlatoTest
{
    public AdoGastronomia Ado { get; set; }
    public MenuPlatoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoGastronomia(adoAGBD);
    }

    [Fact]
    public void altaMenuplato()
    {
        var MenuPlato = new Menuplato(2, 1, Ado.ObtenerPlatoPorId(3), Ado.ObtenerPedidoPorId(2));
        Ado.altaMenuplato(MenuPlato);
        Assert.Equal(2, MenuPlato.idPedido.idPedido);
    }
    [Theory]
    [InlineData(1)]
    public void TraerMenuplato(int id)
    {
        var Menuplato = Ado.ObtenerMenuplato();
        Assert.Contains(Menuplato, x => x.idPedido.idPedido == id);
    }
}