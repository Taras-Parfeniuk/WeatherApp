using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Temperature
{
    public class HourlyTemperature : DefaultTemperature
    {
        public double CurrentTemperature { get; set; }
    }
}
