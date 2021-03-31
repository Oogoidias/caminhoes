using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoModeloRepositoryPopulaDados
    {
        [Fact]
        public void VerificarSePopulouComDados() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repo = new CaminhaoModeloRepository(contexto);

            //act
            repo.PopularDados();
            
            //assert
            var dbSet = contexto.Set<CaminhaoModelo>();
            Assert.True(dbSet.Count() > 0);
        }
    }
}
