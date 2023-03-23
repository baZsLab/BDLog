using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_PAPER")]
    public partial class BdpfPaper
    {
        public BdpfPaper()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("PAPER_ID")]
        public int PaperId { get; set; }
        [Required]
        [Column("PAPER_NAME")]
        [StringLength(50)]
        public string PaperName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdPaperokNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
