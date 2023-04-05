using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_BDPFMA")]
    public partial class BdpfBdpfma
    {
        public BdpfBdpfma()
        {
            BdpfIda = new HashSet<BdpfIdum>();
        }

        [Key]
        [Column("BD_ID")]
        public long BdId { get; set; }
        [Column("BD_SUB")]
        public int BdSub { get; set; }
        [Column("BD_STARTDATE", TypeName = "DATE")]
        public DateTime BdStartdate { get; set; }
        [Column("BD_STOPDATE", TypeName = "DATE")]
        public DateTime BdStopdate { get; set; }
        [Column("BD_FAULT")]
        public int BdFault { get; set; }
        [Column("BD_OP")]
        public int BdOp { get; set; }
        [Column("BD_MAINT")]
        public int BdMaint { get; set; }
        [Column("BD_EM")]
        public int BdEm { get; set; }
        [Column("BD_M2P")]
        [StringLength(20)]
        public string BdM2p { get; set; }
        [Column("BD_DMG")]
        public int BdDmg { get; set; }
        [Column("BD_CUZ")]
        public int BdCuz { get; set; }
        [Column("BD_CONT")]
        public int BdCont { get; set; }
        [Column("BD_PART")]
        [StringLength(50)]
        public string BdPart { get; set; }
        [Column("BD_COST")]
        public long? BdCost { get; set; }
        [Column("BD_FAULTDESC")]
        [StringLength(200)]
        public string BdFaultdesc { get; set; }
        [Column("BD_CONTMEAS")]
        public int BdContmeas { get; set; }
        [Column("BD_CONTMEASDESC")]
        [StringLength(200)]
        public string BdContmeasdesc { get; set; }
        [Column("BD_PAPEROK")]
        public int BdPaperok { get; set; }
        [Column("BD_STANDARD")]
        public bool BdStandard { get; set; }
        [Column("BD_ADDINFO")]
        [StringLength(200)]
        public string BdAddinfo { get; set; }
        [Column("BD_IDANEED")]
        public bool BdIdaneed { get; set; }
        [Column("BD_CREATEDBY")]
        public int? BdCreatedby { get; set; }
        [Column("BD_CREATEDDATE", TypeName = "DATE")]
        public DateTime? BdCreateddate { get; set; }
        [Column("BD_MODIFIEDBY")]
        public int? BdModifiedby { get; set; }
        [Column("BD_MODIFIEDDATE", TypeName = "DATE")]
        public DateTime? BdModifieddate { get; set; }
        [Column("BD_INACTIVE")]
        public bool BdInactive { get; set; }
        [Column("BD_REPEAT")]
        public bool BdRepeat { get; set; }

        [ForeignKey(nameof(BdCont))]
        [InverseProperty(nameof(BdpfContmeasurecode.BdpfBdpfmas))]
        public virtual BdpfContmeasurecode BdContNavigation { get; set; }
        [ForeignKey(nameof(BdContmeas))]
        [InverseProperty(nameof(BdpfContmea.BdpfBdpfmas))]
        public virtual BdpfContmea BdContmeasNavigation { get; set; }
        [ForeignKey(nameof(BdCreatedby))]
        [InverseProperty(nameof(BUser.BdpfBdpfmaBdCreatedbyNavigations))]
        public virtual BUser BdCreatedbyNavigation { get; set; }
        [ForeignKey(nameof(BdCuz))]
        [InverseProperty(nameof(BdpfCausecode.BdpfBdpfmas))]
        public virtual BdpfCausecode BdCuzNavigation { get; set; }
        [ForeignKey(nameof(BdDmg))]
        [InverseProperty(nameof(BdpfDamagecode.BdpfBdpfmas))]
        public virtual BdpfDamagecode BdDmgNavigation { get; set; }
        [ForeignKey(nameof(BdEm))]
        [InverseProperty(nameof(BdpfEm.BdpfBdpfmas))]
        public virtual BdpfEm BdEmNavigation { get; set; }
        [ForeignKey(nameof(BdFault))]
        [InverseProperty(nameof(BdpfFault.BdpfBdpfmas))]
        public virtual BdpfFault BdFaultNavigation { get; set; }
        [ForeignKey(nameof(BdMaint))]
        [InverseProperty(nameof(BdpfMaint.BdpfBdpfmas))]
        public virtual BdpfMaint BdMaintNavigation { get; set; }
        [ForeignKey(nameof(BdModifiedby))]
        [InverseProperty(nameof(BUser.BdpfBdpfmaBdModifiedbyNavigations))]
        public virtual BUser BdModifiedbyNavigation { get; set; }
        [ForeignKey(nameof(BdOp))]
        [InverseProperty(nameof(BdpfOp.BdpfBdpfmas))]
        public virtual BdpfOp BdOpNavigation { get; set; }
        [ForeignKey(nameof(BdPaperok))]
        [InverseProperty(nameof(BdpfPaper.BdpfBdpfmas))]
        public virtual BdpfPaper BdPaperokNavigation { get; set; }
        [ForeignKey(nameof(BdSub))]
        [InverseProperty(nameof(BdpfMcsubunit.BdpfBdpfmas))]
        public virtual BdpfMcsubunit BdSubNavigation { get; set; }
        [InverseProperty(nameof(BdpfIdum.IdaBdNavigation))]
        public virtual ICollection<BdpfIdum> BdpfIda { get; set; }
    }
}
