using Microsoft.EntityFrameworkCore;
using Practica20240402.EntidadesDeNegocio;

namespace Practica20240402.AccesoADatos
{
    public class ClienteDAL
    {
        readonly AppDbContext _appDbContext;
        public ClienteDAL( AppDbContext appDbContext) {
         _appDbContext = appDbContext;
        }
        public async Task<int> Crear(Cliente cliente) {
            _appDbContext.Add(cliente);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Modificar(Cliente cliente) {
            var clienteData= await _appDbContext.Clientes.FirstOrDefaultAsync(s=> s.Id== cliente.Id);
            if(clienteData!=null)
            {
                clienteData.Nombre= cliente.Nombre;
                clienteData.Apellido= cliente.Apellido;
                clienteData.FechaNacimiento = cliente.FechaNacimiento;
                _appDbContext.Update(clienteData);
            }           
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Eliminar(Cliente cliente)
        {
            var clienteData = await _appDbContext.Clientes.FirstOrDefaultAsync(s => s.Id == cliente.Id);
            if (clienteData != null)            
                _appDbContext.Remove(clienteData);            
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<Cliente> ObtenerPorId(Cliente cliente) {
            var clienteData = await _appDbContext.Clientes.FirstOrDefaultAsync(s => s.Id == cliente.Id);
            if (clienteData != null)
                return clienteData;
            else
                return new Cliente();
        }
        public async Task<List<Cliente>> ObtenerTodos() {
            return await _appDbContext.Clientes.ToListAsync();
        }
        public async Task<List<Cliente>> Buscar(Cliente cliente) {

            var query = _appDbContext.Clientes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                query = query.Where(s => s.Nombre.Contains(cliente.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                query = query.Where(s => s.Apellido.Contains(cliente.Apellido));
            }
            return await query.ToListAsync();
        }
    }
}
