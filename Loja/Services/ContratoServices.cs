using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Loja.Models;
using Loja.Services;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly ContratoService _contratoService;

        public ContratosController(ContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        // POST: api/contratos
        [HttpPost]
        [Authorize]
        public IActionResult CreateContrato([FromBody] Contrato contrato)
        {
            if (contrato == null)
            {
                return BadRequest();
            }

            var createdContrato = _contratoService.CreateContrato(contrato);

            return CreatedAtAction(nameof(GetContratoById), new { id = createdContrato.Id }, createdContrato);
        }

        // GET: api/contratos/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetContratoById(int id)
        {
            var contrato = _contratoService.GetContratoById(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // GET: api/clientes/{clienteId}/contratos
        [HttpGet("/clientes/{clienteId}/contratos")]
        [Authorize]
        public IActionResult GetContratosByClienteId(int clienteId)
        {
            var contratos = _contratoService.GetContratosByClienteId(clienteId);
            return Ok(contratos);
        }

        public async Task<List<Servico>> GetServicosByClienteIdAsync(int clienteId)
    {
        var servicos = await DbContext.Contratos
            .Where(c => c.ClienteId == clienteId)
            .Select(c => c.Servico)
            .ToListAsync();

        return servicos;
    }
}
