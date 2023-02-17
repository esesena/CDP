using CDP.Domain;
using CDP.Persistence.Context;
using CDP.Persistence.Contracts;
using CDP.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Persistence
{
    public class PlantingPersist : GeralPersist, IPlantingPersist
    {
        private readonly CDPContext _context;

        public PlantingPersist(CDPContext context) : base(context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<PageList<Planting>> GetAllPlantingsAsync(PageParams pageParams, bool includePlots = false)
        {
            IQueryable<Planting> query = _context.Plantings;

            if (includePlots)
            {
                query = query.Include(p => p.PlantingPlot)
                    .ThenInclude(pe => pe.Plot);
            }

            return await PageList<Planting>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

    }
}
