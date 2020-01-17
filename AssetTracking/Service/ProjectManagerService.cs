using Core;
using Core.Helper;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectManagerService : EntityService<ProjectManager>, IProjectManagerService
    {
        IDbContext _context;

        public ProjectManagerService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public ProjectManager GetByEmployeeId(string company, string employeeId)
        {
            return this.Entities.FirstOrDefault(u => u.Company == company && u.EmployeeId == employeeId);
        }
    }
}
