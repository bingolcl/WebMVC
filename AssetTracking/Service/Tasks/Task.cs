using Autofac;
using Autofac.Integration.Mvc;
using Core;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Task
    {
        /// <summary>
        /// A value indicating whether a task is running
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Datetime of the last start
        /// </summary>
        public DateTime? LastStart { get; private set; }

        /// <summary>
        /// Datetime of the last end
        /// </summary>
        public DateTime? LastEnd { get; private set; }

        /// <summary>
        /// Datetime of the last success
        /// </summary>
        public DateTime? LastSuccess { get; private set; }

        /// <summary>
        /// A value indicating type of the task
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// A value indicating whether to stop task on error
        /// </summary>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// Get the task name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A value indicating whether the task is enabled
        /// </summary>
        public bool Enabled { get; set; }

        private Task()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Ctor for Task
        /// </summary>
        /// <param name="task">Task </param>
        public Task(ScheduleTask task)
        {
            this.Type = task.Type;
            this.Enabled = task.Enabled;
            this.StopOnError = task.StopOnError;
            this.Name = task.Name;
        }

        private ITask CreateTask(ILifetimeScope scope)
        {
            ITask task = null;
            if (this.Enabled)
            {
                var type2 = System.Type.GetType(this.Type);
                if (type2 != null)
                {
                    object instance;
                    if (!EngineContext.Current.ContainerManager.TryResolve(type2, scope, out instance))
                    {
                        //not resolved
                        instance = EngineContext.Current.ContainerManager.ResolveUnregistered(type2, scope);
                    }
                    task = instance as ITask;
                }
            }
            return task;
        }

        /// <summary>
        /// Executes the task
        /// </summary>
        /// <param name="throwException">A value indicating whether exception should be thrown if some error happens</param>
        /// <param name="dispose">A value indicating whether all instances hsould be disposed after task run</param>
        public void Execute(bool throwException = false, bool dispose = true)
        {
            this.IsRunning = true;

            //background tasks has an issue with Autofac
            //because scope is generated each time it's requested
            //that's why we get one single scope here
            //this way we can also dispose resources once a task is completed
            var scope = EngineContext.Current.ContainerManager.Scope();
            var scheduleTaskService = EngineContext.Current.ContainerManager.Resolve<IScheduleTaskService>("", scope);
            var scheduleTask = scheduleTaskService.GetTaskByType(this.Type);

            try
            {
                var task = this.CreateTask(scope);
                if (task != null)
                {
                    this.LastStart = DateTime.Now;
                    if (scheduleTask != null)
                    {
                        //update appropriate datetime properties
                        scheduleTask.LastStart = this.LastStart;
                        scheduleTaskService.Update(scheduleTask);
                    }

                    //execute task
                    task.Execute();
                    this.LastEnd = this.LastSuccess = DateTime.Now;
                }
            }
            catch (Exception exc)
            {
                this.Enabled = !this.StopOnError;
                this.LastEnd = DateTime.Now;

                //log error
                var _logService = EngineContext.Current.Resolve<ILogService>();
                _logService.InsertLog(LogLevel.Error, exc.Message, exc.ToString());

                if (throwException)
                    throw;
            }

            if (scheduleTask != null)
            {
                //update appropriate datetime properties
                scheduleTask.LastEnd = this.LastEnd;
                scheduleTask.LastSuccess = this.LastSuccess;
                scheduleTaskService.Update(scheduleTask);
            }

            //dispose all resources
            if (dispose)
            {
                scope.Dispose();
            }

            this.IsRunning = false;
        }
    }
}
