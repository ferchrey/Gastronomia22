namespace Gastronomia.core;

public class Menuplato
{
    public short CantPlato { get; set; }
    public double PrecioUnitario { get; set; }
    public Plato idPlato { get; set; }
    public Pedido idPedido { get; set; }

    public Menuplato() { }
    public Menuplato(short CantPlato, double PrecioUnitario, Plato idPlato, Pedido idPedido)
    {
        this.CantPlato = CantPlato;
        this.PrecioUnitario = PrecioUnitario;
        this.idPlato = idPlato;
        this.idPedido = idPedido;

    }
}
