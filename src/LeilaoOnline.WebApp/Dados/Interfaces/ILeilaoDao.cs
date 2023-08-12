using System.Collections.Generic;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> GetCategorias();

        Leilao GetById(int id);

        IEnumerable<Leilao> GetLeiloes();

        void Record(Leilao leilao);

        void Update(Leilao leilao);

        void Remove(Leilao leilao);
    }
}