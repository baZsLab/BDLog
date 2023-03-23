using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("USR_ROLE")]
    [Index(nameof(Normalizedname), Name = "RoleNameIndex", IsUnique = true)]
    public partial class UsrRole
    {
        public UsrRole()
        {
            UsrRoleclaims = new HashSet<UsrRoleclaim>();
            UsrUserroles = new HashSet<UsrUserrole>();
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

        [InverseProperty(nameof(UsrRoleclaim.Role))]
        public virtual ICollection<UsrRoleclaim> UsrRoleclaims { get; set; }
        [InverseProperty(nameof(UsrUserrole.Role))]
        public virtual ICollection<UsrUserrole> UsrUserroles { get; set; }
    }
}
