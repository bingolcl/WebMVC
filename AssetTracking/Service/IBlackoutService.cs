using Data;
using System.Collections.Generic;

namespace Service
{
    public interface IBlackoutService : IEntityService<Blackout>
    {
        List<Blackout> GetBlackoutsByTechnician(int technicianId);
    }
}
