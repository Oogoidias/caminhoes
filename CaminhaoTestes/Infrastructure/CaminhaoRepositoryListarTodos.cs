using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoRepositoryListarTodos
    {
        [Fact]
        public void VerificarSeListaTodos() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);
            
            var dbSet = contexto.Set<Caminhao>();
            
            dbSet.Add(new Caminhao("Nome 1", 2020, 2021,
                new CaminhaoModelo("FH", true)));
            dbSet.Add(new Caminhao("Nome 2", 2020, 2020,
                new CaminhaoModelo("FM", true)));
            dbSet.Add(new Caminhao("Nome 3", 2019, 2020,
                new CaminhaoModelo("TR", true)));
            dbSet.Add(new Caminhao("Nome 4", 2019, 2019,
                new CaminhaoModelo("GT", true)));
            contexto.SaveChanges();

            //act
            var listaCaminhaoTodos = repo.ListarTodos();
            
            //assert
            Assert.Equal(4, listaCaminhaoTodos.Count);
        }
    }
}
