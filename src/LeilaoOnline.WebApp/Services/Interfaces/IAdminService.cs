using System.Collections.Generic;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Categoria> GetCategorias();

        IEnumerable<Leilao> GetLeiloes();

        Leilao GetLeilaoById(int id);

        void RecordLeilao(Leilao leilao);

        void UpdateLeilao(Leilao leilao);

        void RemoveLeilao(Leilao leilao);

        void InitiatePregaoWithId(int id);

        void FinishPregaoWithId(int id);
    }
}