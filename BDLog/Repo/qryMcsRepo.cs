using BDELog.Contexts;
using BDELog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDELog.Repo
{
    public class qryMcsRepo
    {
        protected BD_Context _context;

        public qryMcsRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryMcs> GetQryMcs()
        {
            var qryList = (from mc in _context.BdpfMcs
                          join ce in _context.BdpfCells on mc.McCell equals ce.CellId
                          join ar in _context.BdpfAreas on ce.CellArea equals ar.AreaId
                          
                          select new qryMcs()
                          {
                              AreaId = Convert.ToInt16(ar.AreaId),
                              AreaName = ar.AreaName,
                              CellId = Convert.ToInt16(ce.CellId),
                              CellNoName = "#" + ("0" + ce.CellNo.ToString()).Substring(("0" + ce.CellNo.ToString()).Length-2) + " - " + ce.CellName,
                              McId= mc.McId,
                              McName= mc.McName
                          }).ToList();
            return qryList;
        }
    }
}
