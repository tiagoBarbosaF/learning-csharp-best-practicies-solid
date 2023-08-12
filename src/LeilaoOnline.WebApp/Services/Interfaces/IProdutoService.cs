using System.Collections.Generic;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> SearchLeilaoInPregaoByTerm(string term);

        IEnumerable<CategoriaComInfoLeilao> GetCategoriasWithTotalLeiloesInPregao();

        Categoria GetCategoriaByIdWithLeiloesInPregao(int id);
    }
}