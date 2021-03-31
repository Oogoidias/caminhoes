using CadastroCaminhoes.Controllers;
using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoControllerCadastro
    {
       

        public void VerificarViewResultado()
        {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
               .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
               .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);

            CaminhaoController caminhaoController = new CaminhaoController(
                repoCaminhaoModelo,
                repo
                );

            //act
            var resultado = caminhaoController.Cadastro(0) as ViewResult;

            //assert
            Assert.Equal("Cadastro", resultado.ViewName);
        }
    }
}
