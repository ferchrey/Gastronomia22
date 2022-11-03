
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using src.Gastronomia.core;
using et12.edu.ar.AGBD.Ado;
namespace Gastronomia.AdoMySQL;

public class MapHotel : Mapeador<Cliente>
{
    public MapHotel(AdoAGBD ado) : base(ado)
    {
        Tabla = "Cliente";
    }

    public override Cliente ObjetoDesdeFila(DataRow fila)
        => new Cliente()
        {
            idCliente = Convert.ToUInt16(fila["idCliente"]),
            Nombre = fila["Nombre"].ToString(),
            Apellido = fila["Apellido"].ToString(),
            EmailCliente = fila["EmailCliente"].ToString(),
            ContrasenaC = fila["ContrasenaC"].ToString(),

        };
    public void registrarCliente(Cliente cliente)
    => EjecutarComandoCon("registrarCliente", ConfigurarregistrarCliente, PostregistrarCliente, cliente);

    public Cliente ClientePorId(int id)
        => FiltrarPorPK("idCliente", id)!;
    public void ConfigurarregistrarCliente(Cliente cliente)
    {
        SetComandoSP("registrarCliente");

        BP.CrearParametro("unregistrarCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(cliente.idCliente)
            .AgregarParametro();

        BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(cliente.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unApellido")
            .SetTipoVarchar(35)
            .SetValor(cliente.Apellido)
            .AgregarParametro();

        BP.CrearParametro("unEmailCliente")
            .SetTipoVarchar(25)
            .SetValor(cliente.EmailCliente)
            .AgregarParametro();

        BP.CrearParametro("unContrasenaC")
            .SetTipoVarchar(64)
            .SetValor(cliente.ContrasenaC)
            .AgregarParametro();
    }
    public void PostregistrarCliente(Cliente cliente)
    {
        var paramidCliente = GetParametro("unidCliente");
        cliente.idCliente = Convert.ToByte(paramidCliente.Value);
    }
    public List<Cliente> ObtenerCliente() => ColeccionDesdeTabla();
}

