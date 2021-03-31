using Domain;
using System.Collections.Generic;

namespace Infrastucture.Repositories
{
    public interface ICaminhaoRepository
    {
        Caminhao ListarPorID(int id);
        void Salvar(Caminhao caminhao, int id);
        IList<Caminhao> ListarTodos();
        void Excluir(int id);
    }
}