using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_MCSUBUNIT")]
    public partial class BdpfMcsubunit
    {
        public BdpfMcsubunit()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("SUB_ID")]
        public int SubId { get; set; }
        [Required]
        [Column("SUB_NAME")]
        [StringLength(80)]
        public string SubName { get; set; }
        [Column("SUB_SAP")]
        [StringLength(50)]
        public string SubSap { get; set; }
        [Column("SUB_MCUNIT")]
        public int SubMcunit { get; set; }
        [Column("SUB_INACTIVE")]
        public bool? SubInactive { get; set; }

        [ForeignKey(nameof(SubMcunit))]
        [InverseProperty(nameof(BdpfMcunit.BdpfMcsubunits))]
        public virtual BdpfMcunit SubMcunitNavigation { get; set; }
        [InverseProperty(nameof(BdpfBdpfma.BdSubNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
