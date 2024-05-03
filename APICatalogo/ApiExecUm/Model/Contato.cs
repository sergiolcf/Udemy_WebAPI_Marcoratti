using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiExecUm.Model
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Nome { get; set; }

        [Required]
        [StringLength(180)]
        public string SobreNome { get; set; }

        [JsonIgnore]
        public Conta Empresa { get; set; }

        [JsonIgnore]
        public Endereco Endereco { get; set; }

    }
}
