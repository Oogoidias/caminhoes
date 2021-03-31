using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoModeloRepositoryListarPorSigla
    {
        [Fact]
        public void VerificaSeListaPorSigla() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repo = new CaminhaoModeloRepository(contexto);
            var sigla = "FM";

            var dbSet = contexto.Set<CaminhaoModelo>();
            dbSet.Add(new CaminhaoModelo(sigla, true));
            dbSet.Add(new CaminhaoModelo("FG", true));
            dbSet.Add(new CaminhaoModelo("RT", true));
            contexto.SaveChanges();

            //act
            CaminhaoModelo caminhaoModelo = repo.ListarPorSigla(sigla);
            
            //assert
            Assert.Equal(sigla, caminhaoModelo.sigla);
        }
    }
}
