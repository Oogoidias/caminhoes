using Domain;
using System;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoCaminhao
    {
        [Fact]
        public void ConstrutorFuncionaComOsParametros() {
            //arrange
            String nome = "Nome 1";
            int anoFabricacao = 2020;
            int anoModelo = 2021;
            CaminhaoModelo caminhaoModelo = new CaminhaoModelo("FM", true);

            //act
            Caminhao caminhao = new Caminhao(nome, anoFabricacao, anoModelo, caminhaoModelo);

            //assert
            Assert.Equal(caminhao.nome, nome);
            Assert.Equal(caminhao.anoFabricacao, anoFabricacao);
            Assert.Equal(caminhao.anoModelo, anoModelo);
            Assert.Equal(caminhao.caminhaoModelo , caminhaoModelo);
        }
    }
}
