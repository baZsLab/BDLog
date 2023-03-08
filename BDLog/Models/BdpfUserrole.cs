using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_USERROLES")]
    public partial class BdpfUserrole
    {
        public BdpfUserrole()
        {
            BdpfUsernames = new HashSet<BdpfUsername>();
        }

        [Key]
        [Column("ROLE_ID")]
        public int RoleId { get; set; }
        [Column("ROLE_NAME")]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(BdpfUsername.UserRoleNavigation))]
        public virtual ICollection<BdpfUsername> BdpfUsernames { get; set; }
    }
}
