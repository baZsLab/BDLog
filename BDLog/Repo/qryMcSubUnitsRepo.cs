using BDELog.Contexts;
using BDELog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDELog.Repo
{
    public class qryMcSubUnitsRepo
    {
        protected BD_Context _context;

        public qryMcSubUnitsRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryMcSubUnit> GetQryMcSubUnits()
        {
            var qryList = (from su in _context.BdpfMcsubunits
                           join un in _context.BdpfMcunits on su.SubMcunit equals un.UnitId
                           join mc in _context.BdpfMcs on un.UnitMc equals mc.McId
                           join ce in _context.BdpfCells on mc.McCell equals ce.CellId
                           join ar in _context.BdpfAreas on ce.CellArea equals ar.AreaId
                           select new qryMcSubUnit()
                           {
                               AreaId = Convert.ToInt16(ar.AreaId),
                               AreaName = ar.AreaName,
                               CellId = Convert.ToInt16(ce.CellId),
                               CellNoName = "#" + ("0" + ce.CellNo.ToString()).Substring(("0" + ce.CellNo.ToString()).Length - 2) + " - " + ce.CellName,
                               McId = mc.McId,
                               McName = mc.McName,
                               unitID = un.UnitId,
                               unitName = un.UnitName,
                               unitSAP = un.UnitSap,
                               subID = su.SubId,
                               subName = su.SubName,
                               subSAP = su.SubSap
                           }).ToList();
            return qryList;
        }
    }
}
