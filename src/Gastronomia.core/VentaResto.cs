namespace Gastronomia.core;

public class VentaResto
{
    public int idResto { get; set; }
    public ushort Anio { get; set; }
    public byte MES { get; set; }
    public int idPlato { get; set; }
    public decimal Monto { get; set; }

    public VentaResto() { }
    public VentaResto(int idResto, ushort Anio, byte MES, int idPlato, decimal Monto)
    {
        this.idResto = idResto;
        this.Anio = Anio;
        this.MES = MES;
        this.idPlato = idPlato;
        this.Monto = Monto;
    }
}
