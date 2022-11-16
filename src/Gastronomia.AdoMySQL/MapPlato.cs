
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapPlato : Mapeador<Plato>
{
    public MapRestaurant MapRestaurant { get; set; }
    public MapPlato(AdoAGBD ado) : base(ado)
    {
        Tabla = "Plato";
    }
    public MapPlato(MapRestaurant mapRestaurant) : this(mapRestaurant.AdoAGBD)
    {
        MapRestaurant = mapRestaurant;
    }
    public override Plato ObjetoDesdeFila(DataRow fila)
        => new Plato()
        {
            idPlato = Convert.ToInt16(fila["idPlato"]),
            Nombre = Convert.ToString(fila["nombre"]),
            Descripcion = Convert.ToString(fila["Descripcion"]),
            PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]),
            idRestaurant = MapRestaurant.RestaurantPorId(Convert.ToByte(fila["idRestaurant"])),
            Disponible = Convert.ToBoolean(fila["Disponible"])

        };

    public void altaPlato(Plato plato)
    => EjecutarComandoCon("altaPlato", ConfiguraraltaPlato, plato);

    public Plato PlatoPorId(int id)
        => FiltrarPorPK("idPlato", id)!;
    public void ConfiguraraltaPlato(Plato plato)
    {
        SetComandoSP("altaPlato");

        BP.CrearParametro("unidPlato")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(plato.idPlato)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(25)
            .SetValor(plato.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unDescripcion")
            .SetTipoVarchar(45)
            .SetValor(plato.Descripcion)
            .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
            .SetTipoDecimal(7, 2)
            .SetValor(plato.PrecioUnitario)
            .AgregarParametro();

        BP.CrearParametro("unidRestaurant")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(plato.idRestaurant.idRestaurant)
            .AgregarParametro();

        BP.CrearParametro("unDisponible")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(plato.Disponible)
            .AgregarParametro();
    }

}

