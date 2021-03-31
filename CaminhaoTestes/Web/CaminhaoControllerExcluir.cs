using CadastroCaminhoes.Controllers;
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
    public class CaminhaoControllerExcluir
    {
        [Fact]
        public void VerificarSeExclui() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
               .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
               .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);

            Caminhao caminhao = new Caminhao("Nome 1", 2020, 2021,
                new CaminhaoModelo("FH", true));

            var dbSet = contexto.Set<Caminhao>();
            dbSet.Add(caminhao);
            contexto.SaveChanges();

            var id = caminhao.id;

            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repo
                );

            //act
            caminhaoController.Excluir(caminhao.id);

            //assert
            Assert.Equal(0, dbSet.Where(c => c.id == id).Count());
        }

        [Fact]
        public void VerificarViewResultado()
        {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repoCaminhao = new CaminhaoRepository(contexto, repoCaminhaoModelo);

            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repoCaminhao
                );

            Caminhao caminhao = new Caminhao("Nome 1", 2020, 2021,
               new CaminhaoModelo("FH", true));

            var dbSet = contexto.Set<Caminhao>();
            dbSet.Add(caminhao);
            contexto.SaveChanges();

            var id = caminhao.id;

            //act
            var resultado = caminhaoController.Excluir(caminhao.id) as RedirectToActionResult;

            //assert
            Assert.Equal("Visualizar", resultado.ActionName);
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

            var mock = new Mock<ICaminhaoRepository>();
            mock.Setup(r => r.Excluir(0)).Throws(new Exception("Erro"));
            var repo = mock.Object;

            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repo
                );

            //act
            var resultado = caminhaoController.Excluir(0) as RedirectToActionResult;

            //assert
            Assert.Equal("Error", resultado.ActionName);
        }
    }
}
