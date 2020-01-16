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
    public class ProjectService : EntityService<Project>, IProjectService
    {
        IDbContext _context;
        ITechnicianService _technicianService;
        IStatutoryHolidayService _statutoryHolidayService;
        ILogService _logService;

        public ProjectService(IDbContext context,
                              ITechnicianService technicianService,
                              IStatutoryHolidayService statutoryHolidayService,
                              ILogService logService)
            : base(context)
        {
            _context = context;
            _technicianService = technicianService;
            _statutoryHolidayService = statutoryHolidayService;
            _logService = logService;
        }

        public Project GetByProjectNumber(string company, string projectNumber)
        {
            return this.Entities.FirstOrDefault(p => p.Company == company && p.ProjectNumber == projectNumber);
        }

        public List<Project> GetProjectsByPM(string company, int pmId)
        {
            return this.Entities.Where(p => p.Company == company && p.ProjectManagerId == pmId && p.IsActive && p.IsIncludedForPM).OrderBy(p => p.ProjectNumber).ToList();
        }

        public List<Project> GetProjectsByForeman(string company, int technicianId)
        {
            return this.Entities.Where(p => p.Company == company && p.ForemanId == technicianId && p.IsActive && p.IsIncludedForForeman).OrderBy(p => p.ProjectNumber).ToList();
        }

        public List<Project> GetProjectsByEngineer(string company, int technicianId)
        {
            return this.Entities.Where(p => p.Company == company && p.EngineerId == technicianId && p.IsActive && p.IsIncludedForEngineer).OrderBy(p => p.ProjectNumber).ToList();
        }

        public ProjectPlanning GetProjectPlanningForForeman(int projectId, int technicianId, DateTime startDate)
        {
            var project = this.Entities.Single(p => p.Id == projectId);
            var technician = _technicianService.GetById(technicianId);
            var availableDays = _technicianService.GetWorkingDays(technicianId, project.ScheduleStartDate, project.ScheduleCompletionDate);
            decimal dailyHours = availableDays <= 0 ? 0 : project.LoadedPlanningHoursForForeman / availableDays;

            //decimal jobCalculatedRate = project.ForecastedGPHoursForForeman == 0 ? 0 : project.ForecastedCostForForman / project.ForecastedGPHoursForForeman;
            //List<Technician> technicianTeam = new List<Technician>();
            //technicianTeam.Add(technician);
            //foreach (var item in technician.ChildTechnicians)
            //{
            //    technicianTeam.Add(item);
            //}
            //decimal assignedTechAverageRate = technicianTeam.Average(t => t.LoadedRate);
            //decimal factor = assignedTechAverageRate == 0 ? 0 : jobCalculatedRate / assignedTechAverageRate;
            //decimal actualDailyHours = factor == 0 ? dailyHours : dailyHours * factor;

            List<DateTime> blackOutDates = new List<DateTime>();
            foreach (var blackOut in technician.Blackouts)
            {
                for (DateTime date = blackOut.StartDate; date <= blackOut.EndDate; date = date.AddDays(1))
                    blackOutDates.Add(date);
            }

            List<DateTime> projectDateRanges = new List<DateTime>();
            for (DateTime date = project.ScheduleStartDate; date <= project.ScheduleCompletionDate; date = date.AddDays(1))
            {
                projectDateRanges.Add(date);
            }

            var projectPlanning = new ProjectPlanning();
            projectPlanning.Id = project.Id;
            projectPlanning.ProjectNumber = project.ProjectNumber;
            projectPlanning.ProjectName = project.ProjectName;
            projectPlanning.Category = PlanningCategory.Foreman.ToString();
            projectPlanning.ForemanId = project.ForemanId;
            projectPlanning.IsActive = project.IsActive;
            projectPlanning.IsIncluded = project.IsIncludedForForeman;
            //projectPlanning.IsIncludedForEngineer = project.IsIncludedForEngineer;
            projectPlanning.ScheduleStartDate = project.ScheduleStartDate;
            projectPlanning.ScheduleCompletionDate = project.ScheduleCompletionDate;
            projectPlanning.RemainingHoursForForeman = project.LoadedRemainingHoursForForeman;
            projectPlanning.RemainingHoursForEngineer = project.LoadedRemainingHoursForEngineer;
            projectPlanning.ForecastHours = project.ForecastHoursForForeman;
            //projectPlanning.ForecastHoursForEngineer = project.ForecastHoursForEngineer;
            projectPlanning.CalcPercentageCompleteToDate = project.LoadedCalcPercentageCompleteToDateForForeman;
            //projectPlanning.CalcPercentageCompleteToDateForEngineer = project.CalcPercentageCompleteToDateForEngineer;

            int numberofWorkingDays = Convert.ToInt32(ConfigurationManager.AppSettings["ShowNumberofWorkingDays"]);
            List<DateTime> workingDays = _statutoryHolidayService.GetCountedWorkingDays(startDate, numberofWorkingDays);
            projectPlanning.DailyHours = new decimal[numberofWorkingDays];
            for (int i = 0; i < workingDays.Count; i++)
            {
                if (projectDateRanges.Any(d => d == workingDays[i]) && !blackOutDates.Any(d => d == workingDays[i]))
                {
                    projectPlanning.DailyHours[i] = dailyHours;
                }
                else
                {
                    projectPlanning.DailyHours[i] = 0;
                }
            }

            projectPlanning.TotalBacklog = project.LoadedPlanningHoursForForeman;
            projectPlanning.Total = projectPlanning.DailyHours.Sum();
            projectPlanning.Average = projectPlanning.DailyHours.Average();

            return projectPlanning;
        }

        public ProjectPlanning GetProjectPlanningForEngineer(int projectId, int technicianId, DateTime startDate)
        {
            var project = this.Entities.Single(p => p.Id == projectId);
            var technician = _technicianService.GetById(technicianId);
            var availableDays = _technicianService.GetWorkingDays(technicianId, project.ScheduleStartDate, project.ScheduleCompletionDate);
            decimal dailyHours = availableDays <= 0 ? 0 : project.LoadedPlanningHoursForEngineer  / availableDays;

            //decimal jobCalculatedRate = project.ForecastedGPHoursForEngineer == 0 ? 0 : project.ForecastedCostForEngineer / project.ForecastedGPHoursForEngineer;
            //List<Technician> technicianTeam = new List<Technician>();
            //technicianTeam.Add(technician);
            //foreach (var item in technician.ChildTechnicians)
            //{
            //    technicianTeam.Add(item);
            //}
            //decimal assignedTechAverageRate = technicianTeam.Average(t => t.LoadedRate);
            //decimal factor = assignedTechAverageRate == 0 ? 0 : jobCalculatedRate / assignedTechAverageRate;
            //decimal actualDailyHours = factor == 0 ? dailyHours : dailyHours * factor;

            List<DateTime> blackOutDates = new List<DateTime>();
            foreach (var blackOut in technician.Blackouts)
            {
                for (DateTime date = blackOut.StartDate; date <= blackOut.EndDate; date = date.AddDays(1))
                    blackOutDates.Add(date);
            }

            List<DateTime> projectDateRanges = new List<DateTime>();
            for (DateTime date = project.ScheduleStartDate; date <= project.ScheduleCompletionDate; date = date.AddDays(1))
            {
                projectDateRanges.Add(date);
            }

            var projectPlanning = new ProjectPlanning();
            projectPlanning.Id = project.Id;
            projectPlanning.ProjectNumber = project.ProjectNumber;
            projectPlanning.ProjectName = project.ProjectName;
            projectPlanning.Category = PlanningCategory.Engineer.ToString();
            projectPlanning.IsActive = project.IsActive;
            //projectPlanning.ForemanId = project.ForemanId;
            projectPlanning.EngineerId = project.EngineerId;
            //projectPlanning.IsIncludedForForeman = project.IsIncludedForForeman;
            projectPlanning.IsIncluded = project.IsIncludedForEngineer;
            projectPlanning.ScheduleStartDate = project.ScheduleStartDate;
            projectPlanning.ScheduleCompletionDate = project.ScheduleCompletionDate;
            projectPlanning.RemainingHoursForForeman = project.LoadedRemainingHoursForForeman;
            projectPlanning.RemainingHoursForEngineer = project.LoadedRemainingHoursForEngineer;
            //projectPlanning.ForecastHoursForForeman = project.ForecastHoursForForeman;
            projectPlanning.ForecastHours = project.ForecastHoursForEngineer;
            //projectPlanning.CalcPercentageCompleteToDateForForeman = project.CalcPercentageCompleteToDateForForeman;
            projectPlanning.CalcPercentageCompleteToDate = project.LoadedCalcPercentageCompleteToDateForEngineer;

            int numberofWorkingDays = Convert.ToInt32(ConfigurationManager.AppSettings["ShowNumberofWorkingDays"]);
            List<DateTime> workingDays = _statutoryHolidayService.GetCountedWorkingDays(startDate, numberofWorkingDays);
            projectPlanning.DailyHours = new decimal[numberofWorkingDays];
            for (int i = 0; i < workingDays.Count; i++)
            {
                if (projectDateRanges.Any(d => d == workingDays[i]) && !blackOutDates.Any(d => d == workingDays[i]))
                {
                    projectPlanning.DailyHours[i] = dailyHours;
                }
                else
                {
                    projectPlanning.DailyHours[i] = 0;
                }
            }

            projectPlanning.TotalBacklog = project.LoadedPlanningHoursForEngineer;
            projectPlanning.Total = projectPlanning.DailyHours.Sum();
            projectPlanning.Average = projectPlanning.DailyHours.Average();

            return projectPlanning;
        }

        public ProjectPlanning GetProjectPlanningForPM(int projectId, int technicianId, DateTime startDate)
        {
            var project = this.Entities.Single(p => p.Id == projectId);
            var technician = _technicianService.GetById(technicianId);
            var availableDays = _technicianService.GetWorkingDays(technicianId, project.ScheduleStartDate, project.ScheduleCompletionDate);
            decimal dailyHours = availableDays <= 0 ? 0 : project.LoadedPlanningHoursForPM / availableDays;

            //decimal jobCalculatedRate = project.ForecastedGPHoursForForeman == 0 ? 0 : project.ForecastedCostForForman / project.ForecastedGPHoursForForeman;
            //List<Technician> technicianTeam = new List<Technician>();
            //technicianTeam.Add(technician);
            //foreach (var item in technician.ChildTechnicians)
            //{
            //    technicianTeam.Add(item);
            //}
            //decimal assignedTechAverageRate = technicianTeam.Average(t => t.LoadedRate);
            //decimal factor = assignedTechAverageRate == 0 ? 0 : jobCalculatedRate / assignedTechAverageRate;
            //decimal actualDailyHours = factor == 0 ? dailyHours : dailyHours * factor;

            List<DateTime> blackOutDates = new List<DateTime>();
            foreach (var blackOut in technician.Blackouts)
            {
                for (DateTime date = blackOut.StartDate; date <= blackOut.EndDate; date = date.AddDays(1))
                    blackOutDates.Add(date);
            }

            List<DateTime> projectDateRanges = new List<DateTime>();
            for (DateTime date = project.ScheduleStartDate; date <= project.ScheduleCompletionDate; date = date.AddDays(1))
            {
                projectDateRanges.Add(date);
            }

            var projectPlanning = new ProjectPlanning();
            projectPlanning.Id = project.Id;
            projectPlanning.ProjectNumber = project.ProjectNumber;
            projectPlanning.ProjectName = project.ProjectName;
            projectPlanning.Category = PlanningCategory.PM.ToString();
            projectPlanning.ProjectManagerId = project.ProjectManagerId;
            projectPlanning.ProjectManagerEmployeeId = project.ProjectManager.EmployeeId; 
            projectPlanning.IsActive = project.IsActive;
            projectPlanning.IsIncluded = project.IsIncludedForPM;
            //projectPlanning.IsIncludedForEngineer = project.IsIncludedForEngineer;
            projectPlanning.ScheduleStartDate = project.ScheduleStartDate;
            projectPlanning.ScheduleCompletionDate = project.ScheduleCompletionDate;
            projectPlanning.RemainingHoursForForeman = project.LoadedRemainingHoursForForeman;
            projectPlanning.RemainingHoursForEngineer = project.LoadedRemainingHoursForEngineer;
            projectPlanning.RemainingHoursForPM = project.LoadedRemainingHoursForPM;
            projectPlanning.ForecastHours = project.ForecastHoursForPM;
            //projectPlanning.ForecastHoursForEngineer = project.ForecastHoursForEngineer;
            projectPlanning.CalcPercentageCompleteToDate = project.LoadedCalcPercentageCompleteToDateForPM;
            //projectPlanning.CalcPercentageCompleteToDateForEngineer = project.CalcPercentageCompleteToDateForEngineer;

            int numberofWorkingDays = Convert.ToInt32(ConfigurationManager.AppSettings["ShowNumberofWorkingDays"]);
            List<DateTime> workingDays = _statutoryHolidayService.GetCountedWorkingDays(startDate, numberofWorkingDays);
            projectPlanning.DailyHours = new decimal[numberofWorkingDays];
            for (int i = 0; i < workingDays.Count; i++)
            {
                if (projectDateRanges.Any(d => d == workingDays[i]) && !blackOutDates.Any(d => d == workingDays[i]))
                {
                    projectPlanning.DailyHours[i] = dailyHours;
                }
                else
                {
                    projectPlanning.DailyHours[i] = 0;
                }
            }

            projectPlanning.TotalBacklog = project.LoadedPlanningHoursForPM;
            projectPlanning.Total = projectPlanning.DailyHours.Sum();
            projectPlanning.Average = projectPlanning.DailyHours.Average();

            return projectPlanning;
        }

        public int UpdateGPScheduleDate(string company, string jobNumber, DateTime scheduleStartDate, DateTime scheduleCompletionDate)
        {
            try
            {
                var pCompany = new SqlParameter();
                pCompany.ParameterName = "Company";
                pCompany.Value = company;
                pCompany.DbType = DbType.String;

                var pJobNumber = new SqlParameter();
                pJobNumber.ParameterName = "JobNumber";
                pJobNumber.Value = jobNumber;
                pJobNumber.DbType = DbType.String;

                var pScheduleStartDate = new SqlParameter();
                pScheduleStartDate.ParameterName = "ScheduleStartDate";
                pScheduleStartDate.Value = scheduleStartDate;
                pScheduleStartDate.DbType = DbType.DateTime;

                var pScheduleCompletionDate = new SqlParameter();
                pScheduleCompletionDate.ParameterName = "ScheduleCompletionDate";
                pScheduleCompletionDate.Value = scheduleCompletionDate;
                pScheduleCompletionDate.DbType = DbType.DateTime;

                var returnCode = new SqlParameter();
                returnCode.ParameterName = "@ReturnCode";
                returnCode.SqlDbType = SqlDbType.Int;
                returnCode.Direction = ParameterDirection.Output;

                var result = _context.SqlQuery<object>("Exec @ReturnCode = dbo.usp_UpdateGPScheduleDate @Company, @JobNumber, @ScheduleStartDate, @ScheduleCompletionDate", returnCode, pCompany, pJobNumber, pScheduleStartDate, pScheduleCompletionDate).FirstOrDefault();

                //int ret = _context.ExecuteSqlCommand("Exec dbo.usp_UpdateGPScheduleDate @JobNumber, @ScheduleStartDate, @ScheduleCompletionDate", false, null, pJobNumber, pScheduleStartDate, pScheduleCompletionDate);

                return (int)returnCode.Value;
            }
            catch (Exception exc)
            {
                _logService.InsertLog(LogLevel.Error, exc.Message, exc.ToString());
                return -1;
            }            
        }

        public int UpdateGPEngineer(string company, string jobNumber, string employeeId)
        {
            try
            {
                var pCompany = new SqlParameter();
                pCompany.ParameterName = "Company";
                pCompany.Value = company;
                pCompany.DbType = DbType.String;

                var pJobNumber = new SqlParameter();
                pJobNumber.ParameterName = "JobNumber";
                pJobNumber.Value = jobNumber;
                pJobNumber.DbType = DbType.String;

                var pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "EmployeeId";
                pEmployeeId.Value = employeeId;
                pEmployeeId.DbType = DbType.String;

                var returnCode = new SqlParameter();
                returnCode.ParameterName = "@ReturnCode";
                returnCode.SqlDbType = SqlDbType.Int;
                returnCode.Direction = ParameterDirection.Output;

                var result = _context.SqlQuery<object>("Exec @ReturnCode = dbo.usp_UpdateGPEngineer @Company, @JobNumber, @EmployeeId", returnCode, pCompany, pJobNumber, pEmployeeId).FirstOrDefault();

                //int ret = _context.ExecuteSqlCommand("Exec dbo.usp_UpdateGPScheduleDate @JobNumber, @ScheduleStartDate, @ScheduleCompletionDate", false, null, pJobNumber, pScheduleStartDate, pScheduleCompletionDate);

                return (int)returnCode.Value;
            }
            catch (Exception exc)
            {
                _logService.InsertLog(LogLevel.Error, exc.Message, exc.ToString());
                return -1;
            }
        }

        public int UpdateGPForeman(string company, string jobNumber, string employeeId)
        {
            try
            {
                var pCompany = new SqlParameter();
                pCompany.ParameterName = "Company";
                pCompany.Value = company;
                pCompany.DbType = DbType.String;

                var pJobNumber = new SqlParameter();
                pJobNumber.ParameterName = "JobNumber";
                pJobNumber.Value = jobNumber;
                pJobNumber.DbType = DbType.String;

                var pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "EmployeeId";
                pEmployeeId.Value = employeeId;
                pEmployeeId.DbType = DbType.String;

                var returnCode = new SqlParameter();
                returnCode.ParameterName = "@ReturnCode";
                returnCode.SqlDbType = SqlDbType.Int;
                returnCode.Direction = ParameterDirection.Output;

                var result = _context.SqlQuery<object>("Exec @ReturnCode = dbo.usp_UpdateGPForeman @Company, @JobNumber, @EmployeeId", returnCode, pCompany, pJobNumber, pEmployeeId).FirstOrDefault();

                //int ret = _context.ExecuteSqlCommand("Exec dbo.usp_UpdateGPScheduleDate @JobNumber, @ScheduleStartDate, @ScheduleCompletionDate", false, null, pJobNumber, pScheduleStartDate, pScheduleCompletionDate);

                return (int)returnCode.Value;
            }
            catch (Exception exc)
            {
                _logService.InsertLog(LogLevel.Error, exc.Message, exc.ToString());
                return -1;
            }
        }
    }
}