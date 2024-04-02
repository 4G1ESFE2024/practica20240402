
using Practica20240402.AccesoADatos;
using Practica20240402.EntidadesDeNegocio;

namespace Practica20240402.LogicaDeNegocio
{
    public class ClienteBL
    {
        readonly ClienteDAL _clienteDAL;
        public ClienteBL(ClienteDAL clienteDAL)
        {
            _clienteDAL = clienteDAL;
        }
        public async Task<int> Crear(Cliente cliente)
        {
            return await _clienteDAL.Crear(cliente);
        }
        public async Task<int> Modificar(Cliente cliente)
        {
            return await _clienteDAL.Modificar(cliente);
        }
        public async Task<int> Eliminar(Cliente cliente)
        {
            return await _clienteDAL.Eliminar(cliente);
        }
        public async Task<Cliente> ObtenerPorId(Cliente cliente)
        {
            return await _clienteDAL.ObtenerPorId(cliente);
        }
        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await _clienteDAL.ObtenerTodos();
        }
        public async Task<List<Cliente>> Buscar(Cliente cliente) {
            return await _clienteDAL.Buscar(cliente);
        }
    }
}
