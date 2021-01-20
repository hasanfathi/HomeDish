using System;

namespace HomeDish.Challenge.Library.Interfaces
{
    public interface IService
    {
        public double CalculateLowestTotal(Models.AggregateProduct basket);
    }
}
