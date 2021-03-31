using System.Collections.Generic;
using Domain;

namespace CadastroCaminhoes.Models.ViewModels
{
    public class VisualizarViewModel
    {
        public VisualizarViewModel()
        {
        }

        public IList<Caminhao> listaCaminhao { get; set; }
        public int TotalCaminhao { get; set; }
    }
}
