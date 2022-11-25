
using System;

namespace TCC.Domain.Entity
{
    public class ReclamacoesEntity : BaseEntity
    {
        public int AreaID { get; set; }
        public string Descricao { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public DateTime DataHora { get; set; }
        public string Estado { get; set; }
        public string NomeUsuario { get; set; }
        public bool Ativa { get; set; }
        public AreaEntity Area { get; set; }

        public ReclamacoesEntity()
        {
            Area = new AreaEntity();
        }

    }
}
