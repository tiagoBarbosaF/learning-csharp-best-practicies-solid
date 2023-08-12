using System.Collections.Generic;
using System.Linq;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Services.Interfaces;

namespace LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        private ILeilaoDao _leilaoDao;
        private ICategoriaDao _categoriaDao;

        public DefaultProdutoService(ICategoriaDao categoriaDao, ILeilaoDao leilaoDao)
        {
            _categoriaDao = categoriaDao;
            _leilaoDao = leilaoDao;
        }

        public IEnumerable<Leilao> SearchLeilaoInPregaoByTerm(string term)
        {
            var normalizedTerm = term.ToUpper();

            return _leilaoDao.GetLeiloes().Where(c =>
                c.Titulo.ToUpper().Contains(normalizedTerm) ||
                c.Descricao.ToUpper().Contains(normalizedTerm) ||
                c.Categoria.Descricao.ToUpper().Contains(normalizedTerm));
        }

        public IEnumerable<CategoriaComInfoLeilao> GetCategoriasWithTotalLeiloesInPregao()
        {
            return _categoriaDao.GetCategorias().Select(c => new CategoriaComInfoLeilao
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Imagem = c.Imagem,
                EmRascunho = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Rascunho),
                EmPregao = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Pregao),
                Finalizados = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Finalizado)
            });
        }

        public Categoria GetCategoriaByIdWithLeiloesInPregao(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}