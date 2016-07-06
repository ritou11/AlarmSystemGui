using System.Collections.Generic;
using System.Linq;

namespace AlarmSystem.BLL
{
    public interface ISmoother
    {
        double CurrentValue { get; }

        double Update(double newValue);
    }

    public abstract class Smoother : ISmoother
    {
        public double CurrentValue { get; protected set; }

        protected Smoother() { CurrentValue = double.NaN; }

        public abstract double Update(double newValue);
    }

    public abstract class QueueSmoother : Smoother
    {
        public int MaxItem { get; set; }

        public QueueSmoother(int maxItem = 5) { MaxItem = maxItem; }

        protected readonly Queue<double> m_Queue = new Queue<double>();

        public abstract void CalculateCurrentValue();

        public override double Update(double newValue)
        {
            m_Queue.Enqueue(newValue);
            while (m_Queue.Count > MaxItem)
                m_Queue.Dequeue();

            CalculateCurrentValue();
            return CurrentValue;
        }
    }

    public class MedianSmoother : QueueSmoother
    {
        public MedianSmoother(int maxItem = 5) : base(maxItem) { }

        public override void CalculateCurrentValue()
        {
            var sourceNumbers = m_Queue.ToList();
            sourceNumbers.Sort();
            var size = sourceNumbers.Count;
            var mid = size / 2;
            var median = (size % 2 != 0) ? sourceNumbers[mid] : (sourceNumbers[mid] + sourceNumbers[mid - 1]) / 2;
            CurrentValue = median;
        }
    }

    public class MovingAverageSmoother : QueueSmoother
    {
        public MovingAverageSmoother(int maxItem = 5) : base(maxItem) { }

        public override void CalculateCurrentValue() => CurrentValue = m_Queue.Average();
    }

    public class ExponentSmoother : Smoother
    {
        public double Coefficient { get; set; }

        public ExponentSmoother(double coeficient = 0.7) { Coefficient = coeficient; }

        public override double Update(double newValue)
        {
            if (double.IsNaN(CurrentValue))
                return CurrentValue = newValue;
            return CurrentValue = Coefficient * CurrentValue + (1 - Coefficient) * newValue;
        }
    }

    public class MinSmoother : QueueSmoother
    {
        public MinSmoother(int maxItem = 5) : base(maxItem) { }

        public override void CalculateCurrentValue()
            => CurrentValue = m_Queue.Min();
    }
}
