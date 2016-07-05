using System;

namespace AlarmSystem.BLL
{
    public interface IEventDetecter
    {
        bool Occured { get; }
    }

    public class MovingAverageEventDetecter : MovingAverageSmoother, IEventDetecter
    {
        public bool Occured { get; private set; }

        public double Criteria { get; set; }

        public MovingAverageEventDetecter(int maxItem, double criteria) : base(maxItem)
        {
            Criteria = criteria;
            m_Smoother = new MovingAverageSmoother(maxItem);
        }

        private readonly Smoother m_Smoother;

        public override double Update(double newValue)
        {
            base.Update(newValue);

            Occured = m_Smoother.Update(Math.Abs(newValue - CurrentValue) > Criteria ? 1 : 0) > 0.7;

            return CurrentValue;
        }
    }
}
