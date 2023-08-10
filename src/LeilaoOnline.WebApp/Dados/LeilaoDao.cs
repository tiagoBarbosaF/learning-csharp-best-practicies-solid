using System.Collections.Generic;
using System.Linq;
using LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Leilao GetById(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            return _context.Leiloes.Include(l => l.Categoria).ToList();
        }

        public void Record(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Update(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Remove(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}