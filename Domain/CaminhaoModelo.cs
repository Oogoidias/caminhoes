using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class CaminhaoModelo: BaseModel
    {
       
        public CaminhaoModelo() { }

        public CaminhaoModelo(string sigla, bool ativo)
        {
            this.sigla = sigla;
            this.ativo = ativo;
        }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        [Column("Sigla", TypeName = "varchar(2)")]
        public String sigla { get; set; }
        public bool ativo { get; set; }
    }
}
