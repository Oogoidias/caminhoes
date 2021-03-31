using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CaminhaoTestes
{
    public class CaminhaoModeloCaminhaoModelo
    {
        [Fact]
        public void ConstrutorFuncionaComOsParametros()
        {
            //arrange
            String sigla = "FM";
            bool ativo = true;

            //act
            CaminhaoModelo caminhaoModelo = new CaminhaoModelo(sigla, ativo);

            //assert
            Assert.Equal(caminhaoModelo.sigla, sigla);
            Assert.Equal(caminhaoModelo.ativo, ativo);
        }
    }
}
