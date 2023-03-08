using BDELog.Contexts;
using BDELog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDELog.Repo
{
    public class qryCellsRepo
    {
        protected BD_Context _context;

        public qryCellsRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryCells> GetQryCells()
        {
            var qryList = (from ce in _context.BdpfCells
                           orderby ce.CellNo
                          select new qryCells()
                          {
                              CellId = Convert.ToInt16(ce.CellId),
                              CellName = "#" + ("0" + ce.CellNo.ToString()).Substring(("0" + ce.CellNo.ToString()).Length-2) + " - " + ce.CellName,
                              CellArea = Convert.ToInt16(ce.CellArea)
                          }).ToList();
            return qryList;
        }
    }
}
