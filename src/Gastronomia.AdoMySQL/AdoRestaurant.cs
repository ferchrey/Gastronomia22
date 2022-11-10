using et12.edu.ar.AGBD.Ado;
using Gastronomia.core;

namespace Gastronomia.AdoMySQL

{
    public class AdoRestaurant
    {
        
    public AdoAGBD Ado { get; set; }
    public MapRestaurant MapRestaurant{ get; set; }
    public AdoRestaurant(AdoAGBD ado)
    {
        Ado = ado;
        MapRestaurant = new MapRestaurant(Ado);
    }
    public void altaRestaurant(Restaurant restaurant) => MapRestaurant.altaRestaurant(restaurant);

    public List<Restaurant> ObtenerRestaurant() => MapRestaurant.ColeccionDesdeTabla();
    
    }

}


