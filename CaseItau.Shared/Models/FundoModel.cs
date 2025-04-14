using CaseItau.Shared.Validators;
using System.ComponentModel.DataAnnotations;

namespace CaseItau.API.Shared.Models
{
    public class FundoModel
    {
        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Cnpj]
        public string Cnpj { get; set; }
        
        public decimal? Patrimonio { get; set; }

        [Required]
        public int CodigoTipo { get; set; }
        public string NomeTipo { get; set; }
    }
}
