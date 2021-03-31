using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class CaminhaoRepository : BaseRepository<Caminhao>, ICaminhaoRepository
    {
        private readonly ICaminhaoModeloRepository caminhaoModeloRepository;

        public CaminhaoRepository(CaminhaoContext contexto,
            ICaminhaoModeloRepository caminhaoModeloRepository) : base(contexto)
        {
            this.caminhaoModeloRepository = caminhaoModeloRepository;
        }

        public void Excluir(int id)
        {
            Caminhao caminhao = dbSet.Where(c => c.id == id).First();
            dbSet.Remove(caminhao);
            contexto.SaveChanges();
        }

        public void Salvar(Caminhao caminhao, int id)
        {
            caminhao.caminhaoModelo = caminhaoModeloRepository.ListarPorSigla(caminhao.caminhaoModelo.sigla);
            InsereOuAtualiza(caminhao, id);
            contexto.SaveChanges();
        }

        private void InsereOuAtualiza(Caminhao caminhao, int id)
        {
            if (id > 0)
            {
                Caminhao caminhaoParaAtualizar = dbSet.Where(c => c.id == id).First();
                caminhaoParaAtualizar.Atualizar(caminhao);
                dbSet.Update(caminhaoParaAtualizar);
            }
            else
                dbSet.Add(caminhao);
        }

        public Caminhao ListarPorID(int id)
        {
            if (id > 0)
                return dbSet.Where(c => c.id == id).SingleOrDefault();
            else
                return new Caminhao();
        }

        public IList<Caminhao> ListarTodos()
        {
            return dbSet.Include(c => c.caminhaoModelo).ToList();
        }
    }
}
