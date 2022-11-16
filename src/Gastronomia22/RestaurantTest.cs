using et12.edu.ar.AGBD.Ado;
using Gastronomia.AdoMySQL;
using Gastronomia.core;

namespace Gastronomia22.AdoMySQLTest;

public class RestaurantTest
{
    public AdoGastronomia Ado { get; set; }
    public RestaurantTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoGastronomia(adoAGBD);
    }

    [Fact]
    public void altaRestaurant()
    {
        var restaurant = new Restaurant(2, "weon@gmail.com", "avcordoba", "cosaparacontrasena", "felipe");
        Ado.altaRestaurant(restaurant);
        Assert.Equal(2, restaurant.idRestaurant);
    }

    [Theory]
    [InlineData(1, "momo")]
    public void TraerRestaurant(byte id, string nombre)
    {
        var restaurant = Ado.ObtenerRestaurant();
        Assert.Contains(restaurant, h => h.idRestaurant == id && h.Nombrer == nombre);
    }
}
