using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("B_USERLOGINS")]
    [Index(nameof(Userid), Name = "IX_B_USERLOGINS_USERID")]
    public partial class BUserlogin
    {
        [Key]
        [Column("LOGINPROVIDER")]
        [StringLength(128)]
        public string Loginprovider { get; set; }
        [Key]
        [Column("PROVIDERKEY")]
        [StringLength(128)]
        public string Providerkey { get; set; }
        [Column("PROVIDERDISPLAYNAME")]
        public string Providerdisplayname { get; set; }
        [Column("USERID")]
        public int Userid { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(BUser.BUserlogins))]
        public virtual BUser User { get; set; }
    }
}
