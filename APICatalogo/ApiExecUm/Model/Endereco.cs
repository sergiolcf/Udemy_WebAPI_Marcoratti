using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiExecUm.Model
{
    [Owned]
    public class Endereco
    {
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(150)]
        public string Logradouro { get; set; }

        [StringLength(14)]
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
    }
}