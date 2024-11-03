using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozinha.Model;
using Cozinha.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cozinha.Services;

namespace Cozinha.Controllers{
    // Define a rota base para o controller e declara-o como API
    [Route("api/[controller]")]
    [ApiController]
    public class RefeicaoController : ControllerBase
    {
        private readonly CozinhaContext _context;
        private readonly RefeicaoService _service; // serviço para gerenciar refeições

        // Construtor do controller, inicializa o serviço
        public RefeicaoController (CozinhaContext context) {
            _context = context;
            _service = new RefeicaoService(_context);
        }

        // Método GET para retornar todas as refeições
        // Rota: api/Refeicao/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ListarRefeicaoDTO>>> GetRefeicoes()
        {
            return await _service.GetRefeicoes();
        }

        // Método GET para retornar uma refeição específica pelo ID
        // Rota: api/Refeicao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListarRefeicaoDTO>> GetRefeicaoById(int id)
        {
            var refeicao = await _service.GetRefeicao(id);
            if (refeicao == null)
            {
                return NotFound("Refeição não encontrada.");
            }
            return refeicao;
        }

        // Método POST para criar uma nova refeição
        // Rota: api/Refeicao
        [HttpPost]
        public async Task<ActionResult<ListarRefeicaoDTO>> PostRefeicao(CriarRefeicaoDTO newRefeicao)
        {
            return await _service.AddRefeicao(newRefeicao);
        }
        // US014 - Servir refeição (decrementa quantidade)
        [HttpPut("{id}/servir")]
        public async Task<ActionResult<ListarRefeicaoDTO>> ServirRefeicao(int id)
        {
            try
            {
                return await _service.ServirRefeicao(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // US015 - Remover refeição futura
        [HttpDelete("{id}/remover")]
        public async Task<IActionResult> RemoverRefeicaoFutura(int id)
        {
            try
            {
                await _service.RemoverRefeicaoFutura(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public class ProduzirRefeicaoRequest
        {
            public int QuantidadeExtra { get; set; }
        }
        // Método PUT para produzir mais refeições
        // Rota: api/refeicao/{id}/produzir
        [HttpPut("{id}/produzir")]
        public async Task<ActionResult<ListarRefeicaoDTO>> ProduzirRefeicao(int id, [FromBody] ProduzirRefeicaoRequest request)
        {
            try
            {
                var refeicaoAtualizada = await _service.ProduzirRefeicao(id,  request.QuantidadeExtra);
                return Ok(refeicaoAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Refeicao/all
        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllRefeicoes()
        {
            await _service.DeleteAllRefeicoes();
            return NoContent();
        }
    
        
    }
}
