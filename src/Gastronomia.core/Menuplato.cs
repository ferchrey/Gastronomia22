namespace Gastronomia.core;

public class Menuplato
{
    public short CantPlato { get; set; }
    public double PrecioUnitario { get; set; }
    public int idPlato { get; set; }
    public int idPedido { get; set; }

    public Menuplato() { }
    public Menuplato(short CantPlato, double PrecioUnitario, int idPlato, int idPedido)
    {
        this.CantPlato = CantPlato;
        this.PrecioUnitario = PrecioUnitario;
        this.idPlato = idPlato;
        this.idPedido = idPedido;

    }
}
