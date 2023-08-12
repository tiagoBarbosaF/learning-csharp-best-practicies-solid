using System.Collections.Generic;
using System.Linq;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDaoWithEfCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoWithEfCore(AppDbContext context)
        {
            _context = context;
        }

        public Leilao GetById(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public IEnumerable<Leilao> GetAll()
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