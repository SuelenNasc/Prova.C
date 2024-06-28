using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Loja.Models;
using Loja.Services;

namespace Loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly ServicoService _servicoService;

        public ServicosController(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        // POST: api/servicos
        [HttpPost]
        [Authorize]
        public IActionResult CreateServico([FromBody] Servico servico)
        {
            if (servico == null)
            {
                return BadRequest();
            }

            var createdServico = _servicoService.CreateServico(servico);

            return CreatedAtAction(nameof(GetServicoById), new { id = createdServico.Id }, createdServico);
        }

        // PUT: api/servicos/{id}
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateServico(int id, [FromBody] Servico updatedServico)
        {
            var servico = _servicoService.UpdateServico(id, updatedServico);
            if (servico == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/servicos/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetServicoById(int id)
        {
            var servico = _servicoService.GetServicoById(id);
            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        // GET: api/servicos
        [HttpGet]
        [Authorize]
        public IActionResult GetAllServicos()
        {
            var servicos = _servicoService.GetAllServicos();
            return Ok(servicos);
        }
        
    [HttpGet("{clienteId}/servicos")]
    [Authorize]
    public async Task<IActionResult> GetServicosByClienteId(int clienteId)
    {
        var servicos = await ContratoService.GetServicosByClienteIdAsync(clienteId);
        if (servicos == null || !servicos.Any())
        {
            return NotFound($"Nenhum serviço encontrado para o cliente de ID {clienteId}");
        }

        return Ok(servicos);
    }
    }
}
