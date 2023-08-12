using System.Collections.Generic;
using System.Linq;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDaoWithEfCore : ICategoriaDao
    {
        private AppDbContext _context;

        public CategoriaDaoWithEfCore(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.Include(c => c.Leiloes);
        }

        public Categoria GetById(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }
    }
}