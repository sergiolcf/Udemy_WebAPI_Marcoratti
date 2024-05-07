﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiExecUm.Model
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Nome { get; set; }

        [Required]
        [StringLength(180)]
        public string SobreNome { get; set; }

        [Required]
        [StringLengthAttribute(14)]
        public string CPF { get; set; }

        public int? ContaID { get; set; }

        [JsonIgnore]
        public Conta? Empresa { get; set; }

        [JsonIgnore]
        public Endereco? Endereco { get; set; }
    }
}
