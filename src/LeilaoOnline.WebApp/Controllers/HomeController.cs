using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Dados.Interfaces;

namespace LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILeilaoDao _leilaoDao;

        public HomeController(ILeilaoDao leilaoDao)
        {
            _leilaoDao = leilaoDao;
        }

        public IActionResult Index()
        {
            var categorias = _leilaoDao.GetCategorias()
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Rascunho),
                    EmPregao = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Pregao),
                    Finalizados = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Finalizado),
                });
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = _leilaoDao.GetCategorias()
                .First(c => c.Id == categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var termoNormalized = termo.ToUpper();
            var leiloes = _leilaoDao.GetLeiloes()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
            return View(leiloes);
        }
    }
}