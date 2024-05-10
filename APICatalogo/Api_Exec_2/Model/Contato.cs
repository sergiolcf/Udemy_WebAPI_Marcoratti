using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api_Exec_2.Model
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [StringLength(150)]
        public string SobreNome { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        public int? ContaId { get; set; }
        public Conta? Conta { get; set; }
    }
}