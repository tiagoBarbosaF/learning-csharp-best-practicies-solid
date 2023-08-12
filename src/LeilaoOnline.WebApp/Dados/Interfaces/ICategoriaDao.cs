using System.Collections.Generic;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> GetCategorias();

        Categoria GetCategoriasById(int id);
    }
}