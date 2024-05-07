using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiExecUm.Model
{
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public int? ContatoPrimarioId { get; set; }
        public Contato? ContatoPrimario { get; set; }
        public Endereco? Endereco { get; set; }

        [JsonIgnore]
        public ICollection<Contato>? ContatoList { get; set; }

        public Conta()
        {
            ContatoList = new List<Contato>();
        }
    }
}