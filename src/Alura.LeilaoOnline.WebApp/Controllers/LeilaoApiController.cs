﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;
        private LeilaoDao _leilaoDao;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
            _leilaoDao = new LeilaoDao();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _leilaoDao.GetLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null)
            {
                return NotFound();
            }

            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _leilaoDao.Record(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _leilaoDao.Update(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _leilaoDao.GetById(id);
            if (leilao == null)
            {
                return NotFound();
            }

            _leilaoDao.Remove(leilao);
            return NoContent();
        }
    }
}