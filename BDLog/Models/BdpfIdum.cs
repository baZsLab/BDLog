using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_IDA")]
    public partial class BdpfIdum
    {
        [Key]
        [Column("IDA_ID")]
        public int IdaId { get; set; }
        [Column("IDA_BD")]
        public long IdaBd { get; set; }
        [Column("IDA_STARTED")]
        public bool? IdaStarted { get; set; }
        [Column("IDA_STARTDATE", TypeName = "DATE")]
        public DateTime? IdaStartdate { get; set; }
        [Column("IDA_ENDED")]
        public bool? IdaEnded { get; set; }
        [Column("IDA_ENDDATE", TypeName = "DATE")]
        public DateTime? IdaEnddate { get; set; }
        [Column("IDA_NO")]
        [StringLength(20)]
        public string IdaNo { get; set; }
        [Column("IDA_DESC")]
        [StringLength(1000)]
        public string IdaDesc { get; set; }

        [ForeignKey(nameof(IdaBd))]
        [InverseProperty(nameof(BdpfBdpfma.BdpfIda))]
        public virtual BdpfBdpfma IdaBdNavigation { get; set; }
    }
}
