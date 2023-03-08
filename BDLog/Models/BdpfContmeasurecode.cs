using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_CONTMEASURECODE")]
    public partial class BdpfContmeasurecode
    {
        public BdpfContmeasurecode()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("CONT_ID")]
        public int ContId { get; set; }
        [Required]
        [Column("CONT_CODE")]
        [StringLength(50)]
        public string ContCode { get; set; }
        [Required]
        [Column("CONT_NAME")]
        [StringLength(50)]
        public string ContName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdContNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
