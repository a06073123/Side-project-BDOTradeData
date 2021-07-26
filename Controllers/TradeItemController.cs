using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

using bdo3.Models;

namespace bdo3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradeItemController : Controller
    {
        private readonly ILogger<TradeItemController> _logger;
        private readonly BDOContext _context;

        public TradeItemController(ILogger<TradeItemController> logger, BDOContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("Search")]
        public async Task<JsonResult> PostAsync(TradeItem target)
        {
            if (ItemExists(target.Name))
            {
                return Json(_context.TradeItems.Where(ti => ti.Name.Contains(target.Name)).ToList());
            }
            else
            {
                return Json(new { });
            }

        }

        private bool ItemExists(string key)
        {
            return _context.TradeItems.Any(ti => ti.Name.Contains(key));
        }

    }
}
