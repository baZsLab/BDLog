using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;
using BDELog.Repo;
using Microsoft.AspNetCore.Authorization;

namespace BDELog.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIqryIDAbyCellController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIqryIDAbyCellController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIBdpfma
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<qryIDAbyCell>>> GetBdpfIdasbycell(int? cellId)
        {
            var idaRepository = new qryIdaRepo(_context);
            var response = idaRepository.GetNextIDA();
            var items = response;

            if (cellId.HasValue)
            {
                var item = items.Where(i => i.CellId == cellId.Value);
                return item.ToList();
            }


            
            return items.ToList();
        }

        // GET: api/BIBdpfma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfBdpfma>> GetBdpfIdasbycel(long id)
        {
            var bdpfBdpfma = await _context.BdpfBdpfmas.FindAsync(id);

            if (bdpfBdpfma == null)
            {
                return NotFound();
            }

            return bdpfBdpfma;
        }

        private bool BdpfBdpfmaExists(long id)
        {
            return _context.BdpfBdpfmas.Any(e => e.BdId == id);
        }
    }
}
