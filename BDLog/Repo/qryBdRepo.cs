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
                          join ca in _context.BdpfCausecodes on bd.BdCuz equals ca.CuzId
                          join conmes in _context.BdpfContmeas on bd.BdContmeas equals conmes.ContmeasId
                          join co in _context.BdpfContmeasurecodes on bd.BdCont equals co.ContId
                          join dmg in _context.BdpfDamagecodes on bd.BdDmg equals dmg.DmgId
                          join em in _context.BdpfEms on bd.BdEm equals em.BdpfId
                          join fa in _context.BdpfFaults on bd.BdFault equals fa.FaultId
                          join ma in _context.BdpfMaints on bd.BdMaint equals ma.MaintId
                          join op in _context.BdpfOps on bd.BdOp equals op.OpId
                          join pa in _context.BdpfPapers on bd.BdPaperok equals pa.PaperId
                          join cr in _context.BUsers on bd.BdCreatedby equals cr.Id
                          join mo in _context.BUsers on bd.BdModifiedby equals mo.Id
                          into bd_table
                          from bdt in bd_table.DefaultIfEmpty()
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
                              BdFault= fa.FaultName,//
                              BdOp= op.OpName,//
                              BdMaint= ma.MaintName,//
                              BdEm= em.BdpfName,//
                              BdM2p= bd.BdM2p,//
                              BdDmg= dmg.DmgCode,//
                              BdCuz= ca.CuzCode,//
                              BdCont= co.ContCode,//
                              BdPart= bd.BdPart,//
                              BdCost= bd.BdCost,//
                              BdFaultdesc= bd.BdFaultdesc,//
                              BdContmeas= conmes.ContmeasName,//
                              BdContmeasdesc= bd.BdContmeasdesc,//
                              BdPaperok= pa.PaperName,//
                              BdStandard= bd.BdStandard,//
                              BdAddinfo= bd.BdAddinfo,//
                              BdIdaneed= bd.BdIdaneed,//
                              BdCreatedby= cr.Username,
                              BdCreateddate= bd.BdCreateddate,
                              BdModifiedby= bdt.Username ?? string.Empty,
                              BdModifieddate= bd.BdModifieddate,
                              BdInactive= bd.BdInactive,
                              BdRepeat= bd.BdRepeat,//
                              BdDowntime = (bd.BdStopdate - bd.BdStartdate).TotalMinutes, //
                              BdOEE= Math.Round((((bd.BdStopdate - bd.BdStartdate).TotalMinutes)/1440)*100, 2 )//
                              
                          }).ToList();
            return qryList;
        }
    }
}
