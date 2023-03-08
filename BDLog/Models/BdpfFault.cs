using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_FAULT")]
    public partial class BdpfFault
    {
        public BdpfFault()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("FAULT_ID")]
        public int FaultId { get; set; }
        [Required]
        [Column("FAULT_NAME")]
        [StringLength(50)]
        public string FaultName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdFaultNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
