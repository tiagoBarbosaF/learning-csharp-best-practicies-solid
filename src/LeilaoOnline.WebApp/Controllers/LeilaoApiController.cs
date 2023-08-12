using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        ILeilaoDao _leilaoDao;

        public LeilaoApiController(ILeilaoDao leilaoDao)
        {
            _leilaoDao = leilaoDao;
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