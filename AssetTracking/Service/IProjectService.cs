using System;
using System.Collections.Generic;
using Core;
using Data;

namespace Service
{
    public interface IProjectService : IEntityService<Project>
    {
        Project GetByProjectNumber(string company, string projectNumber);
        List<Project> GetProjectsByPM(string company, int pmId);
        List<Project> GetProjectsByForeman(string company, int technicianId);
        List<Project> GetProjectsByEngineer(string company, int technicianId);
        ProjectPlanning GetProjectPlanningForForeman(int projectId, int technicianId, DateTime startDate);
        ProjectPlanning GetProjectPlanningForEngineer(int projectId, int technicianId, DateTime startDate);
        ProjectPlanning GetProjectPlanningForPM(int projectId, int technicianId, DateTime startDate);
        int UpdateGPScheduleDate(string company, string jobNumber, DateTime scheduleStartDate, DateTime scheduleCompletionDate);
        int UpdateGPEngineer(string company, string jobNumber, string technicianId);
        int UpdateGPForeman(string company, string jobNumber, string technicianId);
    }
}