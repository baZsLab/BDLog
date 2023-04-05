using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("B_ROLE")]
    [Index(nameof(Normalizedname), Name = "RoleNameIndex", IsUnique = true)]
    public partial class BRole
    {
        public BRole()
        {
            BRoleclaims = new HashSet<BRoleclaim>();
            BUserroles = new HashSet<BUserrole>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(256)]
        public string Name { get; set; }
        [Column("NORMALIZEDNAME")]
        [StringLength(256)]
        public string Normalizedname { get; set; }
        [Column("CONCURRENCYSTAMP")]
        public string Concurrencystamp { get; set; }

        [InverseProperty(nameof(BRoleclaim.Role))]
        public virtual ICollection<BRoleclaim> BRoleclaims { get; set; }
        [InverseProperty(nameof(BUserrole.Role))]
        public virtual ICollection<BUserrole> BUserroles { get; set; }
    }
}
