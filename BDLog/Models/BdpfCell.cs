using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Models
{
    [Table("BDPF_CELL")]
    public partial class BdpfCell
    {
        public BdpfCell()
        {
            BdpfMcs = new HashSet<BdpfMc>();
        }

        [Required]
        [Column("CELL_NAME")]
        [StringLength(50)]
        public string CellName { get; set; }
        [Column("CELL_NO")]
        public byte? CellNo { get; set; }
        [Key]
        [Column("CELL_ID")]
        public int CellId { get; set; }
        [Column("CELL_AREA")]
        public int CellArea { get; set; }
        [Column("CELL_INACTIVE")]
        public bool? CellInactive { get; set; }

        [ForeignKey(nameof(CellArea))]
        [InverseProperty(nameof(BdpfArea.BdpfCells))]
        public virtual BdpfArea CellAreaNavigation { get; set; }
        [InverseProperty(nameof(BdpfMc.McCellNavigation))]
        public virtual ICollection<BdpfMc> BdpfMcs { get; set; }
    }
}
