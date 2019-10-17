﻿using System;
using System.Threading.Tasks;

namespace Aptacode.TaskPlex.Tasks.Transformation
{
    public class StringTransformationEventArgs : BaseTaskEventArgs
    {
    }

    public class StringTransformation : PropertyTransformation<string>
    {
        public StringTransformation(object target, string property, Func<string> destinationValue, TimeSpan taskDuration, TimeSpan stepDuration) : base(target, property, destinationValue, taskDuration, stepDuration)
        {

        }
        public StringTransformation(object target, string property, string destinationValue, TimeSpan taskDuration, TimeSpan stepDuration) : base(target, property, destinationValue, taskDuration, stepDuration)
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
