﻿using System.Linq;
using System.Threading.Tasks;
using Aptacode.TaskPlex.Enums;
using Aptacode.TaskPlex.Tasks;

namespace Aptacode.TaskPlex.Interfaces
{
    public interface ITaskCoordinator
    {
        TaskState State { get; }
        void Reset();
        void Pause();
        void Resume();
        void Stop();
        void Start();

        Task Apply(BaseTask task);
        IQueryable<BaseTask> GetTasks();
        void Stop(BaseTask task);
        void Pause(BaseTask task);
        void Resume(BaseTask task);
    }
}