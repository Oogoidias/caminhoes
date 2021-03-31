using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoModeloRepositoryListarCaminhaoModeloAtivo
    {
        [Fact]
        public void VerificaSeListaApenasAtivos() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repo = new CaminhaoModeloRepository(contexto);

            var dbSet = contexto.Set<CaminhaoModelo>();

            dbSet.Add(new CaminhaoModelo("FM", true));
            dbSet.Add(new CaminhaoModelo("FH", true));
            dbSet.Add(new CaminhaoModelo("EI", false));
            dbSet.Add(new CaminhaoModelo("DS", false));
            dbSet.Add(new CaminhaoModelo("KJ", false));
            contexto.SaveChanges();

            //act
            IList<CaminhaoModelo> listaCaminhaoModelo = repo.ListarCaminhaoModeloAtivo();
            
            //assert
            Assert.Equal(2, listaCaminhaoModelo.Count());
        }
    }
}
