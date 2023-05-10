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

namespace BDELog.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIqryBDController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIqryBDController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIBdpfma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<qryBd>>> GetBdpfBdpfmas()
        {
            var bdRepository = new qryBDRepo(_context);
            var bds = bdRepository.GetBD().OrderByDescending(m => m.BdStartdate).ToList();

            return bds.ToList();
        }

        // GET: api/BIBdpfma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfBdpfma>> GetBdpfBdpfma(long id)
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
