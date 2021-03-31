using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class CaminhaoModeloRepository : BaseRepository<CaminhaoModelo>, ICaminhaoModeloRepository
    {
        public CaminhaoModeloRepository(CaminhaoContext contexto) : base(contexto)
        {
        }

        public IList<CaminhaoModelo> ListarCaminhaoModeloAtivo()
        {
            return dbSet.Where(cm => cm.ativo == true).ToList();
        }

        public CaminhaoModelo ListarPorSigla(String sigla)
        {
            return dbSet.DefaultIfEmpty(new CaminhaoModelo("FM", true)).Where(cm => cm.sigla == sigla).SingleOrDefault();
        }

        public void PopularDados()
        {
            List<CaminhaoModelo> caminhaoModelo = GerarDados();
            SalvarLista(caminhaoModelo);
        }

        private List<CaminhaoModelo> GerarDados()
        {
            List<CaminhaoModelo> caminhaoModelo = new List<CaminhaoModelo>();

            caminhaoModelo.Add(new CaminhaoModelo("FH", true));
            caminhaoModelo.Add(new CaminhaoModelo("FM", true));
            caminhaoModelo.Add(new CaminhaoModelo("OP", false));
            caminhaoModelo.Add(new CaminhaoModelo("RH", false));
            caminhaoModelo.Add(new CaminhaoModelo("VT", false));
            caminhaoModelo.Add(new CaminhaoModelo("FR", false));
            caminhaoModelo.Add(new CaminhaoModelo("DR", false));

            return caminhaoModelo;
        }

        private void SalvarLista(List<CaminhaoModelo> listaCaminhaoModelo)
        {
            foreach (var caminhaoModelo in listaCaminhaoModelo)
                if (!dbSet.Where(cm => cm.sigla == caminhaoModelo.sigla).Any())
                    dbSet.Add(caminhaoModelo);
            contexto.SaveChanges();
        }
    }
}
