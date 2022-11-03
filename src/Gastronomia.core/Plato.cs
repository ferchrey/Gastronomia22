namespace Gastronomia.core;

public class Plato
{
    public int idPlato { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal PrecioUnitario { get; set; }
    public short idRestaurant { get; set; }
    public bool Disponible { get; set; }

    public Plato() { }
    public Plato(int idPlato, string Nombre, string Descripcion, decimal PrecioUnitario, short idRestaurant, bool Disponible)
    {
        this.idPlato = idPlato;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.PrecioUnitario = PrecioUnitario;
        this.idRestaurant = idRestaurant;
        this.Disponible = Disponible;
    }
}
