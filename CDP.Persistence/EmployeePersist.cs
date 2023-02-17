﻿using CDP.Domain;
using CDP.Domain.Identity;
using CDP.Persistence.Context;
using CDP.Persistence.Contracts;
using CDP.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CDP.Persistence
{
    public class EmployeePersist : GeralPersist, IEmployeePersist
    {
        private readonly CDPContext _context;

        public EmployeePersist(CDPContext context) : base(context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<PageList<Employee>> GetAllEmployeesAsync(PageParams pageParams, bool includeFarms = false)
        {
            IQueryable<Employee> query = _context.Employees
                        .Include(c => c.User);

            if (includeFarms)
            {
                query = query.Include(p => p.EmployeesFarms)
                    .ThenInclude(pe => pe.Farm);
            }

            query = query.AsNoTracking()
                         .Where(p => (p.User.Description.ToLower().Contains(pageParams.Term.ToLower()) ||
                                     p.User.FirstName.ToLower().Contains(pageParams.Term.ToLower()) ||
                                     p.User.LastName.ToLower().Contains(pageParams.Term.ToLower())) &&
                                     p.User.Function == Domain.Enums.Function.Director)
                         .OrderBy(p => p.Id);

            return await PageList<Employee>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Employee> GetEmployeeByUserIdAsync(int userId, bool includeFarms = false)
        {
            IQueryable<Employee> query = _context.Employees
                            .Include(p => p.User);

            if (includeFarms)
            {
                query = query.Include(p => p.EmployeesFarms)
                    .ThenInclude(pe => pe.Farm);
            }
            query = query.OrderBy(e => e.Id)
                .Where(p => p.Id == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
