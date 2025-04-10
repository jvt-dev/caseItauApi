using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseItau.API.Domain.Entities
{
    [Table("FUNDO")]
    public class FundoEntity
    {
        [Key]
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public decimal? Patrimonio { get; private set; }
        
        [Column("CODIGO_TIPO")]
        public int CodigoTipo { get; private set; }

        public void UpdatePatrimonio(decimal patrimonio)
        {
            Patrimonio += patrimonio;
        }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public void UpdateCnpj(string cnpj)
        {
            Cnpj = cnpj;
        }

        public void UpdateCodigoTipo(int codigoTipo)
        {
            CodigoTipo = codigoTipo;
        }
    }
}
