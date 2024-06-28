using Loja.Data;
using Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Services
{
    public class ContratoService(ApiDbContext context)
    {
        private readonly ApiDbContext _context = context;

        internal static async Task GetServicosByClienteIdAsync(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Contrato CreateContrato(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            _context.SaveChanges();
            return contrato;
        }

        public List<Contrato> GetContratosByClienteId(int clienteId)
        {
            return _context.Contratos.Where(c => c.ClienteId == clienteId).ToList();
        }

        internal object GetContratoById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
