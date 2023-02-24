using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_CAUSECODE")]
    public partial class BdpfCausecode
    {
        public BdpfCausecode()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("CUZ_ID")]
        public int CuzId { get; set; }
        [Required]
        [Column("CUZ_CODE")]
        [StringLength(50)]
        public string CuzCode { get; set; }
        [Required]
        [Column("CUZ_NAME")]
        [StringLength(50)]
        public string CuzName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdCuzNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
