﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("USR_USERCLAIMS")]
    [Index(nameof(Userid), Name = "IX_USR_USERCLAIMS_USERID")]
    public partial class UsrUserclaim
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("USERID")]
        public int Userid { get; set; }
        [Column("CLAIMTYPE")]
        public string Claimtype { get; set; }
        [Column("CLAIMVALUE")]
        public string Claimvalue { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty(nameof(UsrUser.UsrUserclaims))]
        public virtual UsrUser User { get; set; }
    }
}
