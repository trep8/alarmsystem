using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objects
            var smrtbldTest_1 = new TestClass(); // TestClass publisher
            var alarmSystem_1 = new AlarmSystems(); // subscriber
            
            
            // Subscriptions
            smrtbldTest_1.ToxicFire += alarmSystem_1.OnToxicFire; // event handler method subcribes to the event
            smrtbldTest_1.ExcessCO2lvl += alarmSystem_1.OnExcessCO2lvl;
            smrtbldTest_1.ToxicFire += alarmSystem_1.OnExcessCO2lvl;
            smrtbldTest_1.NormalCO2lvl += alarmSystem_1.OnNormalCO2lvl;
            
            Console.ForegroundColor = ConsoleColor.Cyan; // fancy colors because we can
            Console.WriteLine("Smart building is live!\n");
            Console.ForegroundColor = ConsoleColor.White;

            int i = 0;
            while (i < 10) 
            {
                smrtbldTest_1.RunSmartBuilding();
                i++;
                Thread.Sleep(1500);
            }
            Console.WriteLine("Press any key to continue...");           
            Console.ReadKey();
        }
    }
}
