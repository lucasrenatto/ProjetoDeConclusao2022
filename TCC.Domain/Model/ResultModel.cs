using System.Collections.Generic;
using TCC.Domain.DTO;

namespace TCC.Domain.Model
{
    public class ResultModel
    {
        public List<ReclamacaoDTO> Response{ get; set; }
        public string Message { get; set; }
    }
}
