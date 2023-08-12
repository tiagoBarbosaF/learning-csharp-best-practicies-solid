using System.Collections.Generic;

namespace LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}