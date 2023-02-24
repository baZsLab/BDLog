using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_EM")]
    public partial class BdpfEm
    {
        public BdpfEm()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("BDPF_ID")]
        public int BdpfId { get; set; }
        [Required]
        [Column("BDPF_NAME")]
        [StringLength(50)]
        public string BdpfName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdEmNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
