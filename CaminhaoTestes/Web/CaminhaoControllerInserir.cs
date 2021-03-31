using CadastroCaminhoes.Controllers;
using CadastroCaminhoes.Models.ViewModels;
using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoControllerInserir
    {
        [Fact]
        public void VerificarSeInclui() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
               .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
               .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);

            Caminhao caminhao = new Caminhao("Nome 1", 2020, 2021,
                new CaminhaoModelo("FH", true));

            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.idCaminhao = 0;
            cadastroViewModel.caminhao = caminhao;

            var dbSet = contexto.Set<Caminhao>();

            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repo
                );

            //act
            caminhaoController.Inserir(cadastroViewModel);

            //assert
            Assert.Equal(1, dbSet.Count());
        }

        [Fact]
        public void VerificarQuandoGeraException()
        {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);

            Caminhao caminhao = new Caminhao("Nome 1", 2020, 2021,
                new CaminhaoModelo("FH", true));

            var mock = new Mock<ICaminhaoRepository>();
            mock.Setup(r => r.Salvar(caminhao, 0)).Throws(new Exception("Erro"));
            var repo = mock.Object;


            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repo
                );

            CadastroViewModel cadastroViewModel = new CadastroViewModel();
            cadastroViewModel.idCaminhao = 0;
            cadastroViewModel.caminhao = caminhao;

            //act
            var resultado = caminhaoController.Inserir(cadastroViewModel) as RedirectToActionResult;

            //assert
            Assert.Equal("Error", resultado.ActionName);
        }
    }
}
