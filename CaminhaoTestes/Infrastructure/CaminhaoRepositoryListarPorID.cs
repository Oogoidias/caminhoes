using Domain;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoRepositoryListarPorID
    {
        [Fact]
        public void VerificarSeListaPorID() {
            //arrange
            var options = new DbContextOptionsBuilder<CaminhaoContext>()
                .UseInMemoryDatabase("CaminhaoContext_" + DateTime.Now.ToFileTimeUtc())
                .Options;
            var contexto = new CaminhaoContext(options);
            var repoCaminhaoModelo = new CaminhaoModeloRepository(contexto);
            var repo = new CaminhaoRepository(contexto, repoCaminhaoModelo);
            
            var dbSet = contexto.Set<Caminhao>();

            int id = 0;
            String nome = "Nome 1";
            int anoFabricacao = 2020;
            int AnoModelo = 2021;

            Caminhao caminhao = new Caminhao(nome, anoFabricacao, AnoModelo,
                new CaminhaoModelo("FH", true));

            dbSet.Add(caminhao);
            dbSet.Add(new Caminhao("Nome 2", 2020, 2020,
                new CaminhaoModelo("FM", true)));
            dbSet.Add(new Caminhao("Nome 3", 2019, 2020,
                new CaminhaoModelo("TR", true)));
            dbSet.Add(new Caminhao("Nome 4", 2019, 2019,
                new CaminhaoModelo("GT", true)));
            contexto.SaveChanges();

            id = caminhao.id;

            //act
            var caminhaoInserido = repo.ListarPorID(id);
            
            //assert
            Assert.Equal(nome, caminhaoInserido.nome);
            Assert.Equal(anoFabricacao, caminhaoInserido.anoFabricacao);
            Assert.Equal(AnoModelo, caminhaoInserido.anoModelo);
        }
    }
}
