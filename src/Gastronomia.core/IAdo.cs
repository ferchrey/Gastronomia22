using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Gastronomia.core
{
    public interface IAdo
    {
        void registrarCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
    }
}