﻿using System;
using System.Threading.Tasks;
using Aptacode.TaskPlex.Tasks.Transformation.EventArgs;

namespace Aptacode.TaskPlex.Tasks.Transformation
{
    public class StringTransformation : PropertyTransformation<string>
    {
        /// <summary>
        ///     Update a string property on the target to the value returned by the given Func<string> after the task duration
        /// </summary>
        /// <param name="target"></param>
        /// <param name="property"></param>
        /// <param name="destinationValue"></param>
        /// <param name="taskDuration"></param>
        /// <param name="stepDuration"></param>
        public StringTransformation(object target, string property, Func<string> destinationValue,
            TimeSpan taskDuration, TimeSpan stepDuration) : base(target, property, destinationValue, taskDuration,
            stepDuration)
        {
        }

        /// <summary>
        ///     Update a string property on the target to the specified destination value after the task duration
        /// </summary>
        /// <param name="target"></param>
        /// <param name="property"></param>
        /// <param name="destinationValue"></param>
        /// <param name="taskDuration"></param>
        /// <param name="stepDuration"></param>
        public StringTransformation(object target, string property, string destinationValue, TimeSpan taskDuration,
            TimeSpan stepDuration) : base(target, property, destinationValue, taskDuration, stepDuration)
        {
        }

        protected override async Task InternalTask()
        {
            try
            {
                RaiseOnStarted(new StringTransformationEventArgs());
                await Task.Delay(Duration, _cancellationToken.Token).ConfigureAwait(false);
                SetValue(GetEndValue());
                RaiseOnFinished(new StringTransformationEventArgs());
            }
            catch (TaskCanceledException)
            {
                RaiseOnCancelled();
            }
        }
    }
}