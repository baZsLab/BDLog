using BDELog.Contexts;
using BDELog.Controllers;
using BDELog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BDELog.Repo
{
    public class qryIdaRepo
    {
        protected BD_Context _context;

        public qryIdaRepo(BD_Context context)
        {
            _context = context; 
        }
        public IEnumerable<qryIda> GetIda()
        {
            var bdRepository = new qryBDRepo(_context);
            var bds = bdRepository.GetBD().OrderByDescending(m => m.BdCreateddate).Where(i => i.BdIdaneed == true).ToList();
            var qryList = (from bd in bds
                           
                           join ce in _context.BdpfCells on bd.CellId equals ce.CellId

                           join ida in _context.BdpfIda on bd.BdId equals ida.IdaBd into joinedlist
                           from item in joinedlist.DefaultIfEmpty()
                           
                           let IdaId = item?.IdaId
                           let IdaNo = item?.IdaNo
                           let IdaDesc = item?.IdaDesc
                           let IdaStartdate = item?.IdaStartdate
                           let IdaStarted = item?.IdaStarted
                           let IdaEnddate = item?.IdaEnddate
                           let IdaEnded = item?.IdaEnded
                           select new qryIda
                           {
                               AreaId = bd.AreaId,
                               AreaName = bd.AreaName,
                               CellId = bd.CellId,
                               CellNo = (int)ce.CellNo,
                               CellNoName = bd.CellNoName,
                               McId = bd.McId,
                               McName = bd.McName,
                               unitID = bd.unitID,
                               unitName = bd.unitName,
                               subID = bd.subID,
                               subName = bd.subName,
                               BdStartdate = bd.BdStartdate,
                               IdaId = IdaId,
                               IdaBd = bd.BdId,
                               IdaNo = IdaNo,
                               IdaDesc = IdaDesc,
                               IdaStartdate = IdaStartdate,
                               IdaStarted = IdaStarted,
                               IdaEnddate = IdaEnddate,
                               IdaEnded = IdaEnded
                           }).ToList();
                              
                          
            return qryList;
        }
        public IEnumerable<qryIDAbyCell> GetNextIDA()
        {
            var cells =  _context.BdpfCells.ToList();
            var idaRepository = new qryIdaRepo(_context);
            var idas = idaRepository.GetIda().Where(m => m.IdaStarted == true).ToList();

            var qryList = (from cell in cells
                          join ida in idas on cell.CellId equals ida.CellId into gj
                          from subIda in gj.DefaultIfEmpty()
                          group subIda by cell into g
                          select new qryIDAbyCell
                          {
                              CellId = g.Key.CellId,
                              CellNo = (int)g.Key.CellNo,
                              IDACount = g.Count(ida => ida != null)
                          }).ToList();

            return qryList;
        }
    }
}
