
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapVentaResto : Mapeador<VentaResto>
{
    public MapPlato MapPlato { get; set; }
    public MapVentaResto(AdoAGBD ado) : base(ado)
    {
        Tabla = "VentaResto";
    }
    public MapVentaResto(MapPlato mapPlato) : this(mapPlato.AdoAGBD)
    {
        MapPlato = mapPlato;
    }
    public override VentaResto ObjetoDesdeFila(DataRow fila)
        => new VentaResto()
        {
            idResto = Convert.ToInt16(fila["idResto"]),
            Anio = Convert.ToUInt16(fila["Anio"]),
            MES = Convert.ToByte(fila["MES"]),
            idPlato = MapPlato.PlatoPorId(Convert.ToInt16(fila["idPlato"])),
            Monto = Convert.ToDecimal(fila["Monto"])

        };

    public void altaVentaResto(VentaResto ventaresto)
    => EjecutarComandoCon("altaVentaResto", ConfiguraraltaVentaResto, ventaresto);

    public VentaResto VentaRestoPorId(int id)
        => FiltrarPorPK("idVentaResto", id)!;
    public void ConfiguraraltaVentaResto(VentaResto ventaresto)
    {
        SetComandoSP("altaVentaResto");

        BP.CrearParametro("unidResto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(ventaresto.idResto)
            .AgregarParametro();

        BP.CrearParametro("unAnio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaresto.Anio)
            .AgregarParametro();

        BP.CrearParametro("unMES")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaresto.MES)
            .AgregarParametro();

        BP.CrearParametro("unidPlato")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(ventaresto.idPlato.idPlato)
            .AgregarParametro();

        BP.CrearParametro("unMonto")
            .SetTipoDecimal(5, 2)
            .SetValor(ventaresto.Monto)
            .AgregarParametro();
    }

}

