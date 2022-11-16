using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;
namespace Gastronomia22.AdoMySQLTest;

public class PlatoTest
{
    public AdoGastronomia Ado { get; set; }
    public PlatoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoGastronomia(adoAGBD);
    }

    [Fact]
    public void altaPlato()
    {
        var plato = new Plato(3, "pinga", "é uma delícia", 1, Ado.ObtenerRestaurantPorId(1), true);
        Ado.altaPlato(plato);
        Assert.Equal(3, plato.idPlato);
    }
    [Theory]
    [InlineData(1)]
    public void TraerPlato(int id)
    {
        var plato = Ado.ObtenerPlatos();
        Assert.Contains(plato, x => x.idPlato == id);
    }
}