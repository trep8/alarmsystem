using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class TestClass : SmartBuilding // inherits SmartBuilding, this way we can test stuff without altering our SmartBuilding
    {
        

        public override void RunSmartBuilding() // override so we make sure this method runs and not base class
        {
            var rndTest = new Random();
            // get some random values
            this.temp = rndTest.Next(0,100);
            this.setCO2_levels(rndTest.Next(0, 2000));

            Console.WriteLine("Temp:\t[{0}]\nCO2:\t[{1}]", this.temp, this.getCO2_levels());
            if (this.temp > 50 && this.getCO2_levels()> 1500)
                OnToxicFire();          // trigger event for a toxic fire
            if (this.getCO2_levels() > 1500 && this.temp <= 50)
                OnExcessCO2lvl();       // trigger event for excess co2
            if (this.getCO2_levels() < 1500)
                OnNormalCO2lvl();       // when things are normal
            Console.WriteLine("\n");

        }
    }
}
