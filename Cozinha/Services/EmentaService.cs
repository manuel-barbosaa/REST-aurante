using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cozinha.Services
{
    public class EmentaService
    {
        private readonly EmentaRepository _repo;

        public EmentaService(EmentaRepository repo)
        {
            _repo = repo;
        }

        // Método para buscar uma ementa pelo ID
        public async Task<ListarEmentaDTO?> GetEmentaDisponivelById(long id)
        {
            var ementa = await _repo.GetEmentaById(id);

            if (ementa == null) return null;

            return new ListarEmentaDTO
            {
                Id = ementa.Id,
                Frequencia = ementa.Frequencia,
                DataInicio = ementa.DataInicio,
                DataFim = ementa.DataFim,
                TipoRefeicao = ementa.TipoRefeicao,
                Quantidade = ementa.Quantidade
            };
        }

        // // Método para buscar ementas disponíveis para um tipo de refeição, quantidade > 0 e data específica
        // public async Task<List<ListarEmentaDTO>> GetEmentaDisponivel(long tipoRefeicaoId, DateTime data)
        // {
        //     var ementas = await _repo.GetEmentaByTipoQuantidadeData(tipoRefeicaoId, data);

        //     return ementas.Select(e => new ListarEmentaDTO
        //     {
        //         Id = e.Id,
        //         Frequencia = e.Frequencia,
        //         DataInicio = e.DataInicio,
        //         DataFim = e.DataFim,
        //         TipoRefeicao = e.TipoRefeicao,
        //         Quantidade = e.Quantidade
        //     }).ToList();
        // }
    

        // Método para adicionar uma nova ementa
        public async Task<ListarEmentaDTO> AddEmenta(CriarEmentaDTO dto)
        {
            var novaEmenta = new Ementa
            {
                Frequencia = dto.Frequencia,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataFim,
                TipoRefeicao = dto.TipoRefeicao,
                Quantidade = dto.Quantidade
            };

            var addedEmenta = await _repo.AddEmenta(novaEmenta);
            return new ListarEmentaDTO
            {
                Id = addedEmenta.Id,
                Frequencia = addedEmenta.Frequencia,
                DataInicio = addedEmenta.DataInicio,
                DataFim = addedEmenta.DataFim,
                TipoRefeicao = addedEmenta.TipoRefeicao,
                Quantidade = addedEmenta.Quantidade
            };
        }


        public async Task<bool> DeleteEmenta(long id)
        {
            var ementa = await _repo.GetEmentaById(id);
            if (ementa == null) return false;

            await _repo.RemoveEmenta(ementa);
            return true;
        }


    }




}
