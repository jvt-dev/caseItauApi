using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseItau.API.Entities
{
    public class FundoEntity
    {
        [Key]
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public decimal? Patrimonio { get; private set; }
        
        [ForeignKey("CODIGO_TIPO")]
        public TipoFundoEntity TipoFundo { get; private set; }
    }
}
