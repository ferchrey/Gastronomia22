using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapRestaurant : Mapeador<Restaurant>
{
    public MapRestaurant(AdoAGBD ado) : base(ado)
    {
        Tabla = "Restaurant";
    }

    public override Restaurant ObjetoDesdeFila (DataRow fila)
        => new Restaurant()
        {
            idRestaurant = Convert.ToByte(fila["idRestaurant"]),
            Email = fila["Email"].ToString(),
            Domicilio = fila["Domicilio"].ToString(),
            Contrasena = fila["Contrasena"].ToString(),
            Nombrer = fila["Nombrer"].ToString(),

        };
    public void altaRestaurant(Restaurant restaurant)
    => EjecutarComandoCon("altaRestaurant", ConfiguraraltaRestaurant, PostaltaRestaurant, restaurant);

    public Restaurant RestaurantPorId(byte id)
        => FiltrarPorPK("idRestaurant", id)!;
    public void ConfiguraraltaRestaurant(Restaurant restaurant)
    {
        SetComandoSP("altaRestaurant");

        BP.CrearParametro("unidRestaurant")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(restaurant.idRestaurant)
            .AgregarParametro();

        BP.CrearParametro("unEmail")
            .SetTipoVarchar(25)
            .SetValor(restaurant.Email)
            .AgregarParametro();

        BP.CrearParametro("unDomicilio")
            .SetTipoVarchar(25)
            .SetValor(restaurant.Domicilio)
            .AgregarParametro();

        BP.CrearParametro("unContrasena")
            .SetTipoVarchar(64)
            .SetValor(restaurant.Contrasena)
            .AgregarParametro();

        BP.CrearParametro("unNombrer")
            .SetTipoVarchar(25)
            .SetValor(restaurant.Nombrer)
            .AgregarParametro();
    }
    public void PostaltaRestaurant(Restaurant restaurant)
    {
        var paramidRestaurant = GetParametro("unidRestaurant");
        restaurant.idRestaurant = Convert.ToByte(paramidRestaurant.Value);
    }

}

