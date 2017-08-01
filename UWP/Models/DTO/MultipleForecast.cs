using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Uwp.Services;

namespace Uwp.Models.DTO
{
    public class MultipleForecast
    {
        public City City { get; set; }
        public List<SingleForecast> SingleForecasts { get; set; }
    }
}
