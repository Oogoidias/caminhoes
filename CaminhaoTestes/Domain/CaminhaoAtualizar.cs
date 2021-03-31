using Domain;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoAtualizar
    {
        [Fact]
        public void VerificarSeOObjetoFoiAtualizado() {
            //arrange
            Caminhao caminhao = new Caminhao("Nome 1", 2019, 2019, new CaminhaoModelo("FM", true));
            Caminhao caminhaoNovo = new Caminhao("Nome 2", 2021, 2021, new CaminhaoModelo("FH", true));

            //act
            caminhao.Atualizar(caminhaoNovo);

            //assert
            Assert.Equal(caminhao.nome, caminhaoNovo.nome);
            Assert.Equal(caminhao.anoFabricacao, caminhaoNovo.anoFabricacao);
            Assert.Equal(caminhao.anoModelo, caminhaoNovo.anoModelo);
            Assert.Equal(caminhao.caminhaoModelo , caminhaoNovo.caminhaoModelo);
        }
    }
}
