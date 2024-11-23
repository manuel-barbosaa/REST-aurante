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


namespace Cozinha.Controllers
{
    //define a rota base para o controller e declara-o como API
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        //Declarações de dependencias do controller 
        private readonly CozinhaContext _context; //contexto do banco de dados
        private PratoService _service; //serviço de prato

        //Construtor do controller, inicializa o contexto e o serviço
        public PratoController(CozinhaContext context)
        {
            _context = context;
            _service = new PratoService(context);
        }
        //Método GET que retorna todos os pratos
        //Rota: api/Prato/all
        // GET: api/Prato
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ListarPratoDTO>>> GetPratos()
        {
            return await _service.GetPratos();
        }

        //Método GET que retorna todos os pratos ativos (disponíveis)
        //Rota: api/Prato/available
        // GET: api/Prato/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<ListarPratoDTO>>> GetAvailablePratos()
        {
            return await _service.GetPratosAtivosList();
        }

        //Método GET que retorna um prato específico pelo seu id
        //Rota: api/Prato/{id}
         // GET /api/Prato/1
        [HttpGet("{id}")]  
        public async Task<ActionResult<ListarPratoDTO>> GetPrato(long id)
        {
            return await _service.GetPrato(id);
        }

        //Método POST que cria um novo prato com base nos dados recebidos
        //Rota: api/Prato
        // POST: api/Prato
        [HttpPost]
        public async Task<ActionResult<ListarPratoDTO>> PostPrato(CriarPratoDTO prato)
        {
            return await _service.CreateNewPrato(prato);
        }

      
        // Método PUT para ativar um prato específico
        // Rota: api/prato/{id}/activate
        // PUT: api/prato/{id}/activate
        [HttpPut("prato/{id}/activate")]
        public async Task<ActionResult<ListarPratoDTO>> ActivatePrato(long id)
        {
            return await _service.AtivarPrato(id);
        }

        // Método PUT para desativar um prato específico
        // Rota: api/prato/{id}/deactivate
        // PUT: api/prato/{id}/deactivate
        [HttpPut("prato/{id}/deactivate")]
        public async Task<ActionResult<ListarPratoDTO>> DeactivatePrato(long id)
        {
            return await _service.InativarPrato(id);
        }

        //Método PUT para desativar um ingrediente específico
        //Rota: api/ingrediente/{nome}/activate
        // PUT: api/ingrediente/{nome}/deactivate
        [HttpPut("ingrediente/{nome}/deactivate")]
        public async Task<IActionResult> DeactivateIngrediente(string nome)
        {
            await _service.InativarIngrediente(nome);
            return NoContent();  // Responde com status 204 No Content
        }


        //Método PUT para ativar um ingrediente específico
        // PUT: api/ingrediente/{nome}/activate
        [HttpPut("ingrediente/{nome}/activate")]
        public async Task<IActionResult> ActivateIngrediente(string nome)
        {
            await _service.AtivarIngrediente(nome);
            return NoContent();
        }
        
        // DELETE: api/Prato/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePrato(long id)
        {
            var deleted = await _service.DeletePrato(id);

            if (!deleted)
            {
                return NotFound(); // Retorna 404 se o prato não for encontrado
            }

            return NoContent(); // Retorna 204 se o prato for removido com sucesso
        }
    }
}