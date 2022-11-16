using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;
namespace Gastronomia22.AdoMySQLTest;

public class VentaRestoTest
{
    public AdoGastronomia Ado { get; set; }
    public VentaRestoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoGastronomia(adoAGBD);
    }

    [Fact]
    public void altaVentaResto()
    {
        var VentaResto = new VentaResto(2, 2022, 11, Ado.ObtenerPlatoPorId(1), 50);
        Ado.altaVentaResto(VentaResto);
        Assert.Equal(2, VentaResto.idResto);
    }
    [Theory]
    [InlineData(1)]
    public void TraerVentaResto(int id)
    {
        var plato = Ado.ObtenerPlatos();
        Assert.Contains(plato, x => x.idPlato == id);
    }
}