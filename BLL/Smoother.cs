using System.Collections.Generic;
using System.Linq;

namespace AlarmSystem.BLL
{
    public abstract class Smoother
    {
        public double CurrentValue { get; protected set; }

        protected Smoother() { CurrentValue = double.NaN; }

        public abstract double Update(double newValue);
    }

    public class MedianSmoother : Smoother
    {
        private readonly Queue<double> m_Queue = new Queue<double>();

        public override double Update(double newValue)
        {
            m_Queue.Enqueue(newValue);

            var sourceNumbers = m_Queue.ToList();
            sourceNumbers.Sort();
            var size = sourceNumbers.Count;
            var mid = size / 2;
            var median = (size % 2 != 0) ? sourceNumbers[mid] : (sourceNumbers[mid] + sourceNumbers[mid - 1]) / 2;
            return CurrentValue = median;
        }
    }

    public class ExponentSmoother : Smoother
    {
        public double Coefficient { get; set; }

        public ExponentSmoother(double coeficient = 0.7) { Coefficient = coeficient; }

        public override double Update(double newValue) => CurrentValue = 0.7 * CurrentValue + 0.3 * newValue;
    }
}
