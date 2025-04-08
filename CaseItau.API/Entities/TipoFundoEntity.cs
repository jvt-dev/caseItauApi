using System.ComponentModel.DataAnnotations;

namespace CaseItau.API.Entities
{
    public class TipoFundoEntity
    {
        [Key]
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
    }
}
