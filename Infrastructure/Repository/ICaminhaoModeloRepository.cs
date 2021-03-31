using Domain;
using System.Collections.Generic;

namespace Infrastucture.Repositories
{
    public interface ICaminhaoModeloRepository
    {
        IList<CaminhaoModelo> ListarCaminhaoModeloAtivo();
        CaminhaoModelo ListarPorSigla(string sigla);
        void PopularDados();
    }
}