using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api_Exec_2.Model
{
    [Owned]
    public class Endereco
    {
        [StringLength(150)]
        public string? Logradouro { get; set; }
        [StringLength(150)]
        public string? Bairro { get; set; }
        public int? Numero { get; set; }

        [StringLength(150)]
        public string? Complemento { get; set; }

        [StringLength(9)]
        public string? CEP { get; set; }
    }
}