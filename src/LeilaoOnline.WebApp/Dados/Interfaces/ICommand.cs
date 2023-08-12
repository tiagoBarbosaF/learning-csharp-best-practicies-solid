using System.Collections.Generic;

namespace LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ICommand<T>
    {
        void Record(T obj);

        void Update(T obj);

        void Remove(T obj);
    }
}