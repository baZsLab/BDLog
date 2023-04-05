using BDELog.Contexts;
using BDELog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDELog.Repo
{
    public class qryBDRepo
    {
        protected BD_Context _context;

        public qryBDRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryBd> GetBD()
        {
            var qryList = (from bd in _context.BdpfBdpfmas
                          join su in _context.BdpfMcsubunits on bd.BdSub equals su.SubId
                          join un in _context.BdpfMcunits on su.SubMcunit equals un.UnitId
                          join mc in _context.BdpfMcs on un.UnitMc equals mc.McId
                          join ce in _context.BdpfCells on mc.McCell equals ce.CellId
                          join ar in _context.BdpfAreas on ce.CellArea equals ar.AreaId
                          select new qryBd()
                          {
                              AreaId = Convert.ToInt16(ar.AreaId),
                              AreaName = ar.AreaName,
                              CellId = Convert.ToInt16(ce.CellId),
                              CellNoName = "#" + ("0" + ce.CellNo.ToString()).Substring(("0" + ce.CellNo.ToString()).Length-2) + " - " + ce.CellName,
                              McId= mc.McId,
                              McName= mc.McName,
                              unitID=un.UnitId,
                              unitName=un.UnitName,
                              unitSAP=un.UnitSap,
                              subID=su.SubId,
                              subName=su.SubName,
                              subSAP=su.SubSap,
                              BdId= bd.BdId,//
                              BdStartdate= bd.BdStartdate,//
                              BdStopdate= bd.BdStopdate,//
                              BdFault= bd.BdFault,//
                              BdOp= bd.BdOp,//
                              BdMaint= bd.BdMaint,//
                              BdEm= bd.BdEm,//
                              BdM2p= bd.BdM2p,//
                              BdDmg= bd.BdDmg,//
                              BdCuz= bd.BdCuz,//
                              BdCont= bd.BdCont,//
                              BdPart= bd.BdPart,//
                              BdCost= bd.BdCost,//
                              BdFaultdesc= bd.BdFaultdesc,//
                              BdContmeas= bd.BdContmeas,//
                              BdContmeasdesc= bd.BdContmeasdesc,//
                              BdPaperok= bd.BdPaperok,//
                              BdStandard= bd.BdStandard,//
                              BdAddinfo= bd.BdAddinfo,//
                              BdIdaneed= bd.BdIdaneed,//
                              BdCreatedby= bd.BdCreatedby,
                              BdCreateddate= bd.BdCreateddate,
                              BdModifiedby= bd.BdModifiedby,
                              BdModifieddate= bd.BdModifieddate,
                              BdInactive= bd.BdInactive,
                              BdRepeat= bd.BdRepeat,//
                              BdDowntime = (bd.BdStopdate - bd.BdStartdate).TotalMinutes, //
                              BdOEE=((bd.BdStopdate - bd.BdStartdate).TotalMinutes)/1440 //
                              
                          }).ToList();
            return qryList;
        }
    }
}
