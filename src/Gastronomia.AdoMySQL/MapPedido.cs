using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapPedido : Mapeador<Pedido>
{
    public MapRestaurant MapRestaurant { get; set; }
    public MapPedido(AdoAGBD ado) : base(ado) => Tabla = "Pedido";
    public MapPedido(MapRestaurant mapRestaurant) : this(mapRestaurant.AdoAGBD)
            => MapRestaurant = mapRestaurant;

    public override Pedido ObjetoDesdeFila(DataRow fila)
        => new Pedido()
        {
            idPedido = Convert.ToByte(fila["idPedido"]),
            FechayHora = Convert.ToDateTime(fila["FechayHora"]),
            Restaurant = MapRestaurant.RestaurantPorId(Convert.ToByte(fila["idRestaurant"])),
            idCliente = Convert.ToInt16(fila["idCLiente"]),
            PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]),
            Valoracion = Convert.ToByte(fila["Valoracion"]),
            Descripcion = Convert.ToString(fila["Descripcion"])

        };
    public void altaPedido(Pedido pedido)
    => EjecutarComandoCon("altaPedido", ConfiguraraltaPedido, PostaltaPedido, pedido);

    public Pedido PedidoPorId(byte id)
        => FiltrarPorPK("idPedido", id)!;
    public void ConfiguraraltaPedido(Pedido pedido)
    {
        SetComandoSP("altaPedido");


        BP.CrearParametro("unidPedido")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(pedido.idPedido)
            .AgregarParametro();
        
        BP.CrearParametro("unFechayHora")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(pedido.FechayHora)
            .AgregarParametro();
        
        BP.CrearParametro("unidRestaurant")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(pedido.Restaurant.idRestaurant)
            .AgregarParametro();
        
        BP.CrearParametro("unidCliente")
            .SetTipoDecimal(7, 2)
            .SetValor(pedido.idCliente)
            .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
            .SetTipoVarchar(60)
            .SetValor(pedido.PrecioUnitario)
            .AgregarParametro();

        BP.CrearParametro("unValoracion")
            .SetTipoVarchar(60)
            .SetValor(pedido.Valoracion)
            .AgregarParametro();

        BP.CrearParametro("unValoracion")
            .SetTipoVarchar(60)
            .SetValor(pedido.Valoracion)
            .AgregarParametro();

    }
    public void PostaltaPedido(Pedido pedido)
    {
        var paramidPedido = GetParametro("unidPedido");
        pedido.idPedido = Convert.ToByte(paramidPedido.Value);
    }
    public List<Pedido> ObtenerPedidos() => ColeccionDesdeTabla();
}