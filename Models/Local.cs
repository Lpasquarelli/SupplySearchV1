using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Models
{
    [Table("LocalEstoque")]
    public class Local
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Cpf")]
        public string Cpf { get; set; }
        [Column("RazaoSocial")]
        public string RazaoSocial { get; set; }
        [Column("endereco")]
        public string endereco { get; set; }
        [Column("numero")]
        public int numero { get; set; }
        [Column("complemento")]
        public string? complemento { get; set; }
        [Column("telefone")]
        public string telefone { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }
    }
}
