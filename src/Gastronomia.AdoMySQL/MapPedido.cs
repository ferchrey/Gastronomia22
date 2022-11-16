using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Gastronomia.core;
using et12.edu.ar.AGBD.Ado;

namespace Gastronomia.AdoMySQL;
public class MapPedido : Mapeador<Pedido>
{
    public MapRestaurant MapRestaurant { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapPedido(AdoAGBD ado) : base(ado) => Tabla = "Pedido";
    public MapPedido(MapRestaurant mapRestaurant, MapCliente mapCliente) : this(mapRestaurant.AdoAGBD)
    {
        MapRestaurant = mapRestaurant;
        MapCliente = mapCliente;
    }

    public override Pedido ObjetoDesdeFila(DataRow fila)
        => new Pedido()
        {
            idPedido = Convert.ToByte(fila["idPedido"]),
            FechayHora = Convert.ToDateTime(fila["FechayHora"]),
            Restaurant = MapRestaurant.RestaurantPorId(Convert.ToByte(fila["idRestaurant"])),
            idCliente = MapCliente.ClientePorId(Convert.ToUInt16(fila["idCliente"])),
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
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(pedido.FechayHora)
            .AgregarParametro();

        BP.CrearParametro("unidRestaurant")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(pedido.Restaurant.idRestaurant)
            .AgregarParametro();

        BP.CrearParametro("unidCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(pedido.idCliente.idCliente)
            .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
            .SetTipoDecimal(5, 2)
            .SetValor(pedido.PrecioUnitario)
            .AgregarParametro();

        BP.CrearParametro("unDescripcion")
            .SetTipoVarchar(45)
            .SetValor(pedido.Descripcion)
            .AgregarParametro();

        BP.CrearParametro("unValoracion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
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