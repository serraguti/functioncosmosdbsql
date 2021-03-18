using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControlCochesCosmosSql.Models
{
    [Table("COCHESCOSMOS")]
    public class Coche
    {
        [Key]
        [Column("IDCOCHE")]
        public String Id { get; set; }
        [Column("MARCA")]
        public String Marca { get; set; }
        [Column("MODELO")]
        public String Modelo { get; set; }
        [Column("ESTADO")]
        public String Estado { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("VELOCIDAD")]
        public int Velocidad { get; set; }
    }
}
