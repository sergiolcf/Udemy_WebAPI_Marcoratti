using System.ComponentModel.DataAnnotations;

namespace ApiExerc.Model
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        [StringLength(10)]
        public string CEP { get; set; }

        [StringLength(150)]
        public string? Complemento { get; set; }

    }
}
