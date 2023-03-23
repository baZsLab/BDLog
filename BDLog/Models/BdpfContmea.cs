using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_CONTMEAS")]
    public partial class BdpfContmea
    {
        public BdpfContmea()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("CONTMEAS_ID")]
        public int ContmeasId { get; set; }
        [Required]
        [Column("CONTMEAS_NAME")]
        [StringLength(50)]
        public string ContmeasName { get; set; }
        [Column("CONTMEAS_NO")]
        public int ContmeasNo { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdContmeasNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
