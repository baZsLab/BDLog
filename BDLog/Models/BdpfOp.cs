using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_OP")]
    public partial class BdpfOp
    {
        public BdpfOp()
        {
            BdpfBdpfmas = new HashSet<BdpfBdpfma>();
        }

        [Key]
        [Column("OP_ID")]
        public int OpId { get; set; }
        [Required]
        [Column("OP_NAME")]
        [StringLength(50)]
        public string OpName { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdOpNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmas { get; set; }
    }
}
