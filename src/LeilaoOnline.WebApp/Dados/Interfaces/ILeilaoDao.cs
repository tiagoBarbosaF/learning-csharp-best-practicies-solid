using System.Collections.Generic;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDao : ICommand<Leilao>, IQuery<Leilao>
    {
    }
}