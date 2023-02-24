using BDPFMA.Contexts;
using BDPFMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDPFMA.Repo
{
    public class qryMcUnitsRepo
    {
        protected BD_Context _context;

        public qryMcUnitsRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryMcUnit> GetQryMcUnits()
        {
            var qryList = (from un in _context.BdpfMcunits
                          join mc in _context.BdpfMcs on un.UnitMc equals mc.McId
                          join ce in _context.BdpfCells on mc.McCell equals ce.CellId
                          join ar in _context.BdpfAreas on ce.CellArea equals ar.AreaId
                          select new qryMcUnit()
                          {
                              AreaId = Convert.ToInt16(ar.AreaId),
                              AreaName = ar.AreaName,
                              CellId = Convert.ToInt16(ce.CellId),
                              CellNoName = "#" + ("0" + ce.CellNo.ToString()).Substring(("0" + ce.CellNo.ToString()).Length-2) + " - " + ce.CellName,
                              McId= mc.McId,
                              McName= mc.McName,
                              unitID=un.UnitId,
                              unitName=un.UnitName,
                              unitSAP=un.UnitSap
                          }).ToList();
            return qryList;
        }
    }
}
