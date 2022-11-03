using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastronomia.core
{
    public interface IAdo
    {
        void registrarCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
    }
}