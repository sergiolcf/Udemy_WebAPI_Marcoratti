using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExerc.Model
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(18)]
        public string CNPJ { get; set; }

        public Endereco? Endereco { get; set; }

        [ForeignKey("Contato")]
        public Contato Contato_Principal { get; set; }

        public ICollection<Contato>? Contato { get; set; }

        public Conta()
        {
            Endereco = new Endereco();
            Contato = new Collection<Contato>();
        }
    }
}
