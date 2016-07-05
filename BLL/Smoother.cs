using System;
using System.Collections;
using AlarmSystem.Entities;

namespace AlarmSystem.BLL
{
    internal class Smoother
    {
        private readonly Queue q_dist = new Queue();
        private double last_acc = 1.0;

        private double GetMedian(double[] sourceNumbers)
        {
            if (sourceNumbers == null ||
                sourceNumbers.Length == 0)
                throw new Exception("Median of empty array not defined.");
            double[] sortedPNumbers = (double[])sourceNumbers.Clone();
            Array.Sort(sortedPNumbers);
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        public Report Smooth(Report tosmooth)
        {
            if (tosmooth == null)
                return null;
            if (q_dist.Count >= 5)
                q_dist.Dequeue();
            q_dist.Enqueue(tosmooth.Distance);
            tosmooth.Distance = GetMedian(Array.ConvertAll(q_dist.ToArray(), o => (double)o));
            last_acc = 0.7 * last_acc + 0.3 * tosmooth.Acceleration;
            tosmooth.Acceleration = last_acc;
            return tosmooth;
        }
    }
}
