using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiExecUm.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [ForeignKey("Contato")]
        public Contato ContatoPrimario { get; set; }

        [JsonIgnore]
        public Endereco Endereco { get; set; }
        public ICollection<Contato> ContatoList { get; set; }

        public Conta()
        {
            ContatoList = new List<Contato>();
        }
    }
}