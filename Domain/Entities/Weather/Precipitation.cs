using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Weather
{
    public class Precipitation
    {
        public int LastHoursValue { get; set; }

        public Precipitation(int value)
        {
            LastHoursValue = value;
        }
    }
}
