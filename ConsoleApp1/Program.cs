using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository repo = new CityRepository();
        }
    }
}
