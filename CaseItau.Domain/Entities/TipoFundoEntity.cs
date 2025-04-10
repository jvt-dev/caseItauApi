using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseItau.API.Domain.Entities
{
    [Table("TIPO_FUNDO")]
    public class TipoFundoEntity
    {
        [Key]
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
    }
}
