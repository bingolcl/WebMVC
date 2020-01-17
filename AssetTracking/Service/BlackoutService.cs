using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Data;
using Data;

namespace Service
{
    public class BlackoutService : EntityService<Blackout>, IBlackoutService
    {
        IDbContext _context;

        public BlackoutService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Blackout> GetBlackoutsByTechnician(int technicianId)
        {
            return this.Entities.Where(b => b.TechnicianId == technicianId).OrderBy(b => b.StartDate).ToList();
        }
    }
}
