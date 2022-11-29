using System;

namespace TCC.Domain.DTO
{
    public class ReclamacaoDTO : BaseDTO
    {
        public int AreaID { get; set; }
        public string Descricao { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public DateTime DataHora { get; set; }
        public string DataString { get; set; }
        public string Estado { get; set; }
        public string NomeUsuario { get; set; }
        public bool Ativa { get; set; }
        public AreaDTO Area { get; set; }

        public ReclamacaoDTO()
        {
            Area = new AreaDTO();
        }
    }
}
