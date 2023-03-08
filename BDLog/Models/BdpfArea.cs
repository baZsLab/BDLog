using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_AREA")]
    public partial class BdpfArea
    {
        public BdpfArea()
        {
            BdpfCells = new HashSet<BdpfCell>();
        }

        [Required]
        [Column("AREA_NAME")]
        [StringLength(50)]
        public string AreaName { get; set; }
        [Key]
        [Column("AREA_ID")]
        public int AreaId { get; set; }
        [Column("AREA_INACTIVE")]
        public bool? AreaInactive { get; set; }

        [InverseProperty(nameof(BdpfCell.CellAreaNavigation))]
        public virtual ICollection<BdpfCell> BdpfCells { get; set; }
    }
}
