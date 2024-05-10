using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_Exec_2.Model
{
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [StringLength(18)]
        public string CNPJ { get; set; }

        public Endereco? Endereco { get; set; }

        public int? ContatoPrimarioId { get; set; }
        public Contato? ContatoPrimario { get; set; }

        public ICollection<Contato>? ListaContatos { get; set; }

        public Conta()
        {
            ListaContatos = new List<Contato>();
        }
    }
}