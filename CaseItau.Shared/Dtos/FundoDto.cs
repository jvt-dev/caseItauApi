using CaseItau.Shared.Dtos;

namespace CaseItau.API.Shared.Dtos
{
    public class FundoDto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal? Patrimonio { get; set; }
        public int CodigoTipo { get; set; }
        public TipoFundoDto TipoFundo { get; set; }
    }
}
