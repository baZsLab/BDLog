using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_MAINT")]
    public partial class BdpfMaint
    {
        public BdpfMaint()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("MAINT_ID")]
        public int MaintId { get; set; }
        [Required]
        [Column("MAINT_NAME")]
        [StringLength(50)]
        public string MaintName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdMaintNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
