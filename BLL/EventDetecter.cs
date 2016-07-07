﻿using System;

namespace AlarmSystem.BLL
{
    public interface IEventDetecter : ISmoother
    {
        bool Occured { get; }
    }

    /* public class MovingAverageEventDetecter : MovingAverageSmoother, IEventDetecter
    {
        public bool Occured { get; private set; }

        public double Criteria { get; set; }
        public double Criteria2 { get; set; }

        public MovingAverageEventDetecter(int maxItem, double criteria, double criteria2) : base(maxItem)
        {
            Criteria = criteria;
            Criteria2 = criteria2;
            m_Smoother = new MovingAverageSmoother(maxItem);
        }

        private readonly Smoother m_Smoother;

        public override double Update(double newValue)
        {
            base.Update(newValue);

            Occured = m_Smoother.Update(Math.Abs(newValue - CurrentValue) > Criteria ? 1 : 0) > Criteria2;

            return CurrentValue;
        }
    } */

    public class CuSumEventDetecter : ExponentSmoother, IEventDetecter
    {
        public bool Occured { get; private set; }

        public double Diviation { get; private set; }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public double Criteria { get; set; }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public double Coefficient2 { get; set; }

        public CuSumEventDetecter(double coefficient, double coefficient2, double criteria) : base(coefficient)
        {
            Criteria = criteria;
            Coefficient2 = coefficient2;
            Diviation = 0;
        }

        public override double Update(double newValue)
        {
            base.Update(newValue);

            if (!double.IsNaN(CurrentValue))
                Diviation = Coefficient2 * Diviation + newValue - CurrentValue;

            Occured = Math.Abs(Diviation) > Criteria;

            //if (Occured)
            //    Diviation = 0;

            return CurrentValue;
        }
    }
}
