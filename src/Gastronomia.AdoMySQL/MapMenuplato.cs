using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapMenuplato : Mapeador<Menuplato>
{
    public MapPedido MapPedido { get; set; }
    public MapPlato MapPlato { get; set; }
    public MapMenuplato(AdoAGBD ado) : base(ado) => Tabla = "Menuplato";
    public MapMenuplato(MapPedido mapPedido, MapPlato mapPlato) : this(mapPlato.AdoAGBD)
    {
        MapPedido = mapPedido;
        MapPlato = mapPlato;
    }

    public override Menuplato ObjetoDesdeFila(DataRow fila)
        => new Menuplato()
        {
            CantPlato = Convert.ToInt16(fila["CantPlato"]),
            PrecioUnitario = Convert.ToDouble(fila["PrecioUnitario"]),
            idPlato = MapPlato.PlatoPorId(Convert.ToInt16(fila["idPlato"])),
            idPedido = MapPedido.PedidoPorId(Convert.ToByte(fila["idPedido"]))

        };
    public void altaMenuplato(Menuplato menuplato)
    => EjecutarComandoCon("altaMenuplato", ConfiguraraltaMenuplato, menuplato);

    public Menuplato MenuplatoPorId(int id)
        => FiltrarPorPK("idPlato", id)!;
    public void ConfiguraraltaMenuplato(Menuplato menuplato)
    {
        SetComandoSP("altaMenuplato");

        BP.CrearParametro("unCantPlato")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(menuplato.CantPlato)
            .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
            .SetTipoDecimal(5, 2)
            .SetValor(menuplato.PrecioUnitario)
            .AgregarParametro();

        BP.CrearParametro("unidPlato")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(menuplato.idPlato.idPlato)
            .AgregarParametro();

        BP.CrearParametro("unidPedido")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(menuplato.idPedido.idPedido)
            .AgregarParametro();

    }
    public List<Menuplato> ObtenerMenuplato() => ColeccionDesdeTabla();
}