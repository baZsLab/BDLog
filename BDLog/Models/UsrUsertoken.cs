using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("USR_USERTOKENS")]
    public partial class UsrUsertoken
    {
        [Key]
        [Column("USERID")]
        public int Userid { get; set; }
        [Key]
        [Column("LOGINPROVIDER")]
        [StringLength(128)]
        public string Loginprovider { get; set; }
        [Key]
        [Column("NAME")]
        [StringLength(128)]
        public string Name { get; set; }
        [Column("VALUE")]
        public string Value { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(UsrUser.UsrUsertokens))]
        public virtual UsrUser User { get; set; }
    }
}
