using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_MC")]
    public partial class BdpfMc
    {
        public BdpfMc()
        {
            BdpfMcunits = new HashSet<BdpfMcunit>();
        }

        [Key]
        [Column("MC_ID")]
        public int McId { get; set; }
        [Required]
        [Column("MC_NAME")]
        [StringLength(50)]
        public string McName { get; set; }
        [Column("MC_CELL")]
        public int McCell { get; set; }
        [Column("MC_INACTIVE")]
        public bool? McInactive { get; set; }

        [ForeignKey(nameof(McCell))]
        [InverseProperty(nameof(BdpfCell.BdpfMcs))]
        public virtual BdpfCell McCellNavigation { get; set; }
        [InverseProperty(nameof(BdpfMcunit.UnitMcNavigation))]
        public virtual ICollection<BdpfMcunit> BdpfMcunits { get; set; }
    }
}
