namespace Gastronomia.core;

public class Pedido
{
    public int idPedido { get; set; }
    public DateTime FechayHora { get; set; }
    public Restaurant Restaurant { get; set; }
    public int idCliente { get; set; }
    public decimal PrecioUnitario { get; set; }
    public byte Valoracion { get; set; }
    public string Descripcion { get; set; }

    public Pedido() { }
    public Pedido(int idPedido, DateTime FechayHora, Restaurant Restaurant, int idCliente, decimal PrecioUnitario, byte Valoracion, string Descripcion)
    {
        this.idPedido = idPedido;
        this.FechayHora = FechayHora;
        this.Restaurant = Restaurant;
        this.idCliente = idCliente;
        this.PrecioUnitario = PrecioUnitario;
        this.Valoracion = Valoracion;
        this.Descripcion = Descripcion;
    }
}

