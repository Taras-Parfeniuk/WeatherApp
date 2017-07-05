using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Domain.Entities.Location;
using Domain.Data;

namespace Domain.Data
{
    public class CityRepository : ICityRepository
    {
        public IEnumerable<City> Cities
        {
            get
            {
                using (FileStream fstream = File.OpenRead("cities.list.json"))
                {
                    byte[] buf = new byte[fstream.Length];
                    fstream.Read(buf, 0, buf.Length);
                    string citiesJson = Encoding.Unicode.GetString(buf);
                    JObject o = JObject.Parse(citiesJson);
                    return o.Values<City>();
                }
            }
        }

        public City GetCityByName(string name)
        {
            return Cities.FirstOrDefault(c => c.Name == name);
        }
    }
}
