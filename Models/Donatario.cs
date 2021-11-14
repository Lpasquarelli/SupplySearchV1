using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Models
{
    [Table("Donatario")]
    public class Donatario
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Cpf")]
        public string Cpf { get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("telefone")]
        public string telefone { get; set; }
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }

        [NotMapped]
        public List<Doacoes> Doacoes { get; set; }
    }
}
