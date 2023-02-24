using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_MCUNIT")]
    public partial class BdpfMcunit
    {
        public BdpfMcunit()
        {
            BdpfMcsubunits = new HashSet<BdpfMcsubunit>();
        }

        [Key]
        [Column("UNIT_ID")]
        public int UnitId { get; set; }
        [Required]
        [Column("UNIT_NAME")]
        [StringLength(50)]
        public string UnitName { get; set; }
        [Column("UNIT_SAP")]
        [StringLength(50)]
        public string UnitSap { get; set; }
        [Column("UNIT_MC")]
        public int UnitMc { get; set; }
        [Column("UNIT_INACTIVE")]
        public bool? UnitInactive { get; set; }

        [ForeignKey(nameof(UnitMc))]
        [InverseProperty(nameof(BdpfMc.BdpfMcunits))]
        public virtual BdpfMc UnitMcNavigation { get; set; }
        [InverseProperty(nameof(BdpfMcsubunit.SubMcunitNavigation))]
        public virtual ICollection<BdpfMcsubunit> BdpfMcsubunits { get; set; }
    }
}
