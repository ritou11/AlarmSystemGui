using System.Collections.Generic;
using System.Linq;

namespace AlarmSystem.BLL
{
    public interface ISmoother
    {
        // ReSharper disable UnusedMemberInSuper.Global
        double CurrentValue { get; }
        // ReSharper restore UnusedMemberInSuper.Global

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
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public int MaxItem { get; set; }

        // ReSharper disable once PublicConstructorInAbstractClass
        public QueueSmoother(int maxItem) { MaxItem = maxItem; }

        protected readonly Queue<double> Queue = new Queue<double>();

        protected abstract void CalculateCurrentValue();

        public override double Update(double newValue)
        {
            Queue.Enqueue(newValue);
            while (Queue.Count > MaxItem)
                Queue.Dequeue();

            CalculateCurrentValue();
            return CurrentValue;
        }
    }

    /* public class MedianSmoother : QueueSmoother
    {
        public MedianSmoother(int maxItem) : base(maxItem) { }

        public override void CalculateCurrentValue()
        {
            var sourceNumbers = m_Queue.ToList();
            sourceNumbers.Sort();
            var size = sourceNumbers.Count;
            var mid = size / 2;
            var median = (size % 2 != 0) ? sourceNumbers[mid] : (sourceNumbers[mid] + sourceNumbers[mid - 1]) / 2;
            CurrentValue = median;
        }
    } */

    /* public class MovingAverageSmoother : QueueSmoother
    {
        public MovingAverageSmoother(int maxItem = 5) : base(maxItem) { }

        public override void CalculateCurrentValue() => CurrentValue = m_Queue.Average();
    } */

    public class ExponentSmoother : Smoother
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public double Coefficient { get; set; }

        // ReSharper disable once MemberCanBeProtected.Global
        public ExponentSmoother(double coeficient) { Coefficient = coeficient; }

        public override double Update(double newValue)
        {
            if (double.IsNaN(CurrentValue))
                return CurrentValue = newValue;
            return CurrentValue = Coefficient * CurrentValue + (1 - Coefficient) * newValue;
        }
    }

    public class MinSmoother : QueueSmoother
    {
        public MinSmoother(int maxItem) : base(maxItem) { }

        protected override void CalculateCurrentValue()
            => CurrentValue = Queue.Min();
    }
}
