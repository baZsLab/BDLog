using System;

namespace BDELog.Models
{
    public partial class qryIda
    {
        public int? IdaId { get; set; }
        public long? IdaBd { get; set; }
        public bool? IdaStarted { get; set; }
        public DateTime? IdaStartdate { get; set; }
        public bool? IdaEnded { get;set; }
        public DateTime? IdaEnddate { get; set; }
        public string? IdaNo { get; set;}
        public string? IdaDesc { get; set;}

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int CellId { get; set; }
        public string CellNoName { get; set; }
        public int McId { get; set; }
        public string McName { get; set; }
        public int unitID { get; set; }
        public string unitName { get; set; }
        public string unitSAP { get; set; }
        public int subID { get; set; }
        public string subName { get; set; }
        public string subSAP { get; set; }
        public DateTime BdStartdate { get; set; }
        public int CellNo { get; set; }
    }
}
