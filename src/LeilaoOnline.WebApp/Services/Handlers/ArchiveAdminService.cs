using System.Linq;
using System.Collections.Generic;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Services.Interfaces;

namespace LeilaoOnline.WebApp.Services.Handlers
{
    public class ArchiveAdminService : IAdminService
    {
        private IAdminService _defaultAdminService;

        public ArchiveAdminService(ILeilaoDao leilaoDao)
        {
            _defaultAdminService = new DefaultAdminService(leilaoDao);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _defaultAdminService.GetCategorias();
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            return _defaultAdminService.GetLeiloes().Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public Leilao GetLeilaoById(int id)
        {
            return _defaultAdminService.GetLeilaoById(id);
        }

        public void RecordLeilao(Leilao leilao)
        {
            _defaultAdminService.RecordLeilao(leilao);
        }

        public void UpdateLeilao(Leilao leilao)
        {
            _defaultAdminService.UpdateLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultAdminService.UpdateLeilao(leilao);
            }
        }

        public void InitiatePregaoWithId(int id)
        {
            _defaultAdminService.InitiatePregaoWithId(id);
        }

        public void FinishPregaoWithId(int id)
        {
            _defaultAdminService.FinishPregaoWithId(id);
        }
    }
}