using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.WebApp.Controllers;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Services.Interfaces;

namespace LeilaoOnline.Testes
{
    public class LeilaoControllerRemove
    {

        private IAdminService _adminService;
        private LeilaoController controller;

        public LeilaoControllerRemove(IAdminService adminService)
        {
            _adminService = adminService;
            controller = new LeilaoController(_adminService);
        }

        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual é inexistente!! teste deixa de ser automático...
            var actionResultEsperado = typeof(NotFoundResult);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna405()
        {
            // arrange
            var idLeilaoEmPregao = 11232; // qual leilao está em pregão???!! 
            var actionResultEsperado = typeof(StatusCodeResult);

            // act
            var result = controller.Remove(idLeilaoEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 11232; // qual leilao está em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
