using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiExecUm.Model
{
    [Index(nameof(CPF), IsUnique = true)]
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

        [Required]
        [StringLengthAttribute(14)]
        public string CPF { get; set; }

        [StringLength(300)]
        public string Cidade { get; set; }

        [JsonIgnore]
        public Conta? Empresa { get; set; }

        [JsonIgnore]
        public Endereco? Endereco { get; set; }
    }
}
