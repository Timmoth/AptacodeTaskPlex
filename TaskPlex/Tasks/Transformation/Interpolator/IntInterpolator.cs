﻿using System;
using System.Collections.Generic;
using Aptacode.TaskPlex.Tasks.Transformation.Interpolator.Easers;

namespace Aptacode.TaskPlex.Tasks.Transformation.Interpolator
{
    public class IntInterpolator : Interpolator<int>
    {
        public IEnumerable<int> Interpolate(int startValue, int endValue, int stepCount, EaserFunction easer)
        {
            if (stepCount <= 0)
            {
                yield break;
            }

            //The difference between the start and end value
            var totalDifference = endValue - startValue;

            for (var stepIndex = 1; stepIndex <= stepCount; stepIndex++)
            {
                yield return startValue + (int) Math.Round(easer(stepIndex, stepCount) * totalDifference);
            }
        }
    }
}