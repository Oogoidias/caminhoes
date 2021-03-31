using System;
using System.Collections.Generic;
using Domain;

namespace CadastroCaminhoes.Models.ViewModels
{
    public class CadastroViewModel
    {
        public CadastroViewModel(int id, 
            IList<CaminhaoModelo> listaCaminhaoModelo,
            Caminhao caminhao
            )
        {
            if (id > 0)
            {
                this.ehUpdate = true;
                if (!listaAnoModelo.Contains(caminhao.anoModelo))
                    listaAnoModelo.Add(caminhao.anoModelo);
            }

            this.listaCaminhaoModelo = listaCaminhaoModelo;
            this.caminhao = caminhao;
            this.idCaminhao = id;
        }

        public CadastroViewModel()
        {
        }

        public IList<CaminhaoModelo> listaCaminhaoModelo { get; set; }
        public Caminhao caminhao { get; set; }
        public int anoAtual { get; } = DateTime.Now.Year;
        public IList<int> listaAnoModelo { get; } = new List<int>() { DateTime.Now.Year, DateTime.Now.Year + 1 };
        public bool ehUpdate { get; set; } = false;
        public int idCaminhao { get; set; }
    }
}
