using System.ComponentModel.DataAnnotations;

namespace ApiExerc.Model
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        public int Idade { get; set; }
        public Endereco? Endereco { get; set; }
        public Conta? Conta { get; set; }

        public Contato()
        {
            Endereco = new Endereco();
        }
    }
}
