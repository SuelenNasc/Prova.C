using Loja.Data;
using Loja.Models;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Services
{
    public class ServicoService(ApiDbContext context)
    {
        private readonly ApiDbContext _context = context;

        public Servico CreateServico(Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
            return servico;
        }

        public Servico UpdateServico(int id, Servico updatedServico)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null)
            {
                return null;
            }

            servico.Nome = updatedServico.Nome;
            servico.Preco = updatedServico.Preco;
            servico.Status = updatedServico.Status;

            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return servico;
        }

        public Servico GetServicoById(int id)
        {
            return _context.Servicos.Find(id);
        }

        public List<Servico> GetAllServicos()
        {
            return _context.Servicos.ToList();
        }
    }

    internal class ApiDbContext
    {
        public object Servicos { get; internal set; }
        public object Contratos { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public class Servico
    {
        public object Nome { get; internal set; }
        public object Preco { get; internal set; }
        public object Status { get; internal set; }
    }
}
