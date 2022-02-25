using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VP_Felho.Models
{
    [Index(nameof(felhasznalonev), Name = "felhasznalonev", IsUnique = true)]
    [Table("felhasznalo")]
    public partial class Felhasznalo
    {
        public Felhasznalo()
        {
            fajl = new HashSet<Fajl>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string felhasznalonev { get; set; }
        [Required]
        [StringLength(255)]
        public string jelszo { get; set; }

        [InverseProperty("felhasznalo")]
        public virtual ICollection<Fajl> fajl { get; set; }
    }
}
