using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("USR_USERROLES")]
    [Index(nameof(Roleid), Name = "IX_USR_USERROLES_ROLEID")]
    public partial class UsrUserrole
    {
        [Key]
        [Column("USERID")]
        public int Userid { get; set; }
        [Key]
        [Column("ROLEID")]
        public int Roleid { get; set; }

        [ForeignKey(nameof(Roleid))]
        [InverseProperty(nameof(UsrRole.UsrUserroles))]
        public virtual UsrRole Role { get; set; }
        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(UsrUser.UsrUserroles))]
        public virtual UsrUser User { get; set; }
    }
}
