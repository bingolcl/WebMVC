using Microsoft.EntityFrameworkCore;
using PSI.Data;
using PSI.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service
{
    public class TechService : ITechService
    {
        PSIDevContext _psiContext { get; set; }

        public TechService(PSIDevContext context)
        {
            _psiContext = context;
        }

        public List<Technician> GetAll()
        {
            var techs = _psiContext.Technician.
                        Include(t => t.TechInRole).
                        ThenInclude(tr => tr.Role).
                        ToList();
            return techs;
        }

        public Technician Find(string email)
        {
            var techs = this.GetAll().Find(t => t.Email == email);
            return techs;
        }

        public List<Role> GetRoles(Technician tech)
        {
            var roles = tech.TechInRole.Select(tr => tr.Role).ToList();
            return roles;
        }
    }
}
