using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Core;
using Core.Data;
using Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Service
{
    public class ProjectTaskService : EntityService<ProjectTask>, IProjectTaskService
    {
        IDbContext _context;

        public ProjectTaskService(IDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}