using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_DAMAGECODE")]
    public partial class BdpfDamagecode
    {
        public BdpfDamagecode()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("DMG_ID")]
        public int DmgId { get; set; }
        [Required]
        [Column("DMG_CODE")]
        [StringLength(50)]
        public string DmgCode { get; set; }
        [Required]
        [Column("DMG_NAME")]
        [StringLength(50)]
        public string DmgName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdDmgNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
