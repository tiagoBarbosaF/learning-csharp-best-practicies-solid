using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Dados.Interfaces;

namespace LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        private ILeilaoDao _leilaoDao;

        public LeilaoController(ILeilaoDao leilaoDao)
        {
            _leilaoDao = leilaoDao;
        }


        public IActionResult Index()
        {
            var leiloes = _leilaoDao.GetLeiloes();
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _leilaoDao.GetCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _leilaoDao.Record(model);
                return RedirectToAction("Index");
            }

            ViewData["Categorias"] = _leilaoDao.GetCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _leilaoDao.GetCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _leilaoDao.Update(model);
                return RedirectToAction("Index");
            }

            ViewData["Categorias"] = _leilaoDao.GetCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _leilaoDao.Update(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _leilaoDao.Update(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _leilaoDao.Remove(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _leilaoDao.GetLeiloes()
                .Where(l => string.IsNullOrWhiteSpace(termo) ||
                            l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                            l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                            l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}