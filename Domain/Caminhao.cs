using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Caminhao : BaseModel
    {
        public Caminhao(String nome, int anoFabricacao, int anoModelo, CaminhaoModelo caminhaoModelo)
        {
            this.nome = nome;
            this.anoFabricacao = anoFabricacao;
            this.anoModelo = anoModelo;
            this.caminhaoModelo = caminhaoModelo;
        }

        public Caminhao() {
            this.caminhaoModelo = new CaminhaoModelo();
        }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Column("Nome", TypeName = "varchar(256)")]
        public String nome { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório")]
        [Column("AnoFabricacao")]
        public int anoFabricacao { get; set; }

        [Required(ErrorMessage = "O ano do modelo é obrigatório")]
        [Column("AnoModelo")]
        public int anoModelo { get; set; }

        public CaminhaoModelo caminhaoModelo { get; set; }

        public void Atualizar(Caminhao caminhao)
        {
            this.nome = caminhao.nome;
            this.anoFabricacao = caminhao.anoFabricacao;
            this.anoModelo = caminhao.anoModelo;
            this.caminhaoModelo = caminhao.caminhaoModelo;
        }
    }
}
