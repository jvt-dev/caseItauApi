namespace CaseItau.API.Shared.Models
{
    public class FundoModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal? Patrimonio { get; set; }
        public int CodigoTipo { get; set; }
    }
}
