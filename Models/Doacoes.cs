using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Models
{
    [Table("Doacoes")]
    public class Doacoes
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Produto")]
        public string Produto { get; set; }
        [Column("Quantidade")]
        public int Quantidade { get; set; }
        [Column("UnidadeMedida")]
        public string UnidadeMedida { get; set; }
        [Column("DiaEntrega")]
        public DateTime DiaEntrega { get; set; }
        [Column("IDLocal")]
        public int IDLocal { get; set; }
        [Column("IDDoador")]
        public int IDDoador { get; set; }
        [Column("idDonatario")]
        public int? idDonatario { get; set; }

        [NotMapped]
        public Donatario Donatario { get; set; }

        [NotMapped]
        public Local LocalEntrega { get; set; }
    }
}
