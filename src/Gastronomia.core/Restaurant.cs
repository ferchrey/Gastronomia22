namespace Gastronomia.core;

public class Restaurant
{
    public short idRestaurant { get; set; }
    public string Email { get; set; }
    public string Domicilio { get; set; }
    public string Contrasena { get; set; }
    public string Nombrer { get; set; }

    public Restaurant() { }
    public Restaurant(short idRestaurant, string Email, string Domicilio, string Contrasena, string Nombrer)
    {
        this.idRestaurant = idRestaurant;
        this.Email = Email;
        this.Domicilio = Domicilio;
        this.Contrasena = Contrasena;
        this.Nombrer = Nombrer;
    }
}