using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VP_Felho.Models
{
    [Index(nameof(felhasznalo_id), Name = "felhasznalo_id")]
    [Table("fajl")]
    public partial class Fajl
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string fajlnev { get; set; }
        [Required]
        [StringLength(50)]
        public string kiterjesztes { get; set; }
        [Required]
        public byte[] adat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime datum { get; set; }
        [Column(TypeName = "int(11)")]
        public int felhasznalo_id { get; set; }

        [ForeignKey(nameof(felhasznalo_id))]
        [InverseProperty("fajl")]
        public virtual Felhasznalo felhasznalo { get; set; }
    }
}
