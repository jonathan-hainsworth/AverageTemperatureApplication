using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTemperatureTests
{
    [TestFixture]
    public class UTCTimeHelper
    {
        [Test]
        public void getTimeNow()
        {
            DateTime now = new DateTime(2022,10,16,0,0,0);
            long time = now.Ticks;
            Console.WriteLine(now.ToString());
            Console.WriteLine(now.ToString());
        }
    }
}
