﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.TaskPlex.Tasks
{
    public abstract class GroupTask : BaseTask
    {
        protected GroupTask(List<BaseTask> tasks) : base(TimeSpan.Zero) => Tasks = tasks;

        internal List<BaseTask> Tasks { get; }

        /// <summary>
        /// Add a task to the group
        /// </summary>
        /// <param name="task"></param>
        public void Add(BaseTask task)
        {
            if(task == null)
            {
                return;
            }

            Tasks.Add(task);
            Duration = GetTotalDuration(Tasks);
        }

        /// <summary>
        /// Remove a task from the group
        /// </summary>
        /// <param name="task"></param>
        public void Remove(BaseTask task)
        {
            if(task == null)
            {
                return;
            }

            Tasks.Remove(task);
            Duration = GetTotalDuration(Tasks);
        }

        public IEnumerable<int> GetHashCodes() => Tasks.Select(p => p.GetHashCode());

        protected abstract TimeSpan GetTotalDuration(IEnumerable<BaseTask> tasks);
    }
}