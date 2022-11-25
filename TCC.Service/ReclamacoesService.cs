using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Domain.DTO;
using TCC.Domain.Entity;
using TCC.Repository;

namespace TCC.Service
{
    public class ReclamacoesService
    {
        private readonly ReclamacaoRepository _reclamacaoRepository;
        public ReclamacoesService()
        {
            _reclamacaoRepository = new ReclamacaoRepository();
        }
        public async Task<List<ReclamacaoDTO>> BuscarTodas()
        {
            try
            {
                List<ReclamacaoDTO> reclame = new List<ReclamacaoDTO>();
                var reclamacoes = await _reclamacaoRepository.BuscarTodas();
                foreach (var reclamacao in reclamacoes)
                {
                    ReclamacaoDTO rec = new ReclamacaoDTO()
                    {
                        Area = new AreaDTO()
                        {
                            Descricao = reclamacao.Area.Descricao
                        },
                        Descricao = reclamacao.Descricao,
                        AreaID = reclamacao.AreaID,
                        Ativa = reclamacao.Ativa,
                        Cidade = reclamacao.Cidade,
                        DataHora = reclamacao.DataHora,
                        Estado = reclamacao.Estado,
                        ID = reclamacao.ID,
                        NomeUsuario = reclamacao.NomeUsuario,
                        Rua = reclamacao.Rua
                    };
                    reclame.Add(rec);
                }
                return reclame;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<ReclamacaoDTO>> BuscarTodasAtivas()
        {
            try
            {
                List<ReclamacaoDTO> reclame = new List<ReclamacaoDTO>();
                var reclamacoes = await _reclamacaoRepository.BuscarTodasAtivas();
                foreach (var reclamacao in reclamacoes)
                {
                    ReclamacaoDTO rec = new ReclamacaoDTO()
                    {
                        Area = new AreaDTO()
                        {
                            Descricao = reclamacao.Area.Descricao
                        },
                        Descricao = reclamacao.Descricao,
                        AreaID = reclamacao.AreaID,
                        Ativa = reclamacao.Ativa,
                        Cidade = reclamacao.Cidade,
                        DataHora = reclamacao.DataHora,
                        Estado = reclamacao.Estado,
                        ID = reclamacao.ID,
                        NomeUsuario = reclamacao.NomeUsuario,
                        Rua = reclamacao.Rua
                    };
                    reclame.Add(rec);
                }
                return reclame;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ReclamacaoDTO> BuscarPorID(int id)
        {
            try
            {
                var reclamacao = await _reclamacaoRepository.BuscarPorID(id);

                ReclamacaoDTO rec = new ReclamacaoDTO()
                {
                    Area = new AreaDTO()
                    {
                        Descricao = reclamacao.Area.Descricao
                    },
                    Descricao = reclamacao.Descricao,
                    AreaID = reclamacao.AreaID,
                    Ativa = reclamacao.Ativa,
                    Cidade = reclamacao.Cidade,
                    DataHora = reclamacao.DataHora,
                    Estado = reclamacao.Estado,
                    ID = reclamacao.ID,
                    NomeUsuario = reclamacao.NomeUsuario,
                    Rua = reclamacao.Rua
                };

                return rec;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task ConcluirReclamacao(int id)
        {
            try
            {
                await _reclamacaoRepository.ConcluirReclamacao(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<ReclamacaoDTO>> BuscarTodasConcluidas()
        {
            try
            {
                List<ReclamacaoDTO> reclame = new List<ReclamacaoDTO>();
                var reclamacoes = await _reclamacaoRepository.BuscarTodasConcluidas();
                foreach (var reclamacao in reclamacoes)
                {
                    ReclamacaoDTO rec = new ReclamacaoDTO()
                    {
                        Area = new AreaDTO()
                        {
                            Descricao = reclamacao.Area.Descricao
                        },
                        Descricao = reclamacao.Descricao,
                        AreaID = reclamacao.AreaID,
                        Ativa = reclamacao.Ativa,
                        Cidade = reclamacao.Cidade,
                        DataHora = reclamacao.DataHora,
                        Estado = reclamacao.Estado,
                        ID = reclamacao.ID,
                        NomeUsuario = reclamacao.NomeUsuario,
                        Rua = reclamacao.Rua
                    };
                    reclame.Add(rec);
                }
                return reclame;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> BuscarSAE()
        {
            try
            {
                var quantidade = await _reclamacaoRepository.BuscarSAE();
                return quantidade;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> BuscarSaude()
        {
            try
            {
                var quantidade = await _reclamacaoRepository.BuscarSaude();
                return quantidade;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> BuscarCFPL()
        {
            try
            {
                var quantidade = await _reclamacaoRepository.BuscarCFPL();
                return quantidade;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> BuscarOutros()
        {
            try
            {
                var quantidade = await _reclamacaoRepository.BuscarOutros();
                return quantidade;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
