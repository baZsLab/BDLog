using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("B_USERROLES")]
    [Index(nameof(Roleid), Name = "IX_B_USERROLES_ROLEID")]
    public partial class BUserrole
    {
        [Key]
        [Column("USERID")]
        public int Userid { get; set; }
        [Key]
        [Column("ROLEID")]
        public int Roleid { get; set; }

        [ForeignKey(nameof(Roleid))]
        [InverseProperty(nameof(BRole.BUserroles))]
        public virtual BRole Role { get; set; }
        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(BUser.BUserroles))]
        public virtual BUser User { get; set; }
    }
}
