using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("B_ROLECLAIMS")]
    [Index(nameof(Roleid), Name = "IX_B_ROLECLAIMS_ROLEID")]
    public partial class BRoleclaim
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ROLEID")]
        public int Roleid { get; set; }
        [Column("CLAIMTYPE")]
        public string Claimtype { get; set; }
        [Column("CLAIMVALUE")]
        public string Claimvalue { get; set; }

        [ForeignKey(nameof(Roleid))]
        [InverseProperty(nameof(BRole.BRoleclaims))]
        public virtual BRole Role { get; set; }
    }
}
