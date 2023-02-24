using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_USERNAMES")]
    public partial class BdpfUsername
    {
        [Key]
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Required]
        [Column("USER_NAME")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Column("USER_ROLE")]
        public int? UserRole { get; set; }

        [ForeignKey(nameof(UserRole))]
        [InverseProperty(nameof(BdpfUserrole.BdpfUsernames))]
        public virtual BdpfUserrole UserRoleNavigation { get; set; }
    }
}
