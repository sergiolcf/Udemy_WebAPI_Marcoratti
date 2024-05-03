using System.ComponentModel.DataAnnotations;

namespace ApiExecUm.Model
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(150)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(14)]
        public string CEP { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

    }
}
