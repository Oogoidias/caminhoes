using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoRepositorySalvar
    {
        [Fact]
        public void VerificarSeEstaInserindo() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);

            var dbSet = contexto.Set<Caminhao>();

            Caminhao caminhao = new Caminhao("Nome 2", 2020, 2020,
                new CaminhaoModelo("FM", true));
            //act
            repo.Salvar(caminhao, 0);
            
            //assert
            Assert.Equal(1, dbSet.Count());
        }
    }
}
