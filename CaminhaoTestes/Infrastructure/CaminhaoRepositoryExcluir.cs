using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoRepositoryExcluir
    {
        [Fact]
        public void VerificarSeSeExcluiu() {
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

            //act
            repo.Excluir(caminhao.id);
            
            //assert
            Assert.Equal(0, dbSet.Where(c => c.id == id).Count());
        }
    }
}
