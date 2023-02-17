using CDP.Domain;
using CDP.Persistence.Context;
using CDP.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Persistence
{
    public class PlotPersist : IPlotPersist
    {
        private readonly CDPContext _context;

        public PlotPersist(CDPContext context)
        {
            _context = context;
        }

        public async Task<Plot> GetPlotByIdsAsync(int plotId, int farmId)
        {
            IQueryable<Plot> query = _context.Plots;
            query = query.AsNoTracking()
                         .Where(plot => plot.FarmId == farmId
                                     && plot.Id == plotId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Plot[]> GetPlotsByFarmIdAsync(int farmId)
        {
            IQueryable<Plot> query = _context.Plots;

            query = query.AsNoTracking()
                         .Where(plot => plot.FarmId == farmId);

            return await query.ToArrayAsync();
        }
    }
}
