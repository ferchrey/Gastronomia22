
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapVentaResto : Mapeador<VentaResto>
{
    public MapMenuplato MapMenuplato { get; set; }
    public MapVentaResto(AdoAGBD ado) : base(ado)
    {
        Tabla = "VentaResto";
    }
    public MapVentaResto(MapMenuplato mapMenuplato) : this(mapMenuplato.AdoAGBD)
    {
        MapMenuplato = mapMenuplato;
    }
    public override VentaResto ObjetoDesdeFila(DataRow fila)
        => new VentaResto()
        {
            idResto = Convert.ToInt16(fila["idVentaResto"]),
            Anio = Convert.ToUInt16(fila["nombre"]),
            MES = Convert.ToByte(fila["Descripcion"]),
            idPlato = MapMenuplato.MenuplatoPorId(Convert.ToInt16(fila["a"])),
            PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]),
            Disponible = Convert.ToBoolean(fila["Disponible"])

        };

    public void altaVentaResto(VentaResto ventaresto)
    => EjecutarComandoCon("altaVentaResto", ConfiguraraltaVentaResto, ventaresto);

    public VentaResto VentaRestoPorId(int id)
        => FiltrarPorPK("idVentaResto", id)!;
    public void ConfiguraraltaVentaResto(VentaResto ventaresto)
    {
        SetComandoSP("altaVentaResto");

        BP.CrearParametro("unidVentaResto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaresto.idVentaResto)
            .AgregarParametro();

        BP.CrearParametro("unnombre")
            .SetTipoVarchar(25)
            .SetValor(ventaresto.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unDescripcion")
            .SetTipoVarchar(45)
            .SetValor(ventaresto.Descripcion)
            .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
            .SetTipoDecimal(7, 2)
            .SetValor(ventaresto.PrecioUnitario)
            .AgregarParametro();

        BP.CrearParametro("unidRestaurant")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaresto.idRestaurant.idRestaurant)
            .AgregarParametro();

        BP.CrearParametro("unDisponible")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(ventaresto.Disponible)
            .AgregarParametro();
    }

}

