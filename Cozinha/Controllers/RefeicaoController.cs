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
        private readonly RefeicaoService _service; // serviço para gerenciar refeições

        // Construtor do controller, inicializa o serviço
        public RefeicaoController(RefeicaoService service)
        {
            _service = service;
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
        public async Task<ActionResult<ListarRefeicaoDTO>> GetRefeicao(long id)
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
        public async Task<ActionResult<ListarRefeicaoDTO>> ServirRefeicao(long id)
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
        [HttpDelete("{id}/remove-future")]
        public async Task<IActionResult> RemoverRefeicaoFutura(long id)
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
        // Método PUT para produzir mais refeições
        // Rota: api/refeicao/{id}/produzir
        [HttpPut("{id}/produzir")]
        public async Task<ActionResult<ListarRefeicaoDTO>> ProduzirRefeicao(int id, int quantidadeExtra)
        {
            try
            {
                var refeicaoAtualizada = await _service.ProduzirRefeicao(id, quantidadeExtra);
                return Ok(refeicaoAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        //Método get ementa disponivel
        [HttpGet("EmentaDisponivel")]
        public async Task<ActionResult<IEnumerable<ListarEmentaDTO>>> GetEmentaDisponivel([FromQuery] DateTime data, [FromQuery] long tipoRefeicaoId)
        {
            var ementa = await _service.GetEmentaDisponivel(data, tipoRefeicaoId);
            return Ok(ementa);
        }
    }
}
