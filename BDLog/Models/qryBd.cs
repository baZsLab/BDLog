﻿using BDELog.Contexts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDELog.Models
{
    public class qryBd
    {
        public int  AreaId { get; set; }
        public string AreaName { get; set; }
        public int CellId { get; set; }
        public string CellNoName { get; set; }
        public int McId { get; set; }
        public string McName { get; set;}
        public int unitID { get; set; }
        public string unitName { get; set; }
        public string unitSAP { get; set; }
        public int subID { get; set; }
        public string subName { get; set; }
        public string subSAP { get; set; }


        public long BdId { get; set; }
        public DateTime BdStartdate { get; set; }
        public DateTime BdStopdate { get; set; }
        public string BdFault { get; set; }
        public string BdOp { get; set; }
        public string BdMaint { get; set; }
        public string BdEm { get; set; }
        public string BdM2p { get; set; }
        public string BdDmg { get; set; }
        public string BdCuz { get; set; }
        public string BdCont { get; set; }
        public string BdPart { get; set; }
        public long? BdCost { get; set; }
        public string BdFaultdesc { get; set; }
        public string BdContmeas { get; set; }
        public string BdContmeasdesc { get; set; }
        public string BdPaperok { get; set; }
        public bool BdStandard { get; set; }
        public string BdAddinfo { get; set; }
        public bool BdIdaneed { get; set; }
        public string BdCreatedby { get; set; }
        public DateTime? BdCreateddate { get; set; }
        public string BdModifiedby { get; set; }
        public DateTime? BdModifieddate { get; set; }
        public bool BdInactive { get; set; }
        public bool BdRepeat { get; set; }
        public double BdDowntime { get; set; }
        public double BdOEE { get; set; }


    }
}
